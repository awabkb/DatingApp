using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{      [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            this._context = context;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValues(){
            var values=await _context.Values.ToListAsync();
            return new OkObjectResult(values);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult>  GetValue(int id){
            var value=await _context.Values.FirstOrDefaultAsync(x=>x.ID==id);
            return new OkObjectResult(value);
            
        }

    }
}