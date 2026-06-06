using DenounceBeasts.API.Data;
using DenounceBeasts.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalitiesController : ControllerBase
    {

        //private readonly DbContextOptions<DataContext> options;
        private readonly DataContext _context;
        public MunicipalitiesController(DataContext context)
        {
            //options = new DbContextOptionsBuilder<DataContext>()
            //    .UseSqlServer(databaseName: "MunicipalitiesDB")
            //    .Options;
            //_context = new DataContext(options);
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Municipality>> GetAll()
        {
            //var options = new DbContextOptionsBuilder<DataContext>()
            //    .UseSqlServer(databaseName: "MunicipalitiesDB")
            //    .Options;
            //var context = new DataContext(options);
            var _municipalities = _context.Municipalities.ToList();
            // Retornamos 200 OK con la lista completa.
            return Ok(_municipalities);
        }

        [HttpGet]
        [Route("with-sectors")]
        public ActionResult<IEnumerable<MunicipalityDto>> GetAllWithSectors()
        {

            var _municipalities = _context.Municipalities.Include(s=> s.Sectors)
                .ToList();
            //var sectos = _context.Sectors.ToList();


            var result = new List<MunicipalityDto>();

            //foreach (var municipality in _municipalities)
            //{
            //    // var sectorsForMunicipality = _context.Sectors.Where(s => s.MunicipalityId == municipality.Id).ToList();
            //    var sectorsForMunicipality = sectos.Where(s => s.MunicipalityId == municipality.Id).ToList();
            //    //var municipalityDto = new MunicipalityDto
            //    //{
            //    //    Id = municipality.Id,
            //    //    Name = municipality.Name,
            //    //    PostalCode = municipality.PostalCode,
            //    //    IsActive = municipality.IsActive, 
            //    //}; 
            //    //foreach (var sector in sectorsForMunicipality)
            //    //{
            //    //    var sectorDto = new SectorDto
            //    //    {
            //    //        Id = sector.Id,
            //    //        Name = sector.Name,
            //    //        IsActive = sector.IsActive
            //    //    };
            //    //    municipalityDto.Sectors.Add(sectorDto);
            //    //}
            //    var municipalityDto = new MunicipalityDto
            //    {
            //        Id = municipality.Id,
            //        Name = municipality.Name,
            //        PostalCode = municipality.PostalCode,
            //        IsActive = municipality.IsActive,
            //        Sectors = sectorsForMunicipality.Select(s => new SectorDto
            //        {
            //            Id = s.Id,
            //            Name = s.Name,
            //            IsActive = s.IsActive
            //        }).ToList()
            //    };
            //    result.Add(municipalityDto);
            //}
          //result = _municipalities.Select(m => new MunicipalityDto
          //  {
          //      Id = m.Id,
          //      Name = m.Name,
          //      PostalCode = m.PostalCode,
          //      IsActive = m.IsActive,
          //      Sectors = sectos.Where(s => s.MunicipalityId == m.Id).Select(s => new SectorDto
          //      {
          //          Id = s.Id,
          //          Name = s.Name,
          //          IsActive = s.IsActive
          //      }).ToList()
          //  }).ToList();

          result = _municipalities.Select(m => new MunicipalityDto
            {
                Id = m.Id,
                Name = m.Name,
                PostalCode = m.PostalCode,
                IsActive = m.IsActive,
                Sectors = m.Sectors.Select(s => new SectorDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive
                }).ToList()
            }).ToList();

            return Ok(result);
        }


        [HttpGet("{id}")] // GET: api/municipalities/5
        public ActionResult<Municipality> GetById(int id)
        {
            var municipality = _context.Municipalities.FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                // Retornar 404 si no se encontró
                return NotFound();
            }
            return Ok(municipality);
        }


        //[HttpPost] // POST: api/municipalities
        //public ActionResult<int> CreateTemp(CreateMunicipalityDto request)
        //{  
        //    var municipality = new Municipality
        //    {
        //        Name = request.Name,
        //        PostalCode = request.PostalCode,
        //        IsActive = true
        //    };
        //    //_context.Municipalities.Add(request);
        //    _context.Municipalities.Add(municipality);
        //    _context.SaveChanges();
        //    //return Ok(new { id = request.Id }); 
        //    return Ok();
        //}

        [HttpPost] // POST: api/municipalities
        public ActionResult<int> Create(CreateMunicipalityDto request)
        {
            //var options = new DbContextOptionsBuilder<DataContext>()
            //   .UseSqlServer(databaseName: "MunicipalitiesDB")
            //   .Options;
            //var context = new DataContext(options);

            // Validación manual adicional: nombre no vacío (alternativa a [Required]).
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of municipality is required.");
            }

            var municipality = new Municipality
            {
                Name = request.Name,
                PostalCode = request.PostalCode,
                IsActive = true
            };
            // municipality.Id = 1500;

            _context.Municipalities.Add(municipality);
            _context.SaveChanges();
            return Ok(new { id = municipality.Id });

        }


        [HttpPut("{id}")] // PUT: api/municipalities/5
        public IActionResult Update(int id, UpdateMunicipalityDto request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            var existing = _context.Municipalities.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            // Opcional: validar que municipality.Id == id si quisiéramos forzar consistencia.
            // Actualizar propiedades (excepto el Id)
            existing.Name = request.Name;
            existing.PostalCode = request.PostalCode;
            existing.IsActive = request.IsActive;

            _context.Municipalities.Update(existing);
            _context.SaveChanges();

            // Retornar 204 NoContent indicando que se realizó la operación sin devolver cuerpo.
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/municipalities/5
        public IActionResult Delete(int id)
        {
            var existing = _context.Municipalities.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _context.Municipalities.Remove(existing);
            //_context.Remove(existing);
            _context.SaveChanges();
            // Retornamos 204 NoContent para indicar que se eliminó correctamente (sin contenido).
            return NoContent();
        }

        //private static readonly List<Municipality> _municipalities = new List<Municipality>
        //{
        //    new Municipality { Id = 1, Name = "Santo Domingo", PostalCode = "10101", IsActive = true },
        //    new Municipality { Id = 2, Name = "Santiago de los Caballeros", PostalCode = "51000", IsActive = true },
        //    new Municipality { Id = 3, Name = "Puerto Plata", PostalCode = "57000", IsActive = true }
        //};

        //[HttpGet] // GET: api/municipalities
        //public ActionResult<IEnumerable<Municipality>> GetAll()
        //{
        //    // Retornamos 200 OK con la lista completa.
        //    return Ok(_municipalities);
        //}

        //[HttpGet("{id}")] // GET: api/municipalities/5
        //public ActionResult<Municipality> GetById(int id)
        //{
        //    var municipality = _municipalities.FirstOrDefault(m => m.Id == id);
        //    if (municipality == null)
        //    {
        //        // Retornar 404 si no se encontró
        //        return NotFound();
        //    }
        //    return Ok(municipality);
        //}

        //[HttpPost] // POST: api/municipalities
        //public ActionResult<Municipality> Create(Municipality municipality)
        //{
        //    // Validación manual adicional: nombre no vacío (alternativa a [Required]).
        //    if (string.IsNullOrWhiteSpace(municipality.Name))
        //    {
        //        return BadRequest("Name of municipality is required.");
        //    }
        //    int newId = _municipalities.Any() ? _municipalities.Max(m => m.Id) + 1 : 1;
        //    municipality.Id = newId;
        //    if (municipality.IsActive == false)
        //    {
        //        // Por lógica de negocio, podríamos decidir que todo nuevo municipio inicia activo.
        //        municipality.IsActive = true;
        //    }

        //    _municipalities.Add(municipality);
        //    // Devolver respuesta 201 Created con el recurso creado
        //    return CreatedAtAction(
        //        nameof(GetById),              // Nombre de la acción para generar el link de detalle
        //        new { id = municipality.Id }, // Valores de ruta (el id del nuevo recurso)
        //        municipality                  // El objeto creado (en el cuerpo de la respuesta)
        //    );
        //}

        //[HttpPut("{id}")] // PUT: api/municipalities/5
        //public IActionResult Update(int id, Municipality municipality)
        //{
        //    var existing = _municipalities.FirstOrDefault(m => m.Id == id);
        //    if (existing == null)
        //    {
        //        return NotFound();
        //    }
        //    // Opcional: validar que municipality.Id == id si quisiéramos forzar consistencia.
        //    // Actualizar propiedades (excepto el Id)
        //    existing.Name = municipality.Name;
        //    existing.PostalCode = municipality.PostalCode;
        //    existing.IsActive = municipality.IsActive;
        //    // Retornar 204 NoContent indicando que se realizó la operación sin devolver cuerpo.
        //    return NoContent();
        //}

        //[HttpDelete("{id}")] // DELETE: api/municipalities/5
        //public IActionResult Delete(int id)
        //{
        //    var existing = _municipalities.FirstOrDefault(m => m.Id == id);
        //    if (existing == null)
        //    {
        //        return NotFound();
        //    }
        //    _municipalities.Remove(existing);
        //    // Retornamos 204 NoContent para indicar que se eliminó correctamente (sin contenido).
        //    return NoContent();
        //}
    }
}
