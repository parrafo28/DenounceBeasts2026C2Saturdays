using AutoMapper;
using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        public readonly DataContext Context;
        public readonly IMapper Mapper;

        //public BaseController(DataContext dataContext)
        //{
        //    Context = dataContext;
        //}
        public BaseController(DataContext dataContext, IMapper mapper)
        {
            Context = dataContext;
            Mapper = mapper;

            //var gen = new GenericRepository<int>(dataContext);
            //var gen = new GenericRepository<ComplaintTypeDto>(dataContext);
            //var gen = new GenericRepository<ComplaintType>(dataContext);
        }
    }
}
