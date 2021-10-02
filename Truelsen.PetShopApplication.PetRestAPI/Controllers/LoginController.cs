// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Truelsen.PetShopApplication.Core.Models;
// using Truelsen.PetShopApplication.Domain.Authentication.Helpers;
// using Truelsen.PetShopApplication.Domain.IRepositories;
//
// namespace Truelsen.PetShopApplication.RestAPI.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class LoginController : Controller
//     {
//
//
//             private IPetRepository _petRepository;
//             private IAuthenticationHelper _authHelper;
//
//             public LoginController(IRepository<User> db, IAuthenticationHelper authHelper)
//             {
//                 _userRepository = db;
//                 _authHelper = authHelper;
//             }
//
//             // POST: api/Login
//             [AllowAnonymous]
//             [HttpPost]
//             public IActionResult Post([FromBody] LoginInput model)
//             {
//                 User user = _userRepository.GetAll().FirstOrDefault(user => user.Username.Equals(model.Username));
//
//                 //Did we find a user with the given username?
//                 if (user == null)
//                     return Unauthorized();
//
//                 //Was the correct password given?
//                 if (!_authHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
//                     return Unauthorized();
//             
//                 //Authentication succesful
//                 return Ok(new
//                 {
//                     username = user.Username,
//                     token = _authHelper.GenerateToken(user)
//                 });
//             
//             }
//     }
// }