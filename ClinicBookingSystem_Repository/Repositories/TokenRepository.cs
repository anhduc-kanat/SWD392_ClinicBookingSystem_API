using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Repository.Repositories
{
    public class TokenRepository : BaseRepository<Token>, ITokenRepository
    {
        private readonly TokenDAO _tokenDAO;
        public TokenRepository(TokenDAO tokenDAO): base(tokenDAO) 
        {
            _tokenDAO = tokenDAO;
        }

        public Task<Token> GetTokenByTimestamp(string timestamp)
        {
            return _tokenDAO.GetTokenByTimestamp(timestamp);
        }
    }
}
