using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure.Context;
using DenounceBeasts.Infraestructure.Core;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    public class ComplaintTypeRepository: GenericRepository<ComplaintType>
    {  
        public ComplaintTypeRepository(DataContext context): base(context)
        { 
        } 
    }
}
