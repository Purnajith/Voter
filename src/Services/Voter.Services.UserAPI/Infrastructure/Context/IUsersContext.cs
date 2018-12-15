using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Voter.Services.UserAPI.Infrastructure.Context.Model;

namespace Voter.Services.UserAPI.Infrastructure.Context
{
	public interface IUsersContext
	{
		IMongoCollection<UserModel> Users { get; }
	}
}
