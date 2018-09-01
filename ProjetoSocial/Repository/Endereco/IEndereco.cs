using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSocial.Repository.Endereco
{
    public interface IEndereco
    {
        void InsertEndereco(Models.Endereco Endereco);
        IEnumerable<Models.Endereco> GetEnderecos();
        Models.Endereco GetEnderecoByID(int EnderecoId);
        void UpdateEndereco(Models.Endereco Endereco);
        void DeleteEndereco(int EnderecoId);
        void Save();
    }
}
