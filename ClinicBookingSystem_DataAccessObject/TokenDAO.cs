using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_DataAccessObject
{
    public class TokenDAO:BaseDAO<Token>
    {
        private readonly ClinicBookingSystemContext _dbContext;
        public TokenDAO(ClinicBookingSystemContext dbContext): base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Token> GetTokenByTimestamp(string timestamp)
        {
            string timestampWithoutHeader = timestamp.Substring("Timestamp: ".Length);
         /*   DateTime timestamps;
            if (!DateTime.TryParseExact(timestampWithoutHeader, "yyyy-MM-dd HH:mm:ss.fffffff",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out timestamps))
            {
                // Xử lý trường hợp không thể chuyển đổi timestamp thành DateTime
                throw new ArgumentException("Invalid timestamp format", nameof(timestamp));
            }*/
            Token token = await _dbContext.Tokens.FirstOrDefaultAsync(t => t.TimeStamps.ToString() == timestampWithoutHeader);
            return token;
        }
    }
}
