using HealthCare.Data;
using HealthCare.Models;
using HealthCare.ViewModels.Korisnik;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public KorisnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Get(string id)
        {
            return Ok(_dbContext.Korisnik.FirstOrDefault(m => m.Id == id));
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetLogiraniKorisnik()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userId != null)
            {
                var user = _dbContext.Korisnik.Where(k => k.Id == userId).FirstOrDefault();

                if (user != null)
                {
                    var result = new KorisnikVM()
                    {
                        Id = user.Id,
                        Ime = user.Ime,
                        Prezime = user.Prezime,
                        Email = user.Email,
                        Role = userRole
                    };

                    return Ok(result);
                }

                return BadRequest("Korisnik nije pronaden!");
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var claims = User.Claims;

                var data = _dbContext.Korisnik.OrderBy(s => s.Ime).Select(s => new Korisnik()
                {
                    Id = s.Id,
                    KorisnickoIme = s.KorisnickoIme,
                    Password = s.Password,
                    Email = s.Email,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    BrojTelefona = s.BrojTelefona,
                }).AsQueryable();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{id}")]
        public ActionResult Update(string id, [FromBody] Korisnik k)
        {
            Korisnik korisnik;

            if (id == null)
            {
                korisnik = new Korisnik { };
                _dbContext.Add(korisnik);
            }
            else
            {
                korisnik = _dbContext.Korisnik.FirstOrDefault(k => k.Id == id);
                if (korisnik == null)
                    return BadRequest("pogresan ID");
            }

            korisnik.KorisnickoIme = k.KorisnickoIme;
            korisnik.Password = k.Password;
            korisnik.Email = k.Email;
            korisnik.Ime = k.Ime;
            korisnik.Prezime = k.Prezime;
            korisnik.BrojTelefona = k.BrojTelefona;

            _dbContext.SaveChanges();
            return Get(korisnik.Id);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Korisnik x)
        {
            var newKorisnik = new Korisnik
            {
                KorisnickoIme = x.KorisnickoIme,
                Password = x.Password,
                Email = x.Email,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojTelefona = x.BrojTelefona,
            };

            _dbContext.Add(newKorisnik);
            _dbContext.SaveChanges();
            return Ok(newKorisnik);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            Korisnik korisnik = _dbContext.Korisnik.Find(id);

            if (korisnik == null || id == "")
                return BadRequest("pogresan ID");

            _dbContext.Remove(korisnik);
            _dbContext.SaveChanges();
            return Ok(korisnik);
        }
    }
}
