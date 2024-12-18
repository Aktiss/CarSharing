using CarSharing.Infrastructure.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Application.Common.Interfaces
{
    public interface IAppUserRepository
    {
        ApplicationUser GetUserById(string id);

    }
}
