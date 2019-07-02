using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voter.Services.UserAPI
{

	public class AppSettings
	{
		public Mongodb MongoDB { get; set; }
		public Logging Logging { get; set; }
		public string AllowedHosts { get; set; }
	}

	public class Mongodb
	{
		public string ConnectionString { get; set; }
		public string Database { get; set; }
	}

	public class Logging
	{
		public Loglevel LogLevel { get; set; }
	}

	public class Loglevel
	{
		public string Default { get; set; }
	}
}
