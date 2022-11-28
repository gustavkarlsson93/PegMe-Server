using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PegMe.Models;

namespace API.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IGenericRepository<Club> _repository;

        public ClubController(IGenericRepository<Club> repository)
        {
            _repository = repository;

        }
        
        [HttpPost]
        public async Task<IActionResult> CreateClubAsync(Club club)
        {
            
             _repository.InsertAsync(club);
             _repository.SaveAsync();
            return Ok(club);
        }
        [HttpGet("GetAllClubs")]
        public async Task<IActionResult> GetAllClubs()
        {
            var ListOfClubs = await _repository.ListAllAsync();
            return Ok(ListOfClubs);
        }
    }
}