using CarSharing.Application.Common.Interfaces;
using CarSharing.Infrastructure.Data;
using CarSharing.Infrastructure.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Infrastructure.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarSharingDBContext _context;

        public AppUserRepository(CarSharingDBContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUserById(string id)
        {
            return _context.Users.SingleOrDefault(user => user.Id == id);
        }
    }
}
