using Hw13.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw13.Contracts
{
    public interface IAdminRepository
    {
        public bool Login(string userName, string pass);
        public void Register(Admin admin);
        public Admin GetForUserName(string userName);
    }
}
