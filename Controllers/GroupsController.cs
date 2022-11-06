using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using LibraryAPI.DTOs;

namespace LibraryAPI.Controllers {
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase {
	    private readonly LibraryContext _context;
        private readonly IMapper _mapper;

	    public GroupsController(LibraryContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupDTO>>> GetGroups(){
            var groups = await _context.Groups.ToListAsync();

            return _mapper.Map<List<GroupDTO>>(groups);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GroupDTO>> GetGroup(long id) {
            var group = await _context.Groups.FindAsync(id);

            if(group == null)
                return NotFound();

            return _mapper.Map<GroupDTO>(group);
        }

	    [HttpPost]
	    public async Task<ActionResult<GroupDTO>> PostGroup(CreateGroup data) {
            var group = _mapper.Map<Group>(data);
            _context.Add(group);
            await _context.SaveChangesAsync();

            return _mapper.Map<GroupDTO>(group);
        }
    }
}
