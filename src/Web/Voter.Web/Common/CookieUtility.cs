using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Voter.Web.Common
{
	public class CookieUtility
	{
		#region Constants

		private const string				COOKIE_KEY				="_tempUserEmail";

		#endregion

		#region Methods

		/// <summary>
		/// Gets the users email
		/// </summary>
		/// <param name="httpContextAccessor"></param>
		/// <returns></returns>
		public static string GetEmail(HttpContext httpContext)
		{
			string				result			= String.Empty;

			// try to get the cookie value . In case if the cookie dosnt exist could throw an exception
			try
			{
				result							= httpContext.Request.Cookies[COOKIE_KEY];
			}
			catch(Exception e)
			{
				// do nothing
			}

			return result;
		}

		/// <summary>
		/// Set the given user email to the cookie 
		/// </summary>
		/// <param name="httpContextAccessor"></param>
		/// <param name="email"></param>
		public static void SetEmail(HttpContext httpContext, string email)
		{
			CookieOptions				option				= new CookieOptions();  

			// set expiry to  1 month
			option.Expires									= DateTime.Now.AddMonths(1);

			//https://stackoverflow.com/a/52461278
			// Set the essential flag in order to overcome the gdpr issue  
			option.IsEssential								= true;

			// set to response
			httpContext.Response.Cookies.Append(COOKIE_KEY, email, option);
		}

		#endregion

	}
}
