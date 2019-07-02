using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Voter.Services.UserAPI.Infrastructure.Context.Model
{
	public class UserModel
	{
		[BsonId]
		public ObjectId  _id { get; set; }

		public string Email { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
