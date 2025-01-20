using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using Drugsearch.Models;

namespace Drugsearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        private readonly PharmacyContext _context;

        public DrugsController(PharmacyContext context)
        {
            _context = context;
        }

        // GET: api/Drugs 获取全部药品
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrugs()
        {
            return await _context.Drugs.ToListAsync();
        }

        // GET: api/Drugs/5 根据获取单个药品
        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrug(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);

            if (drug == null)
            {
                return NotFound();
            }

            return drug;
        }

        // GET: api/Drugs/search?name=xxx 根据药品名称搜索药品
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Drug>>> SearchDrugs([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name is required");
            }

            var drugs = await _context.Drugs
            .Where(d => EF.Functions.Like(EF.Functions.Collate(d.Name, "Latin1_General_CI_AS"), $"%{name}%"))
            //忽略大小写
            .ToListAsync();

            if (drugs == null || !drugs.Any())
            {
                return NotFound("No drugs found matching the search term.");
            }

            return Ok(drugs);
        }

        // DELETE: api/Drugs/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteDrug(int id)
        // {
        //     var drug = await _context.Drugs.FindAsync(id);
        //     if (drug == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Drugs.Remove(drug);
        //     await _context.SaveChangesAsync();

        //     return Ok("Deleted");
        // }
    }
}