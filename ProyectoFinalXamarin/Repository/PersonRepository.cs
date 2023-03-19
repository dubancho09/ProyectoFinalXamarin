using ProyectoFinalXamarin.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFinalXamarin.Repository
{
    public class PersonRepository
    {
        private SQLiteAsyncConnection _database;

        public PersonRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Person>().Wait();
        }

        //Insertar o Editar persona
        public async Task<int> InsertPerson(Person person)
        {
            if(person.Id != 0)
            {
               return await _database.UpdateAsync(person);
            }
            else
            {
                return await _database.InsertAsync(person);
            }
            
        }

        //Retornar lista de personas
        public async Task<List<Person>> GetAllPerson()
        {
            return await _database.Table<Person>().ToListAsync();
        }

        //Eliminar Persona
        public async Task<int> DeletePerson(Person person)
        {
            return await _database.DeleteAsync(person);
        }
    }
}
