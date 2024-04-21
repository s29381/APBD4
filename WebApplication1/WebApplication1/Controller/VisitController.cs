using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataBase;

namespace WebApplication1.Controller;

[ApiController, Route("Visit")]
public class VisitController : ControllerBase
{
    private IMockDB _mockDB;

    public VisitController(IMockDB mockDb)
    {
        _mockDB = mockDb; 
    }
    
    [HttpGet("Get visit for animal")]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        var visits = _mockDB.GetVisitsForAnimal(animalId);

        if (visits.Equals(null) || visits.Count == 0)
        {
            return NotFound("Brak wizyt powiązanych z danym zwierzęciem.");
        }

        return Ok(visits);
    }
    
    [HttpGet("Get all")]
    public IActionResult GetAll()
    {
        return Ok(_mockDB.GetAllVisits());
    }

    [HttpPost("Add")]
    public IActionResult AddNewVisit(Visit newVisit)
    {
        bool added = _mockDB.AddNewVisit(newVisit);

        if (!added)
        {
            return BadRequest("Nie udało się dodać nowej wizyty. Sprawdź, czy podane zwierzę istnieje.");
        }

        return Created($"vet/{newVisit.Date}", newVisit);
    }


}