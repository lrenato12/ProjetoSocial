using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjetoSocial.Models;
namespace ProjetoSocial.Repository.Login
{
    public class LoginRepository : ILogin
    {
        private ProjetoSocialEntities DBcontext;
        public LoginRepository(ProjetoSocialEntities objempcontext)
        {
            this.DBcontext = objempcontext;
        }

        public void InsertLogin(Models.Login Login)
        {
            if (string.IsNullOrEmpty(Login.Id))
            { var guid = Guid.NewGuid(); Login.Id = guid.ToString(); }
            DBcontext.Login.Add(Login);
            Save();
        }

        public IEnumerable<Models.Login> GetLogins()
        {
            return DBcontext.Login.ToList();
        }

        public Models.Login GetLoginByID(string LoginId)
        {
            return DBcontext.Login.Find(LoginId);
        }

        public Models.Login GetLoginByUserPass(string user, string password)
        {
            var vLogin = DBcontext.Login.FirstOrDefault(p => p.Usuario.Equals(user));
            if (vLogin != null)
            {
                if (Equals(vLogin.Status, "1"))
                {
                    if (Equals(vLogin.Senha, password))
                    {
                        return vLogin;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }

        public void UpdateLogin(Models.Login Login)
        {
            DBcontext.Entry(Login).State = EntityState.Modified;
            Save();
        }

        public void DeleteLogin(string LoginId)
        {
            Models.Login log = DBcontext.Login.Find(LoginId);
            if (log != null)
            {
                DBcontext.Login.Remove(log);
                Save();
            }
        }

        public void Save()
        {
            DBcontext.SaveChanges();
        }
    }
}