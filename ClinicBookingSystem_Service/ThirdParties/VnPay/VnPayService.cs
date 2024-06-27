using System.Globalization;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Payment;
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

    public string CreatePaymentUrl(OrderRequest order, UserInfoRequest user)
    {
        //Vnpay config
        string vnp_Returnurl = _vnPayConfig.vnp_Returnurl;
        string vnp_Url = _vnPayConfig.vnp_Url;
        string vnp_TmnCode = _vnPayConfig.vnp_TmnCode;
        string vnp_HashSecret = _vnPayConfig.vnp_HashSecret;
        VnPayLibrary vnpay = new VnPayLibrary();

        //Get TimeStamp as UTC+7
        GenerateTimeStamp generateTimeStamp = new GenerateTimeStamp();
        string vnp_CreateDate = generateTimeStamp.GetTimeStamp();
        DateTime createTime = DateTime.ParseExact(vnp_CreateDate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        string vnp_ExpireDate = createTime.AddMinutes(10).ToString("yyyyMMddHHmmss");
        
        //Add Vnpay data to query string
        vnpay.AddRequestData("vnp_Version", "2.1.0"); //version
        vnpay.AddRequestData("vnp_Command", "pay"); //action payment (default o day la thanh toan binh thuong)
        vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode); 
        vnpay.AddRequestData("vnp_Locale", "vn"); //ngon ngu (tieng viet)
        vnpay.AddRequestData("vnp_CurrCode", "VND");  //chi ho tro vnd
        vnpay.AddRequestData("vnp_TxnRef", order.OrderId); //orderId (appointmentId)
        vnpay.AddRequestData("vnp_OrderInfo", $"Thanh toan don hang: {order.OrderId}\nKhach hang: {user.UserAccountName}\nSDT: {user.UserAccountPhone}"); //orderDescription
        vnpay.AddRequestData("vnp_OrderType", "other"); //orderType (nay dua theo mat hang vnpay quy dinh)
        vnpay.AddRequestData("vnp_Amount", (order.TotalPrice * 100).ToString()); //Gia tien tong cong (x100 de ra tien thanh toan. Vi du 10k = 10,000 * 100 = 1,000,000)
        vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl); //Return url de get param tu vnpay
        vnpay.AddRequestData("vnp_ExpireDate", vnp_ExpireDate); //Set thoi gian het han cua don hang (o day tinh la 5p)
        vnpay.AddRequestData("vnp_IpAddr", user.UserIpAddress); //Ip cua user thanh toan
        vnpay.AddRequestData("vnp_CreateDate", vnp_CreateDate); //Set ngay tao don hang (ngay hien tai)
        
        //Process Vnpay with Vnpay Library
        string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
        return paymentUrl;
    }
}