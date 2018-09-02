using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjetoSocial.Models;

namespace ProjetoSocial.Repository.Contato
{
    public class ContatoRepository : IContato
    {
        private ProjetoSocialEntities DBcontext;
        public ContatoRepository(ProjetoSocialEntities objempcontext)
        {
            DBcontext = objempcontext;
        }

        public void InsertContato(Models.Contato Contato)
        {
            if (string.IsNullOrEmpty(Contato.Id))
            { var guid = Guid.NewGuid(); Contato.Id = guid.ToString(); }
            DBcontext.Contato.Add(Contato);
            Save();
        }

        public IEnumerable<Models.Contato> GetContatos()
        {
            return DBcontext.Contato.ToList();
        }

        public Models.Contato GetContatoByID(string ContatoId)
        {
            return DBcontext.Contato.Find(ContatoId);
        }

        public void UpdateContato(Models.Contato Contato)
        {
            DBcontext.Entry(Contato).State = EntityState.Modified;
            Save();
        }

        public void DeleteContato(string ContatoId)
        {
            Models.Contato con = DBcontext.Contato.Find(ContatoId);
            if (con != null)
            {
                DBcontext.Contato.Remove(con);
                Save();
            }
        }

        public void Save()
        {
            DBcontext.SaveChanges();
        }
    }
}