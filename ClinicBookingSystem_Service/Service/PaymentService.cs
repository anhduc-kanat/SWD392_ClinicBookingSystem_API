using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.CustomException;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.Payment;
using ClinicBookingSystem_Service.Models.Response.Payment;
using ClinicBookingSystem_Service.ThirdParties.VnPay;
using ClinicBookingSystem_Service.ThirdParties.VnPay.Model.Request;

namespace ClinicBookingSystem_Service.Service;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVnPayService _vnPayService;
    private readonly IMapper _mapper;
    public PaymentService(IUnitOfWork unitOfWork, IVnPayService vnPayService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _vnPayService = vnPayService;
        _mapper = mapper;
    }
    public async Task<BaseResponse<CreatePaymentResponse>> CreateVnPayPaymentUrl(int appointmentId, UserInfoRequest request)
    {
        //nhan vo appointment => list ra appointmentservice => tinh tong tien cua cac appointmentservice
        var transaction = await _unitOfWork.TransactionRepository.GetTransactionByAppointmentId(appointmentId);
        if (transaction != null)
        {
            if(transaction.Status == TransactionStatus.Paid) 
                throw new CoreException("Appointment has been paid", StatusCodeEnum.BadRequest_400);
        }
        
        
        var appointment = await _unitOfWork.AppointmentRepository.GetAppointmentById(appointmentId);
        if(appointment == null) throw new CoreException("Appointment not found", StatusCodeEnum.BadRequest_400);
        var userAccount = await _unitOfWork.UserRepository.GetByIdAsync(appointment.UserAccountId.Value);
        if (userAccount == null) throw new CoreException("User not found", StatusCodeEnum.BadRequest_400);
        
        var appointmentBusinessServices =
            await _unitOfWork.AppointmentBusinessServiceRepository
                .GetAppointmentBusinessServiceByAppointmentId(appointmentId);
        long totalPrice = 0;
        foreach (var abs in appointmentBusinessServices)
        {
            totalPrice += abs.ServicePrice;
        }

        OrderRequest order = new OrderRequest
        {
            OrderId = appointment.Id.ToString(),
            TotalPrice = totalPrice,
        };
        UserInfoRequest userInfo = new UserInfoRequest
        {
            UserIpAddress = request.UserIpAddress,
            UserAccountName = userAccount.FirstName + " " +  userAccount.LastName,
            UserAccountPhone = userAccount.PhoneNumber
        };
        string url = _vnPayService.CreatePaymentUrl(order, userInfo);
        return new BaseResponse<CreatePaymentResponse>("Create payment url sucessfully", StatusCodeEnum.OK_200,
            new CreatePaymentResponse
            {
                Url = url
            });
    }

    public async Task<BaseResponse<SaveVnPayPaymentResponse>> SaveVnPayPayment(VnPayDataRequest request)
    {
        var existingTransaction = await _unitOfWork.TransactionRepository.GetTransactionByAppointmentId(int.Parse(request.vnp_TxnRef));
        
        var transaction = _mapper.Map<Transaction>(request);
        int appointmentId = int.Parse(transaction.OrderId);
        var appointment = await _unitOfWork.AppointmentRepository.GetAppointmentById(appointmentId);
        transaction.Appointment = appointment;
        
        //Thanh toan service lan dau tien (phi giu cho, phi kham benh)
        if (existingTransaction == null)
        {
            if (request.vnp_TransactionStatus == "00")
            {
                appointment.IsClinicalExamPaid = true;
                appointment.Status = AppointmentStatus.Scheduled;
                transaction.Status = TransactionStatus.Paid;
            }

            if (request.vnp_TransactionStatus == "02" && request.vnp_ResponseCode == "24")
            {
                appointment.IsClinicalExamPaid = false;
                appointment.IsActive = false;
                appointment.Status = AppointmentStatus.Cancelled;
                transaction.Status = TransactionStatus.Cancelled;
            }
            //setup job (chua hoan thien)
            else if (request.vnp_TransactionStatus == "02" && request.vnp_ResponseCode == "15")
            {
                transaction.Status = TransactionStatus.Overdue;
            }
        }
        //Thanh toan service lan thu 2 (phi dich vu)
        else
        {
            if (request.vnp_TransactionStatus == "00")
            {
                appointment.IsFullyPaid = true;
                appointment.Status = AppointmentStatus.Done;
                transaction.Status = TransactionStatus.Paid;
            }

            if (request.vnp_TransactionStatus == "02" && request.vnp_ResponseCode == "24")
            {
                appointment.IsFullyPaid = false;
                transaction.Status = TransactionStatus.Cancelled;
            }
            //setup job (chua hoan thien)
            else if (request.vnp_TransactionStatus == "02" && request.vnp_ResponseCode == "15")
            {
                transaction.Status = TransactionStatus.Overdue;
            }
        }
       

        if (transaction.Status == TransactionStatus.Paid)
            transaction.IsPay = true;
        else transaction.IsPay = false;
        
        await _unitOfWork.TransactionRepository.AddAsync(transaction);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<SaveVnPayPaymentResponse>(transaction);
        return new BaseResponse<SaveVnPayPaymentResponse>("Save payment successfully", StatusCodeEnum.OK_200, result);
    }
}