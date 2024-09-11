using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_Insurance.DTO;
using Travel_Insurance.Model;
using Travel_Insurance.Repository;

namespace Travel_Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimRepository ClaimRepository;
        private readonly IMapper mapper;

        public ClaimController(IClaimRepository _ClaimRepository, IMapper _mapper)
        {
            ClaimRepository = _ClaimRepository;
            mapper = _mapper;
        }



        // GET: api/Badges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Claim1DTO>> GetByIdAsync(int id)
        {
            var claim = await ClaimRepository.GetByIdAsync(id);
            if (claim == null)
            {
                return NotFound();
            }

            return Ok(claim);
        }

        // GET: api/Badge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Claim1DTO>>> GetAllAsync()
        {
            var claim = await ClaimRepository.GetAllAsync();
            return Ok(claim);
        }

        // POST: api/Badge
        [HttpPost]
        public async Task<ActionResult> PostAsync(Claim1DTO claim1Dto)
        {

            var result = await ClaimRepository.CreateClaim(claim1Dto);
            return Ok(result);
        }



        // PUT: api/Badge/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, Claim1DTO claim1Dto)
        {
            if (claim1Dto == null || claim1Dto.ClaimID != id)
            {
                return BadRequest();
            }

            var existingClaim = await ClaimRepository.GetByIdAsync(id);
            if (existingClaim == null)
            {
                return NotFound();
            }

            var res = await ClaimRepository.UpdateClaim(claim1Dto);
            return Ok(new { Message = "Record updated successfully.", UpdatedRecord = res });
        }

        // DELETE: api/Badge/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var existingClaim = await ClaimRepository.GetByIdAsync(id);
            if (existingClaim == null)
            {
                return NotFound();
            }

            await ClaimRepository.DeleteAsync(id);

            return NoContent();
        }

        // PUT: api/Claim/{id}/approve
[HttpOptions("{id}/approve")]
public async Task<IActionResult> ApproveClaimAsync(int id)
{
    var claim = await ClaimRepository.GetByIdAsync(id);
    if (claim == null)
    {
        return NotFound();
    }

    claim.ClaimStatus = "Approved";
    await ClaimRepository.UpdateClaim(claim);

    return NoContent();
}

// PUT: api/Claim/{id}/reject
[HttpOptions("{id}/reject")]
public async Task<IActionResult> RejectClaimAsync(int id)
{
    var claim = await ClaimRepository.GetByIdAsync(id);
    if (claim == null)
    {
        return NotFound();
    }

    claim.ClaimStatus = "Rejected";
    await ClaimRepository.UpdateClaim(claim);

    return NoContent();
}

    }
}