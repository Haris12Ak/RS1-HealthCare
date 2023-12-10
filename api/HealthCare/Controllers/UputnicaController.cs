using HealthCare.Data;
using HealthCare.ViewModels.Karton;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UputnicaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UputnicaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var pacijent = _dbContext.Pacijent.Find(id);

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji u bazi!");

            var result = _dbContext.Uputnica.Where(p => p.PacijentId == id)
                .Select(x => new UputniceVM
                {
                    uputnicaId = x.Id,
                    odjeljenje = x.Odjeljenje,
                    dijagnoza = x.Dijagnoza,
                    datum_izdavanja = x.DatumIzdavanja.ToString("dd/MM/yyyy"),
                    datum_vazenja = x.DatumVazenja.ToString("dd/MM/yyyy"),
                    izdaoLjekar = x.Ljekar.Ime + " " + x.Ljekar.Prezime,
                    specijalizacija_ljekara = x.Ljekar.Specjalizacija
                }).ToList();

            return Ok(result);
        }
    }
}