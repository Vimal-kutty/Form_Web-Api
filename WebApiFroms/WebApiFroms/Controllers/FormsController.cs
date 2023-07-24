using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFroms.Database;
using WebApiFroms.Model;

namespace WebApiFroms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {

        private readonly FormsDbContext _dbContext;

        public FormsController(FormsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //HTTP Get All
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FormModel>> GetAll()
        {
            var getall = _dbContext.forms.ToList();
            if (getall == null)
            {
                return NoContent();
            }
            return Ok(getall);
        }

        //HTTP Get By Id
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<FormModel>GetById(int id)
        {
            var getbyid = _dbContext.forms.Find(id);
            if (getbyid == null)
            {
                return NoContent();
            }
            return Ok(getbyid);
        }

        //HTTP Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<FormModel> Create(FormModel formModels)
        {
            var create = _dbContext.forms.AsQueryable().Where(x => x.firstname.ToLower().Trim() == formModels.firstname.ToLower().Trim()).Any();
            if (create)
            {
                return Conflict("Already Exsits");
            }

            _dbContext.forms.Add(formModels);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetById",new {id= formModels.Id},formModels);
        }

        //HTTP  Put
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FormModel> put(int id,[FromBody]FormModel puts)
        {

            var putdb = _dbContext.forms.Find(id);

            putdb.firstname = puts.firstname;
            putdb.lasttname = puts.lasttname;
            putdb.email = puts.email;
            putdb.phone = puts.phone;
            putdb.address = putdb.address;
            putdb.city = puts.city;
            putdb.state = puts.state;
            putdb.city = puts.city;
            putdb.postcode = puts.postcode;

            _dbContext.forms.Update(putdb);
            _dbContext.SaveChanges();
            return NoContent();
        }

        //HTTP Delete
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FormModel>DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var form = _dbContext.forms.Find(id);
            if (form == null)
            {
                return NotFound();
            }
            _dbContext.forms.Remove(form);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
