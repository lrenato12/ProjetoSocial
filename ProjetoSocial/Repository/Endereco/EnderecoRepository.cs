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
            if (string.IsNullOrEmpty(Endereco.Id))
            { var guid = Guid.NewGuid(); Endereco.Id = guid.ToString(); }
            DBcontext.Endereco.Add(Endereco);
            Save();
        }

        public IEnumerable<Models.Endereco> GetEnderecos()
        {
            return DBcontext.Endereco.ToList();
        }

        public Models.Endereco GetEnderecoByID(string EnderecoId)
        {
            return DBcontext.Endereco.Find(EnderecoId);
        }

        public void UpdateEndereco(Models.Endereco Endereco)
        {
            DBcontext.Entry(Endereco).State = EntityState.Modified;
            Save();
        }

        public void DeleteEndereco(string EnderecoId)
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