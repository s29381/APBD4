using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataBase;

namespace WebApplication1.Controller;

[ApiController, Route("Animal")]
public class AnimalController : ControllerBase
{
    
    private IMockDB _mockDb;

    public AnimalController(IMockDB mockDb)
    {
        _mockDb = mockDb; 
    }
    
    [HttpGet("Get all")]
    public IActionResult GetAll()
    {
        return Ok(_mockDb.GetAllAnimals());
    }
   
    [HttpGet("Get by Id")]
    public IActionResult GetDetails(int id)
    {
        var animal = _mockDb.PickAnimal(id);
        return Ok(animal);

    }

    [HttpPost("Add")]
    public IActionResult Add(Animal? animal)
    {
        _mockDb.AddAnimal(animal);
        return Created($"animal/{animal.Id}", animal);

    }
    
    [HttpPut("Replace")]
    public IActionResult Replace(int id, Animal animal)
    {
        if(_mockDb.SetAnimal(id, animal) is null)return NotFound();
        return Ok();

    }
    
    [HttpDelete("Remove")]
    public IActionResult Remove(int id)
    {
        if(_mockDb.RemoveAnimal(id) is null) return NotFound();
        return NoContent();

    }
}