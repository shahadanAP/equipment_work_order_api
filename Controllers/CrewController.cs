using EquipmentApi.Models;
using EquipmentApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentApi.Controllers
{
    [ApiController]
    [Route("api/crew")]

    public class CrewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CrewController(AppDbContext context)
        {
            _context =  context;
        }

        [HttpGet]

        public IActionResult GetCrew()
        {
            return Ok(_context.Crew.ToList());
        }

        [HttpPost]

        public IActionResult addCrew(Crew newCrew)
        {
            _context.Crew.Add(newCrew);
            _context.SaveChanges();
            return Ok(newCrew);

        }

        [HttpPut("{id}")]

        public IActionResult UpdateCrew(int id, Crew updateCrew)
        {
            var crew = _context.Crew.Find(id);
            if(crew == null)
            {
                return NotFound();
            }

            crew.CrewName = updateCrew.CrewName;
            crew.AmountOfMembers = updateCrew.AmountOfMembers;

            _context.SaveChanges();
            return Ok(crew);
        }

    }

}