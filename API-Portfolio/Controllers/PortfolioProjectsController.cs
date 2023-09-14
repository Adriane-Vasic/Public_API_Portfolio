using API_Portfolio.Data;
using API_Portfolio.DTO;
using API_Portfolio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PortfolioProjectsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<PortfolioProject>>> GetAll()
        {
            return Ok(await _dbContext.Projects.ToListAsync());
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PortfolioProject>> GetOne(int id)
        {
            var projects = _dbContext.Projects.Find(id);

            if (projects == null)
            {
                return BadRequest("No ad was found");
            }
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> PostProject(ProjectDTO newProjectDTO)
        {

            var project = new PortfolioProject
            {
                Name = newProjectDTO.Name,
                Description = newProjectDTO.Description,
                Stack = newProjectDTO.Stack,
                Date = newProjectDTO.Date,
                ImageURL = newProjectDTO.ImageURL,
                Months = newProjectDTO.Months
            };



            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Projects.ToListAsync());


        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ProjectDTO>> UpdateProject(int id, ProjectDTO ProjectToUpdate)
        {
            var dbProject = await _dbContext.Projects.FindAsync(id);

            if (dbProject == null)
            {
                return BadRequest("No project was found");
            }

            dbProject.Name = ProjectToUpdate.Name;
            dbProject.Description = ProjectToUpdate.Description;
            dbProject.Stack = ProjectToUpdate.Stack;
            dbProject.Date = ProjectToUpdate.Date;
            dbProject.ImageURL = ProjectToUpdate.ImageURL;
            dbProject.Months = ProjectToUpdate.Months;

            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Projects.ToListAsync());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ProjectDTO>> DeleteProject(int id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            if (project == null)
            {
                return BadRequest("No project was found");
            }

            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Projects.ToListAsync());


        }






    }
}
