using AutoMapper;
using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.API.Models.Responses;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure.Context;
using DenounceBeasts.Infraestructure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintTypesController : BaseController
    {

        private readonly DataContext _context;
        private readonly GenericRepository<ComplaintType> repository;
        private readonly ComplaintTypeRepository complaintTypeRepository;

        public ComplaintTypesController(DataContext context,
            GenericRepository<ComplaintType> repository,
            ComplaintTypeRepository complaintTypeRepository,

            IMapper mapper) : base(context, mapper)
        {
            _context = context;
            this.repository = repository;
            this.complaintTypeRepository = complaintTypeRepository;
        }


        [HttpGet]
        public ApiResponse<IEnumerable<ComplaintTypeDto>> GetAll()
        {
            var _complaintTypes = complaintTypeRepository.GetAll();
            //var _complaintTypes = _context.ComplaintTypes.ToList();
            //var response = _complaintTypes.Select(ct => new ComplaintTypeDto
            //{
            //    Id = ct.Id,
            //    Name = ct.Name
            //}).ToList();
            //return response;
            //return _complaintTypes.Select(ct => new ComplaintTypeDto
            //{
            //    Id = ct.Id,
            //    Name = ct.Name
            //}).ToList();

            //return _context.ComplaintTypes.Select(ct => new ComplaintTypeDto
            //{
            //    Id = ct.Id,
            //    Name = ct.Name
            //}).ToList();
            //return Ok(_complaintTypes);

            //var response = Mapper.Map<IEnumerable<ComplaintType>, IEnumerable<ComplaintTypeDto>>(_complaintTypes);
            var response = Mapper.Map<IEnumerable<ComplaintTypeDto>>(_complaintTypes);

            return ApiResponse<IEnumerable<ComplaintTypeDto>>
                .SuccessResponse(response);
        }

        [HttpGet("{id}")]
        public ApiResponse<ComplaintTypeDto> GetById(int id)
        {
            var complaintType = repository.GetById(id);
            //var response =new ComplaintTypeDto();
            ComplaintTypeDto response;
            if (complaintType == null)
            {
                //NotFound();
                // return new ComplaintTypeDto();

                //response = new ComplaintTypeDto
                //{
                //    Id = 0,
                //    Name = string.Empty
                //};
                //return response;
                return ApiResponse<ComplaintTypeDto>
                    .FailureResponse("ComplaintType not found.", 404);
            }
            //else
            //{
            //response.Id = complaintType.Id;
            // response.Name = complaintType.Name;   

            //return Ok(complaintType);

            //return new ComplaintTypeDto
            //{
            //    Id = complaintType.Id,
            //    Name = complaintType.Name
            //};
            response = new ComplaintTypeDto
            {
                Id = complaintType.Id,
                Name = complaintType.Name
            };
            //}
            //return response;
            //return ApiResponse<ComplaintTypeDto>
            //    .SuccessResponse(response, 200);
            return ApiResponse<ComplaintTypeDto>
          .SuccessResponse(response);

        }



        [HttpPost]
        public ActionResult<int> Create(ComplaintTypeDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of complaintType is required.");
            }

            var complaintType = new ComplaintType
            {
                Name = request.Name
            };

            _context.ComplaintTypes.Add(complaintType);
            _context.SaveChanges();
            return Ok(new { id = complaintType.Id });

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, ComplaintTypeDto request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            var existing = _context.ComplaintTypes.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.Name = request.Name;

            _context.ComplaintTypes.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.ComplaintTypes.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _context.ComplaintTypes.Remove(existing);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
