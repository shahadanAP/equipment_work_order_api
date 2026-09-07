using EquipmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using EquipmentApi.Data;

namespace EquipmentApi.Controllers
{

    [ApiController]
    [Route("api/equipment")]   

    public class EquipmentController : ControllerBase
    {
         private readonly AppDbContext _context;

        public EquipmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEquipment()
        {
            return Ok(_context.Equipment.ToList());
        }

        [HttpPost]
        public IActionResult AddEquipment(Equipment newEquipment)
        {
            _context.Equipment.Add(newEquipment);
            _context.SaveChanges();
            return Ok(newEquipment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEquipment(int id)
        {
           var equipment = _context.Equipment.Find(id);
           if (equipment == null)
            {
                return NotFound();
            }
            _context.Equipment.Remove(equipment);
            _context.SaveChanges();
            return Ok(equipment);

        } 


    }
}