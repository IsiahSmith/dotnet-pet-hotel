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
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return new List<PetOwner>();
        }

















        //PUT /api/PetOwners/:id, body must be JSON with all required fields 
        //id = id of petOwner in DB
        //petOwner= the petOwner JSON object 
        [HttpPut("{id}")]
        public IActionResult Put(int id, PetOwner petOwner)
        {
            Console.WriteLine("In PUT route");

            if(id != petOwner.id){
                return BadRequest(); //400
            }

            //update in DB 
            _context.PetOwners.Update(petOwner);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
