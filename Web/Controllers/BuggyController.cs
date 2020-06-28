using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Errors;

namespace Web.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly AppDbContext _context;
        public BuggyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }

        //[HttpGet("notfound")]
        [HttpGet]
        public ActionResult notfound()
        {
            var thing = _context.Set<Product>().Find(42);

            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        //[HttpGet("servererror")]
        [HttpGet]
        public ActionResult servererror()
        {
            var thing = _context.Set<Product>().Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        //[HttpGet("badrequest")]
        [HttpGet]
        public ActionResult badrequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        //[HttpGet("{id}")]
        [HttpGet]
        public ActionResult badrequest2(int id)
        {
            return Ok();
        }
    }
}