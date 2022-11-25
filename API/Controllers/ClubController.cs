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
        public async Task<IActionResult> CreateClub(Club club)
        {
           
             _repository.Insert(club);
             _repository.SaveAsync();
            return Ok(club);
        }
    }
}