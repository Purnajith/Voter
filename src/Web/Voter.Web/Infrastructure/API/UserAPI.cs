using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Voter.Web.Infrastructure.API.Models;

namespace Voter.Web.Infrastructure.API
{
	public class UserAPI
	{
		#region Constants 

		private const string				USER					= "/api/user";
		private const string				USER_GET_BY_EMAIL		= USER + "/{0}";

		#endregion

		#region Methods

		/// <summary>
		/// Gets the user for the given email 
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		public static async Task<UserModel> GetUserByEmail(string baseUrl, string email)
		{
			UserModel					result						= null;
			HttpClient					httpClient					= new HttpClient();
			
			HttpResponseMessage			response					= await httpClient.GetAsync(baseUrl + string.Format(USER_GET_BY_EMAIL, email));
			if(response.IsSuccessStatusCode)
			{
				result												= await response.Content.ReadAsAsync<UserModel>();
			}
			return  result;
		}

		/// <summary>
		/// Creates a users in the mongo db instance
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="userModel"></param>
		/// <returns></returns>
		public static async Task<UserModel> CreateUser(string baseUrl, UserModel userModel)
		{
			UserModel					result						= null;
			HttpClient					httpClient					= new HttpClient();
			
			var							stringContent				= new StringContent(JsonConvert.SerializeObject(userModel), UnicodeEncoding.UTF8, "application/json");

			HttpResponseMessage			response					= await httpClient.PostAsync(baseUrl + USER, stringContent);
			if(response.IsSuccessStatusCode)
			{
				result												= await response.Content.ReadAsAsync<UserModel>();
			}
			return  result;
		}

		#endregion


		
	}
}
