using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voter.Web.Models;
using Voter.Web.Infrastructure.API;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Voter.Web.Common;
using Voter.Web.Infrastructure.API.Models;

namespace Voter.Web.Controllers
{
	public class HomeController : Controller
	{
		#region Members

		private readonly IHostingEnvironment				_env;
        private readonly IOptionsSnapshot<AppSettings>		_settings;

		#endregion

		#region Constructor

		public HomeController(IHostingEnvironment env, IOptionsSnapshot<AppSettings> settings)
        {
            _env = env;
            _settings = settings;
        }

		#endregion

		#region Action Methods

		/// <summary>
		/// Home Page
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> Index()
		{
			ViewBag.UserEmail				= this.GetUserEmail().Result;

			return View();
		}


		/// <summary>
		/// Create a new user for the given information
		/// </summary>
		/// <param name="userModel"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CreatUser([FromBody] UserModel userModel)
		{
			if(userModel.IsValid())
			{
				// add to the db
				UserAPI.CreateUser(this._settings.Value.API.UserAPI, userModel);

				// set the cookie
				CookieUtility.SetEmail(this.HttpContext, userModel.Email);
			}

			return Json(userModel);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		#endregion


		#region Helpers

		/// <summary>
		/// Gets if the user is in the cookie and is in the db 
		/// </summary>
		/// <returns></returns>
		private async Task<string> GetUserEmail()
		{
			// check if the cookie exists and whats the email in the cookie 
			string				result				= CookieUtility.GetEmail(this.HttpContext);

			if(!String.IsNullOrEmpty(result))
			{
				UserModel		user				= await UserAPI.GetUserByEmail(this._settings.Value.API.UserAPI, result);

				// if the user dosnt exists we set the result as empy as the cookie user is not a valid user
				if(user == null)
				{
					result							= String.Empty;
				}
			}

			return result;
		}

		#endregion
	}
}
