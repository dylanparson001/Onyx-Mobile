using MauiOnyx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOnyx.API
{
    public interface ILoginService
    {

        public Task<User> Login(string username, string password, string companyId);

    }
}
