using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PetsController : ControllerBase
  {
    private readonly ApplicationContext _context;
    public PetsController(ApplicationContext context)
    {
      _context = context;
    }

    [HttpPost]
    public IActionResult Create(Pet pet)
    {
      //pet object is required on the request body
      //must be JSON
      Console.WriteLine("This is the post" + pet);
      _context.Add(pet);

      //save changes
      _context.SaveChanges();

      //respond
      return CreatedAtAction(nameof(Create), new { id = pet.id }, pet);

    }

    // PUT to update pet information
    [HttpPut("{id}")]
    public IActionResult Put(int id, Pet pet)
    {
      Console.WriteLine("In PUT");

      if (id != pet.id)
      {
        return BadRequest(); // 400
      }

      // update in DB
      _context.Update(pet);
      _context.SaveChanges();

      return NoContent();
    }

    // GET /api/pets
    // returns all pets
    [HttpGet]
    public IEnumerable<Pet> GetPets()
    {
      return _context.Pets;
    }

    // GET /api/pets/:id
    // will return the pet at that id
    [HttpGet("{id}")]
    public ActionResult<Pet> GetById(int id)
    {
      Console.WriteLine("GET /api/pets/:id");
      Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == id);

      // check that this is actually a pet object that has been returned
      if (pet == null)
      {
        return NotFound();
      }

      return pet;
    }

    // [HttpGet]
    // [Route("test")]
    // public IEnumerable<Pet> GetPets() {
    //     PetOwner blaine = new PetOwner{
    //         name = "Blaine"
    //     };

    //     Pet newPet1 = new Pet {
    //         name = "Big Dog",
    //         petOwner = blaine,
    //         color = PetColorType.Black,
    //         breed = PetBreedType.Poodle,
    //     };

    //     Pet newPet2 = new Pet {
    //         name = "Little Dog",
    //         petOwner = blaine,
    //         color = PetColorType.Golden,
    //         breed = PetBreedType.Labrador,
    //     };

    //     return new List<Pet>{ newPet1, newPet2};
    // }
  }
}
