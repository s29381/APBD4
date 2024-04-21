using WebApplication1.Controller;

namespace WebApplication1.DataBase;

public interface IMockDB
{
    public ICollection<Animal?> GetAllAnimals();
    public Animal? PickAnimal(int id);
    public Animal? RemoveAnimal(int  id);
    public bool AddAnimal(Animal? animal);
    public ICollection<Visit> GetAllVisits();
    public bool AddNewVisit(Visit visit);
    public ICollection<Visit> GetVisitsForAnimal(int animalId);
    public Animal? SetAnimal(int animalId, Animal animal);
}