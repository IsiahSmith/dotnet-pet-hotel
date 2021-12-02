using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PetOwnersController : ControllerBase
  {
    private readonly ApplicationContext _context;
    public PetOwnersController(ApplicationContext context)
    {
      _context = context;
    }

    // This is just a stub for GET / to prevent any weird frontend errors that 
    // occur when the route is missing in this controller
    [HttpGet]
    public IEnumerable<PetOwner> GetPets()
    {
      return new List<PetOwner>();
    }

    // POST /api/petowners
    // expects a PetOwner object
    [HttpPost]
    public IActionResult Post(PetOwner petOwner)
    {
      // use the _context to speak to the db
      _context.PetOwners.Add(petOwner);
      // remember to save the changes
      _context.SaveChanges();

      // return the object that was created with a URL
      return CreatedAtAction(nameof(Post), new { id = petOwner.id }, petOwner);
    }

  }
}
