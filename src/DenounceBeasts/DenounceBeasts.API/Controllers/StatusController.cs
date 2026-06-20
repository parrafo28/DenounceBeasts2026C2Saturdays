using AutoMapper;
using DenounceBeasts.API.Data;
using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : BaseController
    {

        //private readonly DataContext _context;
        public StatusController(DataContext context, IMapper mapper) : base(context, mapper)
        {
            //_context = context;
        }


        [HttpGet]
        public IEnumerable<StatusDto> GetAll()
        {
            var _status = Context.Status.ToList();

            return _status.Select(ct => new StatusDto
            {
                Id = ct.Id,
                Name = ct.Name
            }).ToList();


        }

        [HttpGet("{id}")]
        public StatusDto GetById(int id)
        {
            var status = Context.Status.FirstOrDefault(m => m.Id == id);
            StatusDto response;
            if (status == null)
            {
                response = new StatusDto
                {
                    Id = 0,
                    Name = string.Empty
                };
                return response;
            }

            response = new StatusDto
            {
                Id = status.Id,
                Name = status.Name
            };
            return response;

        }



        [HttpPost]
        public ActionResult<int> Create(StatusDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of status is required.");
            }

            var status = new Status
            {
                Name = request.Name
            };

            Context.Status.Add(status);
            Context.SaveChanges();
            return Ok(new { id = status.Id });

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, StatusDto request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            var existing = Context.Status.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.Name = request.Name;

            Context.Status.Update(existing);
            Context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = Context.Status.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            Context.Status.Remove(existing);
            Context.SaveChanges();
            return NoContent();
        }


    }
}
