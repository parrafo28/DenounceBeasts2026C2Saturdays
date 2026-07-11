using AutoMapper;
using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.API.Models.Entities;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/sectors")]
    public class SectorsController : BaseController
    {

        private readonly DataContext _context;

        public SectorsController(DataContext context, Mapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        private static readonly List<Sector> _sectors = new List<Sector>
        {
            new Sector { Id = 1, Name = "Zona Colonial", MunicipalityId = 1, IsActive = true },
            new Sector { Id = 2, Name = "Gascue", MunicipalityId = 1, IsActive = true },
            new Sector { Id = 3, Name = "Cienfuegos", MunicipalityId = 2, IsActive = true }
        };

        [HttpGet]
        [Route("with-municipalty")]
        public ActionResult<IEnumerable<SectorDto>> GetAllWithMunicipality()
        {
            //var municipalities = _context.Municipalities.ToList();

            //var sectors = _context.Sectors.Select(s => new SectorDto
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    MunicipalityId = s.MunicipalityId,
            //    IsActive = s.IsActive, 
            //    MunicipalityName = (municipalities.FirstOrDefault(m => m.Id == s.MunicipalityId) !=null) ? municipalities.FirstOrDefault(m => m.Id == s.MunicipalityId).Name : "Unknown"
            //}).ToList();

            //foreach (var sector in sectors)
            //{
            //    var municipality = municipalities.FirstOrDefault(m => m.Id == sector.MunicipalityId);
            //    if (municipality != null)
            //    {
            //        sector.MunicipalityName = municipality.Name;
            //    }
            //    else                {
            //        sector.MunicipalityName = "Unknown";
            //    }
            //}

            var sectors = _context.Sectors.Include(s => s.Municipality).ToList();

            //var result = sectors.Select(s => new SectorDto
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    MunicipalityId = s.MunicipalityId,
            //    IsActive = s.IsActive,
            //    MunicipalityName = s.Municipality != null ? s.Municipality.Name : "Unknown"
            //}).ToList();

            var result = Mapper.Map<List<Sector>, List<SectorDto>>(sectors);

            return Ok(result);
        }

        [HttpGet] // GET: api/sectors
        public ActionResult<IEnumerable<SectorDto>> GetAll()
        {
            var sectors = _sectors.Select(s => new SectorDto
            {
                Id = s.Id,
                Name = s.Name,
                MunicipalityId = s.MunicipalityId,
                IsActive = s.IsActive
            }).ToList();
            return Ok(sectors);
        }

        [HttpGet]
        [Route("ordered")] // GET: api/sectors/ordered
        public ActionResult<IEnumerable<Sector>> GetAllOrdered()
        {
            var sectors = _sectors.OrderBy(s => s.Name).ToList();
            return Ok(sectors);
        }

        //[HttpGet]
        //[Route("/ordered")] // GET: api/sectors/ordered
        //public ActionResult<IEnumerable<Sector>> GetAllEmptyInformation()
        //{
        //    var sectors = _sectors.OrderBy(s => s.Name).ToList();
        //    return Ok(sectors);
        //}

        [HttpGet("{id}")] // GET: api/sectors/5
        public ActionResult<DetailSectorDto> GetById(int id)
        {
            var sector = _context.Sectors.Include(p => p.Municipality).FirstOrDefault(s => s.Id == id);
            if (sector == null)
                return NotFound();

            var response = new DetailSectorDto
            {
                Id = sector.Id,
                Name = sector.Name,
                MunicipalityId = sector.MunicipalityId,
                IsActive = sector.IsActive,
                MunicipalityName = sector.Municipality != null ? sector.Municipality.Name : "Unknown",
                //RandomInfo = sector.RandomInfo
            };

            return Ok(response);
        }

        [HttpPost] // POST: api/sectors
        public ActionResult<int> Create(CreateSectorDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of sector is required.");
            }
            if (request.MunicipalityId <= 0)
            {
                return BadRequest("MunicipalityId must be provided and positive.");
            }
            // (Podríamos validar aquí que exista un Municipio con ese Id consultando la lista de municipios, 
            //  pero omitiremos esa comprobación en esta versión inicial.)

            var sector = new Sector
            {
                Name = request.Name,
                MunicipalityId = request.MunicipalityId,
                IsActive = true
            };

            //int newId = _sectors.Any() ? _sectors.Max(s => s.Id) + 1 : 1;
            //sector.Id = newId;
            //sector.IsActive = true; // siempre creamos como activo
            //_sectors.Add(sector);
            //return CreatedAtAction(nameof(GetById), new { id = sector.Id }, request);
            _context.Sectors.Add(sector);
            _context.SaveChanges();
            return Ok(new { Id = sector.Id });
        }

        [HttpPut("{id}")] // PUT: api/sectors/5
        public IActionResult Update(int id, Sector sector)
        {
            var existing = _sectors.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return NotFound();
            // Actualizar campos (excepto Id)
            existing.Name = sector.Name;
            existing.MunicipalityId = sector.MunicipalityId;
            existing.IsActive = sector.IsActive;
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/sectors/5
        public IActionResult Delete(int id)
        {
            var existing = _sectors.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return NotFound();
            _sectors.Remove(existing);
            return NoContent();
        }
    }

}
