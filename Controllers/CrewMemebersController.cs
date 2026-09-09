using EquipmentApi.Models;
using EquipmentApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentApi.Controllers
{
    [ApiController]
    [Route("api/crewmembers")]
    public class CrewMembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CrewMembersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCrewMembers()
        {
            return Ok(_context.CrewMembers.ToList());
        }

        [HttpPost]
        public IActionResult AddCrewMember(CrewMembers newMember)
        {
            _context.CrewMembers.Add(newMember);
            _context.SaveChanges();
            return Ok(newMember);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCrewMember(int id, CrewMembers updatedMember)
        {
            var member = _context.CrewMembers.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            member.MemberName = updatedMember.MemberName;
            member.MemberPosition = updatedMember.MemberPosition;
            member.CrewId = updatedMember.CrewId;

            _context.SaveChanges();
            return Ok(member);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCrewMember(int id)
        {
            var member = _context.CrewMembers.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.CrewMembers.Remove(member);
            _context.SaveChanges();
            return Ok(member);
        }
    }
}