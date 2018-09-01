using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjetoSocial.Models;

namespace ProjetoSocial.Repository.Pessoa
{
    public class PessoaRepository : IPessoa
    {
        private ProjetoSocialEntities DBcontext;
        public PessoaRepository(ProjetoSocialEntities objempcontext)
        {
            DBcontext = objempcontext;
        }

        public void InsertPessoa(Models.Pessoa Pessoa)
        {
            DBcontext.Pessoa.Add(Pessoa);
            Save();
        }

        public IEnumerable<Models.Pessoa> GetPessoas()
        {
            return DBcontext.Pessoa.ToList();
        }

        public Models.Pessoa GetPessoaByID(int PessoaId)
        {
            return DBcontext.Pessoa.Find(PessoaId);
        }

        public void UpdatePessoa(Models.Pessoa Pessoa)
        {
            DBcontext.Entry(Pessoa).State = EntityState.Modified;
            Save();
        }

        public void DeletePessoa(int PessoaId)
        {
            Models.Pessoa pes = DBcontext.Pessoa.Find(PessoaId);
            if (pes != null)
            {
                DBcontext.Pessoa.Remove(pes);
                Save();
            }
        }

        public void Save()
        {
            DBcontext.SaveChanges();
        }
    }
}