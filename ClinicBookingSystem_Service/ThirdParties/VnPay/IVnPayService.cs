using ClinicBookingSystem_Service.Models.Request.Payment;

namespace ClinicBookingSystem_Service.ThirdParties.VnPay;

public interface IVnPayService
{
    string CreatePaymentUrl(OrderRequest order, UserInfoRequest user);
    
}