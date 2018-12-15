using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Voter.Services.UserAPI.Infrastructure.Context.Model
{
	public class UserModel
	{
		[BsonId]
		public int id { get; set; }
		public string Name { get; set; }
	}
}
