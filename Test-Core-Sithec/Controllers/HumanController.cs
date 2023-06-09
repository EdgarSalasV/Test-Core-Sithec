using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_Core_Sithec.Models;
using Test_Core_Sithec.Services;

namespace Test_Core_Sithec.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumanController : ControllerBase
    {
        private readonly ILogger<HumanController> _logger;
        private IHumanData _humanData;
        private readonly HumanContext _context;

        public HumanController(ILogger<HumanController> logger, IHumanData humanData, HumanContext context)
        {
            _logger = logger;
            this._humanData = humanData;
            this._context = context;
        }


        [HttpGet("GetHumanListMock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public dynamic GetHumanListMock()
        {
            try
            {
                List<Human> HumanList = _humanData.GetHumanList();

                return HumanList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("GetHumanList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Human>>> GetHumanListAsync()
        {
            try
            {
                var HumanList = await _context.Humans.ToListAsync();
                if (HumanList == null)
                {
                    return NotFound();
                }
                return HumanList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("GetHumanById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult<Human>> GetHumanById(int id)
        {
            try
            {
                var HumanList = await _context.Humans.FindAsync(id);

                if (HumanList == null)
                {
                    return NotFound();
                }

                return HumanList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult<Human>> PostProductItem(Human human)
        {
            _context.Humans.Add(human);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HumanExists(human.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetHumanById), new { id = human.Id }, human);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        public async Task<IActionResult> PutHuman(int id, Human human)
        {
            Console.WriteLine("wooow");

            if (id != human.Id)
            {
                return BadRequest();
            }

            _context.Entry(human).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool HumanExists(long id)
        {
            return _context.Humans.Any(e => e.Id == id);
        }

    }
}
