using API.DTO;
using API.ErrorResponse;
using AutoMapper;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PegMe.Models;

namespace API.Controllers
{
    public class ClubController : BaseController
    {
        private readonly IGenericRepository<Club> _repository;
        private readonly IMapper _mapper;

        public ClubController(IGenericRepository<Club> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 

        }
        
        [HttpPost]
        public async Task<IActionResult> CreateClubAsync(Club club)
        {
            
             _repository.InsertAsync(club);
             _repository.SaveAsync();
            return Ok(club);
        }

        [HttpGet("GetAllClubs")]
        public async Task<IReadOnlyList<ClubDTO>> GetAllClubs()
        {
            IReadOnlyList<Club> ListOfClubs = await _repository.ListAllAsync();
            var result = _mapper.Map<IReadOnlyList<Club>,IReadOnlyList<ClubDTO>>(ListOfClubs);
            return result;
        }
        [HttpGet("GetClubById")]
         public async Task<IActionResult> GetClubById(int id)
        {
            Club Result = await _repository.GetByIdAsync(id);
            throw new APIException(System.Net.HttpStatusCode.NotFound, "Not 123 Found");
            return Ok(Result);
        }
    }
}