using readmypen.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readmypen.DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        public tbUsers Login(string username, string password);
    }
}
