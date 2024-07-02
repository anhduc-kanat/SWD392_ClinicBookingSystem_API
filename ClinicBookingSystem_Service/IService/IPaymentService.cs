using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Payment;
using ClinicBookingSystem_Service.Models.Response.Payment;
using ClinicBookingSystem_Service.Models.Response.Transaction;
using ClinicBookingSystem_Service.ThirdParties.VnPay.Model.Request;

namespace ClinicBookingSystem_Service.IService;

public interface IPaymentService
{
    Task<BaseResponse<CreateTransactionResponse>> CreateTransaction(CreatePaymentTransactionRequest request);
    Task<BaseResponse<CreatePaymentResponse>> CreateVnPayPaymentUrl(CreatePaymentRequest request);
    Task<BaseResponse<IEnumerable<SaveVnPayPaymentResponse>>> SaveVnPayPayment(VnPayDataRequest request);
}