using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Voter.Services.UserAPI.Infrastructure.Context.Model;

namespace Voter.Services.UserAPI.Infrastructure.Context
{
	public class UsersContext : IUsersContext
	{
		private readonly IMongoDatabase _db;
		public UsersContext(IOptions<AppSettings> options)
		{
			var client = new MongoClient(options.Value.MongoDB.ConnectionString);
			_db = client.GetDatabase(options.Value.MongoDB.Database);
		}
		public IMongoCollection<UserModel> User => _db.GetCollection<UserModel>("User");
	}
}
