using WebApplication1.Controller;

namespace WebApplication1.DataBase;

public interface IMockDB
{
    public ICollection<Animal?> GetAllAnimals();
    public Animal? GetAnimal(int id);
    public Animal? RemoveAnimal(int  id);
    public bool AddAnimal(Animal? animal);
    public ICollection<Visit> GetAllVisits();
    public bool AddVisit(Visit visit);
    public ICollection<Visit> GetVisits(int animalId);
    public Animal? SetAnimal(int animalId, Animal animal);
}