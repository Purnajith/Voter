using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Voter.Web.Infrastructure.API.Models;

namespace Voter.Web.Infrastructure.API
{
	public class UserAPI
	{
		public static async Task<UserModel> GetUserByName(string name)
		{
			UserModel					result						= null;
			HttpClient					httpClient					= new HttpClient();
			
			HttpResponseMessage			response					= await httpClient.GetAsync("https://voter.services.userapi/api/user");

			if(response.IsSuccessStatusCode)
			{
				result												= await response.Content.ReadAsAsync<UserModel>();
			}


			return  result;
		}
	}
}
