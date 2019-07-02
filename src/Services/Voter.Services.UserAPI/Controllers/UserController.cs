using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voter.Services.UserAPI.Infrastructure.Context.Model;
using Voter.Services.UserAPI.Repositories;

namespace Voter.Services.UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
		
        private readonly IRepository<UserModel> _userRepository;

		public UserController (IRepository<UserModel> repository)
		{
			this._userRepository = repository;
		}

		// GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {
            return await this._userRepository.GetAll();
        }

		// GET: api/User/5
        [HttpGet("{email}", Name = "GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
			UserModel result = await this._userRepository.GetByEmail(email);

			if(result ==  null)
			{
				return new NotFoundResult();
			}

            return new ObjectResult(result);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel user)
        {
			await this._userRepository.Create(user);
			return new OkObjectResult(user);
        }

        // PUT: api/User/{email}
        [HttpPut("{email}")]
        public async Task<IActionResult> Put(string email, [FromBody] UserModel user)
        {
			UserModel				currentUser					= await this._userRepository.GetByEmail(email);

			if(currentUser == null)
			{
				return new NotFoundResult();
			}

			user._id											= currentUser._id;

			await this._userRepository.Update(user);

			return new OkObjectResult(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string email)
        {
			UserModel user = await this._userRepository.GetByEmail(email);

			if(user == null)
			{
				return new NotFoundResult();
			}

			await this._userRepository.Delete(email);

			return new OkResult();
        }
    }
}
