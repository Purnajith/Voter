using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Voter.Services.UserAPI.Infrastructure.Context;
using Voter.Services.UserAPI.Infrastructure.Context.Model;

namespace Voter.Services.UserAPI.Repositories.User
{
	public class UserRepository : IRepository<UserModel>
	{
		private readonly IUsersContext  _context;
		public UserRepository(IUsersContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<UserModel>> GetAll()
		{
			return await _context
							.Users
							.Find(_ => true)
							.ToListAsync();
		}
		public Task<UserModel> Get(int ID)
		{
			FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq(m => m.id, ID);
			return _context
					.Users
					.Find(filter)
					.FirstOrDefaultAsync();
		}

		public Task<UserModel> GetByName(string name)
		{
			FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq(m => m.Name.ToLower(), name.ToLower());
			return _context
					.Users
					.Find(filter)
					.FirstOrDefaultAsync();
		}
       
		public async Task Create(UserModel user)
		{
			IEnumerable<UserModel>				list				= await this.GetAll();
			int									id					= 1;
			UserModel							last				= list.LastOrDefault();

			if(last != null)
			{
				id													= last.id + 1;
			}

			user.id													= id;

			await _context.Users.InsertOneAsync(user);
		}
		public async Task<bool> Update(UserModel user)
		{
			ReplaceOneResult updateResult =
				await _context
						.Users
						.ReplaceOneAsync(
							filter: g => g.id == user.id,
							replacement: user);
			return updateResult.IsAcknowledged
					&& updateResult.ModifiedCount > 0;
		}
		public async Task<bool> Delete(int ID)
		{
			FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq(m => m.id, ID);
			DeleteResult deleteResult = await _context
												.Users
												.DeleteOneAsync(filter);
			return deleteResult.IsAcknowledged
				&& deleteResult.DeletedCount > 0;
		}
	}
}
