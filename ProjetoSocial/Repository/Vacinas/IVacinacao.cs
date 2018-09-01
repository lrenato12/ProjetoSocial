using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSocial.Repository.Vacinacaos
{
    public interface IVacinacao
    {
        void InsertVacinacao(Models.Vacinacao Vacinacao);
        IEnumerable<Models.Vacinacao> GetVacinacaos();
        Models.Vacinacao GetVacinacaoByID(int VacinacaoId);
        void UpdateVacinacao(Models.Vacinacao Vacinacao);
        void DeleteVacinacao(int VacinacaoId);
        void Save();
    }
}