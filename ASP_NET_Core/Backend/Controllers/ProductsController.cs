using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        // GET: api/persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }

        // POST: api/persons
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            // Validation des champs
            if (string.IsNullOrWhiteSpace(person.Nom) || person.Nom?.Length > 50 ||
                string.IsNullOrWhiteSpace(person.Prenom) || person.Prenom?.Length > 50 ||
                string.IsNullOrWhiteSpace(person.Adresse) || person.Adresse?.Length > 50)
            {
                return BadRequest("Les champs nom, prénom et adresse doivent être non vides et ne pas dépasser 50 caractères.");
            }

            if (person.Age.HasValue && (person.Age < 0 || person.Age > 150))
            {
                return BadRequest("L'âge doit être compris entre 0 et 150.");
            }

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        // PUT: api/persons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest("L'ID fourni ne correspond pas à l'ID de la personne.");
            }

            // Validation des champs
            if (string.IsNullOrWhiteSpace(person.Nom) || person.Nom?.Length > 50 ||
                string.IsNullOrWhiteSpace(person.Prenom) || person.Prenom?.Length > 50 ||
                string.IsNullOrWhiteSpace(person.Adresse) || person.Adresse?.Length > 50)
            {
                return BadRequest("Les champs nom, prénom et adresse doivent être non vides et ne pas dépasser 50 caractères.");
            }

            if (person.Age.HasValue && (person.Age < 0 || person.Age > 150))
            {
                return BadRequest("L'âge doit être compris entre 0 et 150.");
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne : {ex.Message}");
            }

            return NoContent();
        }

        // DELETE: api/persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}