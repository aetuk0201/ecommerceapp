using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Errors;
using Web.Extensions;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManger, SignInManager<AppUser> signInManager,
                                    ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManger = userManger;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManger.FindByEmailFromClaimsPrincipal(HttpContext.User);

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpGet]
        public async Task<ActionResult<bool>> EmailExists([FromQuery] string email)
        {
            return await _userManger.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet]
        public async Task<AddressDto> GetUserAddress()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var user = await _userManger.FindByUserClaimsPrincipalWithAddress(HttpContext.User);

            var shippingAddress = user.Addresses.FirstOrDefault(x => x.AddressType == "Home");

            return _mapper.Map<Address, AddressDto>(shippingAddress);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto addressDto)
        {
            var user = await _userManger.FindByUserClaimsPrincipalWithAddress(HttpContext.User);

            var address = _mapper.Map<AddressDto, Address>(addressDto);

            user.Addresses.ToList().ForEach(x =>
            {
                if (x.Id == address.Id && x.AddressType == address.AddressType)
                {
                    x.AddressLine1 = address.AddressLine1;
                    x.AddressLine2 = address.AddressLine2;
                    x.AddressType = address.AddressType;
                    x.City = address.City;
                    x.State = address.State;
                    x.ZipCode = address.ZipCode;
                }
            });

            var result = await _userManger.UpdateAsync(user);

            if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDto>(user.Addresses.SingleOrDefault(a => a.Id == address.Id && a.AddressType == address.AddressType)));

            return BadRequest("Problem updating the user");
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManger.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (EmailExists(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "email already in use. please choose another" } });
            }

            var user = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.Email,
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName
            };

            var result = await _userManger.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}