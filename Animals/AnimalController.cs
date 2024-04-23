using Microsoft.AspNetCore.Mvc;

namespace AnimalRestAPI.Animals;

[ApiController]
[Route("/api/animals")]
public class AnimalController : ControllerBase
{
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetAllAnimals([FromQuery] string? orderBy)
    {
        orderBy ??= "name";
        string[] validOrderParameters = ["name", "description", "category", "area"];
        if (!validOrderParameters.Contains(orderBy))
        {
            return BadRequest("Cannot sort by: " + orderBy);
        }
        var animals = "All Animals"; //TODO: fetch from DB
        return Ok(animals);
    }
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult CreateAnimal([FromBody] CreateAnimalDTO dto)
    {
   
        var success = true; //TODO: save in DB
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }
    [HttpPut("{idAnimal:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateAnimal([FromBody] UpdateAnimalDTO dto)
    {
   
        var success = true; //TODO: update in DB
        return success ? StatusCode(StatusCodes.Status200OK) : Conflict();
    }
    [HttpDelete("{idAnimal:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteAnimal([FromRoute] int idAnimal)
    {
        var success = true; //TODO: delete in DB
        return success ? StatusCode(StatusCodes.Status200OK) : Conflict();
    }
}