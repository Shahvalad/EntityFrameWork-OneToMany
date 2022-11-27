using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyEF.Data;

namespace OneToManyEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _context;

        public CompanyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            return Ok(await _context.Companies.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetById(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) { return BadRequest("Company not found!"); }
            return Ok(company);
        }



        [HttpPost]
        public async Task<ActionResult<List<Company>>> AddCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return Ok(company);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Company>> UpdateCompany(int id, Company company)
        {
            var updatedCompany = await _context.Companies.FindAsync(id);
            if (updatedCompany == null) { return BadRequest("Company not found!"); }
            updatedCompany.Name = company.Name;
            await _context.SaveChangesAsync();
            return Ok(updatedCompany);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var deletedCompany = await _context.Companies.FindAsync(id);
            if (deletedCompany == null) { return BadRequest("Company not found!"); }
            _context.Companies.Remove(deletedCompany);
            await _context.SaveChangesAsync();
            return Ok(deletedCompany);
        }
    }
}
