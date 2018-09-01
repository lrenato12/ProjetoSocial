using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSocial.Repository.Contato
{
    public interface IContato
    {
        void InsertContato(Models.Contato Contato);
        IEnumerable<Models.Contato> GetContatos();
        Models.Contato GetContatoByID(int ContatoId);
        void UpdateContato(Models.Contato Contato);
        void DeleteContato(int ContatoId);
        void Save();
    }
}
