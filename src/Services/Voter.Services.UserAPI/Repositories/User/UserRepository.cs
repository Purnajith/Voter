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
		#region Members

		private readonly IUsersContext  _context;

		#endregion

		#region Constructors

		public UserRepository(IUsersContext context)
		{
			_context = context;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Get all the users in the db
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<UserModel>> GetAll()
		{
			IEnumerable<UserModel>				result				= null;
			try
			{
				result												= await _context
																			.User
																			.Find(_ => true)
																			.ToListAsync();
			}
			catch (Exception e)
			{
				// need to check 
			}

			return result;
		}

		/// <summary>
		/// Get by Given Email
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public async Task<UserModel> GetByEmail(string email)
		{
			UserModel				result					= null;
			try
			{
				FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq(m => m.Email, email);
				result										= await _context
																		.User
																		.Find(filter)
																		.FirstOrDefaultAsync();
			}
			catch (Exception e)
			{
				// need to check ;
			}

			return result;
		}
       
		/// <summary>
		/// Create new user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task Create(UserModel user)
		{
			IEnumerable<UserModel>					list				= await this.GetAll();
			// We check if the suer exists if not create a new user 
			UserModel								userModel			= list.Where(x=> x.Email == user.Email).FirstOrDefault();

			if(userModel == null)
			{
				try
				{
					await _context.User.InsertOneAsync(user);
				}
				catch (Exception e)
				{
					
				}				
			}

		}

		/// <summary>
		/// Update User info
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<bool> Update(UserModel user)
		{
			ReplaceOneResult updateResult =
				await _context
						.User
						.ReplaceOneAsync(
							filter: g => g._id == user._id,
							replacement: user);
			return updateResult.IsAcknowledged
					&& updateResult.ModifiedCount > 0;
		}

		/// <summary>
		/// Delete by user ID
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public async Task<bool> Delete(string email)
		{
			FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq(m => m.Email, email);
			DeleteResult deleteResult = await _context
												.User
												.DeleteOneAsync(filter);
			return deleteResult.IsAcknowledged
				&& deleteResult.DeletedCount > 0;
		}

		#endregion
	}
}
