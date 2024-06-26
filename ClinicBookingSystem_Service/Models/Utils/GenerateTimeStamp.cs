namespace ClinicBookingSystem_Service.Models.Utils;

public class GenerateTimeStamp
{
    public string GetTimeStamp()
    {
        DateTime utcNow = DateTime.UtcNow;

        // Define the GMT+7 time zone
        TimeZoneInfo gmtPlus7 = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        // Convert the current UTC time to GMT+7 time
        DateTime gmtPlus7Time = TimeZoneInfo.ConvertTimeFromUtc(utcNow, gmtPlus7);

        // Format the time as yyyyMMddHHmmss
        string timestamp = gmtPlus7Time.ToString("yyyyMMddHHmmss");

        // Print the timestamp
        Console.WriteLine(timestamp);
        return timestamp;
    }
    
}