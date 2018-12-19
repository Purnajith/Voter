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
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
			UserModel result = await this._userRepository.GetByName(name);

			if(result ==  null)
			{
				return new NotFoundResult();
			}

            return new ObjectResult(result);
        }

		// GET: api/User/5
        [HttpGet("{name}", Name = "GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
			UserModel result = await this._userRepository.GetByName(name);

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

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserModel user)
        {
			UserModel currentUser = await this._userRepository.Get(id);

			if(currentUser == null)
			{
				return new NotFoundResult();
			}

			user.id	= currentUser.id;

			await this._userRepository.Update(user);

			return new OkObjectResult(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
			UserModel user = await this._userRepository.Get(id);

			if(user == null)
			{
				return new NotFoundResult();
			}

			await this._userRepository.Delete(id);

			return new OkResult();
        }
    }
}
