using SQLite;

namespace ProyectoFinalXamarin.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
    }
}
