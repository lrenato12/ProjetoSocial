using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSocial.Models;

namespace ProjetoSocial.Repository
{
    public interface ILogin
    {
        void InsertLogin(Models.Login Login);
        IEnumerable<Models.Login> GetLogins();
        Models.Login GetLoginByID(int LoginId);
        Models.Login GetLoginByUserPass(string user, string password);
        void UpdateLogin(Models.Login Login);
        void DeleteLogin(int LoginId);
        void Save();
    }
}