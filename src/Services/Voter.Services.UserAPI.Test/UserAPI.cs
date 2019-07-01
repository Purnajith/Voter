using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Services.UserAPI.Controllers;
using Xunit;

namespace Voter.Services.UserAPI.Test
{
	public class UserAPI
	{
		[Fact]	
		public void TestAPICall()
		{
			var controller = new UnitTestController();
			IEnumerable<string> result = controller.Get();

			Assert.Equal(2, result.Count());

		}
	}
}
