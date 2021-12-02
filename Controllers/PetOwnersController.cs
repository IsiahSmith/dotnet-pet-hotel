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
        public IEnumerable<PetOwner> GetPetOwners()
        {
            Console.WriteLine("get petowners");
            return _context.PetOwners;
        }

        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetByOwnersId(int id)
        {
            Console.Write("get owners by id: " + id);

            PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.id == id);

            if (petOwner == null)
            {
                return NotFound();
            }

            return petOwner;
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

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Console.WriteLine("deleting with id" + id);
            PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.id == id);

            if (petOwner is null)
            {
                return NotFound();
            }

            _context.PetOwners.Remove(petOwner);
            _context.SaveChanges();

            return NoContent();
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

