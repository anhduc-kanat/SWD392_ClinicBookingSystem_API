using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Payment;
using ClinicBookingSystem_Service.Models.Response.Payment;
using ClinicBookingSystem_Service.ThirdParties.VnPay.Model.Request;

namespace ClinicBookingSystem_Service.IService;

public interface IPaymentService
{
    Task<BaseResponse<CreatePaymentResponse>> CreateVnPayPaymentUrl(int appointmentId, UserInfoRequest request);
    Task<BaseResponse<SaveVnPayPaymentResponse>> SaveVnPayPayment(VnPayDataRequest request);
}