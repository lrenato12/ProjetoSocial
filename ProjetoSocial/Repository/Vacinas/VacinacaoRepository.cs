using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjetoSocial.Models;
using ProjetoSocial.Repository.Vacinacaos;

namespace ProjetoSocial.Repository.Vacinas
{
    public class VacinacaoRepository : IVacinacao
    {
        private ProjetoSocialEntities DBcontext;
        public VacinacaoRepository(ProjetoSocialEntities objempcontext)
        {
            DBcontext = objempcontext;
        }

        public void InsertVacinacao(Vacinacao Vacinacao)
        {
            DBcontext.Vacinacao.Add(Vacinacao);
            Save();
        }

        public IEnumerable<Vacinacao> GetVacinacaos()
        {
            return DBcontext.Vacinacao.ToList();
        }

        public Vacinacao GetVacinacaoByID(int VacinacaoId)
        {
            return DBcontext.Vacinacao.Find(VacinacaoId);
        }

        public void UpdateVacinacao(Vacinacao Vacinacao)
        {
            DBcontext.Entry(Vacinacao).State = EntityState.Modified;
            Save();
        }

        public void DeleteVacinacao(int VacinacaoId)
        {
            Models.Vacinacao vac = DBcontext.Vacinacao.Find(VacinacaoId);
            if (vac != null)
            {
                DBcontext.Vacinacao.Remove(vac);
                Save();
            }
        }

        public void Save()
        {
            DBcontext.SaveChanges();
        }
    }
}