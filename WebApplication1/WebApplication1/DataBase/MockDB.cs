using System.Globalization;
using WebApplication1.Controller;

namespace WebApplication1.DataBase;

public class MockDB : IMockDB
{
    private readonly ICollection<Animal?> _animals;
    private readonly ICollection<Visit> _visits;

    public MockDB()
    {
        _animals = new List<Animal?>
        {
            new()
            {
                Id = 1,
                Name = "",
                Category = "kot",
                Weight = 13.4,
                FurColor = "Rudy"
            },
            new()
            {
                Id = 2,
                Name = "Osiol",
                Category = "Koniowate",
                Weight = 43.32,
                FurColor = "Szary"
            }
        };

        _visits = new List<Visit>
        {
            new()
            {
                Date = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                Animal = PickAnimal(0),
                Description = "Strzyrzenie",
                Price = 30.23
            },
            
            new()
            {
                Date = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                Animal = PickAnimal(1),
                Description = "Leczenie ",
                Price = 3000 
            },
            new()
            {
                Date = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                Animal = PickAnimal(2),
                Description = "Antybiotyk",
                Price = 321
            }
        };
    }

 

    public Animal? PickAnimal(int id)
    {
        return _animals.FirstOrDefault(e => e != null && e.Id == id);
    }

    public Animal? RemoveAnimal(int id)
    {
        var remove = _animals.FirstOrDefault(animal => animal != null && animal.Id == id);
        _animals.Remove(remove);
        return remove;

    }


    public ICollection<Animal?> GetAllAnimals()
    {
        return _animals;
    }

    public bool AddAnimal(Animal? animal)
    {
        _animals.Add(animal);
        return true;
    }

    public ICollection<Visit> GetAllVisits()
    {
        return _visits;
    }

    public bool AddNewVisit(Visit visit)
    {
        if (visit.Animal != null && visit.Animal.Equals(null))
        {
            return false; 
        }
        _visits.Add(visit);
        return true;
    }
    public ICollection<Visit> GetVisitsForAnimal(int animalId)
    {
        return _visits.Where(vet => vet.Animal != null && vet.Animal.Id == animalId).ToList();
    }


    public Animal? SetAnimal(int animalId,Animal animal)
    {
        var set = _animals.FirstOrDefault(a => a != null && a.Id == animalId);
        if (set == null) return set;
        set.Id = animal.Id;
        set.Name = animal.Name;
        set.Category = animal.Category;
        set.Weight = animal.Weight;
        set.FurColor = animal.FurColor;
        return set;
    }
}