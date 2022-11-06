using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Claims;
using LibraryAPI.Models;
using LibraryAPI.DTOs;

namespace LibraryAPI.Controllers {
    [Route("api/users")]
    [ApiController]
    public class UserAccountsController : ControllerBase {
        private readonly LibraryContext _context;
	    private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

	    public UserAccountsController(LibraryContext context, IConfiguration configuration, IMapper mapper) {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserAccountDTO>> GetUserAccount(long id) {
            var user = await _context.Users.Include(groupUser => groupUser.Groups).ThenInclude(groups => groups.Group).FirstOrDefaultAsync(u => u.Id == id);
            
            return _mapper.Map<UserAccountDTO>(user);
        }

        [HttpPost("signup")]
	    public async Task<ActionResult<UserAccountDTO>> PostUserAccount(CreateUserAccount data) {
            var user = _mapper.Map<UserAccount>(data);
            _context.Add(user);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<UserAccountDTO>(user);

            return dto;
        }

	    [HttpPost("login")]
	    public async Task<ActionResult<AuthenticationToken>> Login(AuthenticationCredentials credentials) {
            var result = _context.Users.Where(u => u.Email == credentials.Email);
	        if(!result.Any())
                return Unauthorized("{ \"message\": \"The given email doesn't exist\" }");

            var user = result.First();

            if(user.VerifyPassword(credentials.Password) == PasswordVerificationResult.Success)
                return await GetToken(user);

            return Unauthorized("Wrong password.");
        }

        [HttpPost("{id:int}/groups")]
        public ActionResult<UserAccountDTO> AddGroup(long id, AddGroupRequest body)
        {
            var group = _context.Groups.Find(body.Id);
            var user = _context.Users.Find(id);

            if (group == null || user == null)
                return NotFound();

            GroupUserAccount userGroup = new GroupUserAccount
            {
                UserAccount = user,
                Group = group
            };

            _context.Add(userGroup);
            _context.SaveChanges();
            // Eager loading sin hacer otra query.
            user = _context.Users.Include(groupUser => groupUser.Groups).ThenInclude(groups => groups.Group).FirstOrDefault(u => u.Id == id);
            
            return _mapper.Map<UserAccountDTO>(user);
        }

        private Task<AuthenticationToken> GetToken(Models.UserAccount user) {
            var claims = new List<Claim> { new Claim("email", user.Email) };
	        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["keyjwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(30);
            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: creds);

            return Task.FromResult(new AuthenticationToken {
		        Token = new JwtSecurityTokenHandler().WriteToken(token),
		        Expiration = expiration
	        });
        }
    } 
}