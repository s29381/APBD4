using System.Globalization;
using WebApplication1.Controller;

namespace WebApplication1.DataBase;

public class MockDB : IMockDB
{
    private readonly List<Animal?> _animals;
    private readonly List<Visit> _visits;

    public MockDB()
    {
        _animals = new List<Animal?>
        {
            new()
            {
                Id = 0,
                Name = "Kacper",
                Category = "Kot",
                Weight = 15.7,
                Color = "Biały"
            },
            new()
            {
                Id = 1,
                Name = "Arek",
                Category = "Pies",
                Weight = 33,
                Color = "Brązowy"
            },
            new()
            {
                Id = 2,
                Name = "Reksio",
                Category = "Pies",
                Weight = 27,
                Color = "Biało-Brązowy" 
            }
        };

        _visits = new List<Visit>
        {
            new()
            {
                Date = new DateTime(2024,12,3).ToString(CultureInfo.InvariantCulture),
                Animal = GetAnimal(0),
                Description = "Badanie Zębów",
                Price = 29
            },
            
            new()
            {
                Date = new DateTime(2024,8,27).ToString(CultureInfo.InvariantCulture),
                Animal = GetAnimal(1),
                Description = "Usunięcie kleszczy",
                Price = 30 
            },
            new()
            {
                Date = new DateTime(2024,3,5).ToString(CultureInfo.InvariantCulture),
                Animal = GetAnimal(2),
                Description = "Strzyżenie",
                Price = 32
            }
        };
    }
    
    public bool AddAnimal(Animal? animal)
    {
        _animals.Add(animal);
        return true;
    }

    public Animal? GetAnimal(int id)
    {
        return _animals.FirstOrDefault(e => e != null && e.Id == id);
    }

    public Animal? RemoveAnimal(int id)
    {
        var remove = _animals.FirstOrDefault(animal => animal != null && animal.Id == id);
        _animals.Remove(remove);
        return remove;
    }
    
    public Animal? SetAnimal(int animalId,Animal animal)
    {
        var set = _animals.FirstOrDefault(a => a != null && a.Id == animalId);
        if (set == null) return null;
        set.Id = animal.Id;
        set.Name = animal.Name;
        set.Category = animal.Category;
        set.Weight = animal.Weight;
        set.Color = animal.Color;
        return set;
    }
    
    public ICollection<Animal?> GetAllAnimals()
    {
        return _animals;
    }

    public bool AddVisit(Visit visit)
    {
        if (visit.Animal.Equals(null))
        {
            return false; 
        }
        else
        {
            _visits.Add(visit);
            return true;
        }
    }
    public ICollection<Visit> GetVisits(int animalId)
    {
        return _visits.Where(vet => vet.Animal.Id == animalId).ToList();
    }
    
    public ICollection<Visit> GetAllVisits()
    {
        return _visits;
    }
}