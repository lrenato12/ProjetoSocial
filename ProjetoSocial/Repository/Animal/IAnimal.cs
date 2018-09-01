using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSocial.Repository.Animal
{
    public interface IAnimal
    {
        void InsertAnimal(Models.Animal Animal);
        IEnumerable<Models.Animal> GetAnimals();
        Models.Animal GetAnimalByID(int AnimalId);
        void UpdateAnimal(Models.Animal Animal);
        void DeleteAnimal(int AnimalId);
        void Save();
    }
}