using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;

namespace ClinicBookingSystem_Service.Models.Pagination;

public class PaginationResponse<T> : BaseResponse<T> where T : class
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public IList<T> Data { get; set; }
    public PaginationResponse(string message, StatusCodeEnum statusCode, IList<T> data, int pageNumber, int pageSize, int totalRecords) : base(message, statusCode)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        Data = data;
    }
    
}