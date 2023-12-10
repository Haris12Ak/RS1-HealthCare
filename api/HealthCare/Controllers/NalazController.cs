using HealthCare.Data;
using HealthCare.ViewModels.Karton;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NalazController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public NalazController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var pacijent = _dbContext.Pacijent.Find(id);

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji u bazi!");

            var result = _dbContext.Nalaz.Where(p => p.PacijentId == id)
                .Select(x => new NalaziVM
                {
                    nalazId = x.Id,
                    vrsta = x.Vrsta,
                    prioritet = x.Prioritet,
                    izdaoLjekar = x.Ljekar.Ime + " " + x.Ljekar.Prezime,
                    specijalizacija_ljekara = x.Ljekar.Specjalizacija
                }).ToList();

            return Ok(result);
        }
    }
}
