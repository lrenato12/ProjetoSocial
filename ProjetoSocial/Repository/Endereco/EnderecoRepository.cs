using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjetoSocial.Models;

namespace ProjetoSocial.Repository.Endereco
{
    public class EnderecoRepository:IEndereco
    {
        private ProjetoSocialEntities DBcontext;
        public EnderecoRepository(ProjetoSocialEntities objempcontext)
        {
            DBcontext = objempcontext;
        }

        public void InsertEndereco(Models.Endereco Endereco)
        {
            DBcontext.Endereco.Add(Endereco);
            Save();
        }

        public IEnumerable<Models.Endereco> GetEnderecos()
        {
            return DBcontext.Endereco.ToList();
        }

        public Models.Endereco GetEnderecoByID(int EnderecoId)
        {
            return DBcontext.Endereco.Find(EnderecoId);
        }

        public void UpdateEndereco(Models.Endereco Endereco)
        {
            DBcontext.Entry(Endereco).State = EntityState.Modified;
            Save();
        }

        public void DeleteEndereco(int EnderecoId)
        {
            Models.Endereco end = DBcontext.Endereco.Find(EnderecoId);
            if (end != null)
            {
                DBcontext.Endereco.Remove(end);
                Save();
            }
        }

        public void Save()
        {
            DBcontext.SaveChanges();
        }
    }
}