using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voter.Web
{
	public class AppSettings
	{
		public Logging Logging { get; set; }
		public string AllowedHosts { get; set; }
		public API API { get; set; }
	}

	public class Logging
	{
		public Loglevel LogLevel { get; set; }
	}

	public class Loglevel
	{
		public string Default { get; set; }
	}

	public class API
	{
		public string UserAPI { get; set; }
	}

}
