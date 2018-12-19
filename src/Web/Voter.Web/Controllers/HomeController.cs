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

namespace Voter.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IHostingEnvironment _env;
        private readonly IOptionsSnapshot<AppSettings> _settings;

		public HomeController(IHostingEnvironment env, IOptionsSnapshot<AppSettings> settings)
        {
            _env = env;
            _settings = settings;
        }


		public async Task<IActionResult> Index()
		{
			await this.GetUserID();
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


		#region Methods

		private async Task<int> GetUserID()
		{
			int	result = -1;

			var response = await UserAPI.GetUserByName(this._settings.Value.API.UserAPI, "Yasa");

			//result = response.id;

			return result;
		}

		#endregion
	}
}
