using System.Globalization;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Utils;
using ClinicBookingSystem_Service.ThirdParties.VnPay.Config;
using ClinicBookingSystem_Service.ThirdParties.VnPay.Library;
using Microsoft.Extensions.Options;

namespace ClinicBookingSystem_Service.ThirdParties.VnPay;

public class VnPayService : IVnPayService
{
    private readonly VnPayConfig _vnPayConfig;
    public VnPayService(IOptions<VnPayConfig> vnPayConfig)
    {
        _vnPayConfig = vnPayConfig.Value;
    }

    public string CreatePaymentUrl()
    {
        string vnp_Returnurl = _vnPayConfig.vnp_Returnurl;
        string vnp_Url = _vnPayConfig.vnp_Url;
        string vnp_TmnCode = _vnPayConfig.vnp_TmnCode;
        string vnp_HashSecret = _vnPayConfig.vnp_HashSecret;
        VnPayLibrary vnpay = new VnPayLibrary();

        GenerateTimeStamp generateTimeStamp = new GenerateTimeStamp();
        string vnp_CreateDate = generateTimeStamp.GetTimeStamp();
        DateTime createTime = DateTime.ParseExact(vnp_CreateDate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        string vnp_ExpireDate = createTime.AddMinutes(5).ToString("yyyyMMddHHmmss");
        
        vnpay.AddRequestData("vnp_Version", "2.1.0");
        vnpay.AddRequestData("vnp_Command", "pay");
        vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
        vnpay.AddRequestData("vnp_Locale", "vn");
        vnpay.AddRequestData("vnp_CurrCode", "VND");
        vnpay.AddRequestData("vnp_TxnRef", "4");
        vnpay.AddRequestData("vnp_OrderInfo", "Checkout");
        vnpay.AddRequestData("vnp_OrderType", "other");
        vnpay.AddRequestData("vnp_Amount", (10000 * 100).ToString());
        vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
        vnpay.AddRequestData("vnp_ExpireDate", vnp_ExpireDate);
        vnpay.AddRequestData("vnp_IpAddr", "171.252.189.31");
        vnpay.AddRequestData("vnp_CreateDate", vnp_CreateDate);
        string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
        return paymentUrl;
    }
}