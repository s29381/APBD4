using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataBase;

namespace WebApplication1.Controller;

[ApiController, Route("")]
public class Controller : ControllerBase
{
    
    private IMockDB _mockDb;

    public Controller(IMockDB mockDb)
    {
        _mockDb = mockDb; 
    }
    
    [HttpGet("Get all animals")]
    public IActionResult GetAllAnimals()
    {
        return Ok(_mockDb.GetAllAnimals());
    }
   
    [HttpGet("Get animal by Id")]
    public IActionResult GetAnimalById(int id)
    {
        var animal = _mockDb.GetAnimal(id);
        return Ok(animal);

    }

    [HttpPost("Add animal")]
    public IActionResult AddAnimal(Animal? animal)
    {
        _mockDb.AddAnimal(animal);
        return Created($"Dodano zwierzęcie", animal);

    }
    
    [HttpPut("Edit animal")]
    public IActionResult EditAnimal(int id, Animal animal)
    {
        if(_mockDb.SetAnimal(id, animal) is null)return NotFound();
        return Ok();

    }
    
    [HttpDelete("Remove animal")]
    public IActionResult RemoveAnimal(int id)
    {
        if(_mockDb.RemoveAnimal(id) is null) return NotFound();
        return NoContent();

    }
    
    [HttpGet("Get visits for animal")]
    public IActionResult GetVisits(int animalId)
    {
        var visits = _mockDb.GetVisits(animalId);

        if (visits.Count == 0)
        {
            return NotFound("Nie znaleziono wizyt");
        }

        return Ok(visits);
    }

    [HttpPost("Add visit")]
    public IActionResult AddVisit(Visit newVisit)
    {
        bool correct = _mockDb.AddVisit(newVisit);

        if (!correct)
        {
            return BadRequest("Podano błędne dane");
        }

        return Created($"Dodano wizytę", newVisit);
    }
}