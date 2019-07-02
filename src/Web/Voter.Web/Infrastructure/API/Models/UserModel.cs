using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voter.Web.Infrastructure.API.Models
{
	public class UserModel
	{
		public string Email { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		/// <summary>
		/// Check if the model is valid
		/// </summary>
		/// <returns></returns>
		internal bool IsValid()
		{
			return !String.IsNullOrEmpty(this.Email) && !String.IsNullOrEmpty(this.FirstName) && !String.IsNullOrEmpty(this.LastName);
		}
	}
}
