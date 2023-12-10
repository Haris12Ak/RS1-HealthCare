using HealthCare.Data;
using HealthCare.Models;
using HealthCare.ViewModels.Osoblje;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OsobljeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public OsobljeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Get(string id)
        {
            return Ok(_dbContext.Osoblje.FirstOrDefault(m => m.Id == id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var claims = User.Claims;

                var data = _dbContext.Osoblje.OrderBy(s => s.Id).Select(s => new Osoblje()
                {
                    Id = s.Id,
                    GodineIskustva = s.GodineIskustva
                }).AsQueryable();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetByOdjeljenje(int id)
        {
            try
            {
                var claims = User.Claims;

                var data = _dbContext.Osoblje.Where(m => m.OdjeljenjeId == id).Select(s => new OsobljePrikazVM()
                {
                    Id = s.Id,
                    GodineIskustva = s.GodineIskustva,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    BrojTelefona = s.BrojTelefona,
                    Email = s.Email
                }).AsQueryable();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{id}")]
        public ActionResult Update(string id, [FromBody] OsobljeEditVM o)
        {
            Osoblje osoblje = _dbContext.Osoblje.FirstOrDefault(l => l.Id == id);

            if (osoblje == null)
                return BadRequest("Osoba ne postoji");

            osoblje.Ime = o.Ime;
            osoblje.Prezime = o.Prezime;
            osoblje.GodineIskustva = o.GodineIskustva;
            osoblje.BrojTelefona = o.BrojTelefona;
            osoblje.Email = o.Email;

            _dbContext.SaveChanges();
            return Ok(o);
        }

        [HttpPost]
        public ActionResult Add([FromBody] OsobljeAddVM v)
        {
            if (v.Ime == "" || v.Prezime == "")
                return BadRequest();

            var osoblje = _dbContext.Osoblje.Where(x => x.Ime == v.Ime).FirstOrDefault();

            if (osoblje != null)
                return BadRequest("Ta osoba vec postoji u bazi!");

            var odjeljenje = _dbContext.Odjeljenje.Where(x => x.Id == v.OdjeljenjeId).FirstOrDefault();

            if (odjeljenje == null)
                return BadRequest("Odjeljenje nije pronađen u bazi!");

            var newOsoblje = new Osoblje
            {
                Ime = v.Ime,
                Prezime = v.Prezime,
                Email = v.Email,
                BrojTelefona = v.BrojTelefona,
                GodineIskustva = v.GodineIskustva,
                KorisnickoIme = v.Ime.ToLower(),
                Password = v.Ime + "_testOsoblje",
                OdjeljenjeId = odjeljenje.Id,
                Odjeljenje = odjeljenje,
            };

            _dbContext.Add(newOsoblje);
            _dbContext.SaveChanges();
            return Ok(newOsoblje);
        }

        [HttpGet]
        public ActionResult GetOdjeljenja()
        {
            var result = _dbContext.Odjeljenje.Select(x => new OsobljeNazivVM()
            {
                Id = x.Id,
                Naziv = x.Naziv
            }).OrderByDescending(x => x.Id).ToList();

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            Osoblje osoblje = _dbContext.Osoblje.Find(id);

            if (osoblje == null || id == "")
                return BadRequest("pogresan ID");

            _dbContext.Remove(osoblje);
            _dbContext.SaveChanges();
            return Ok(osoblje);
        }
    }
}
