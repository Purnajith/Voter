﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Voter.Services.UserAPI.Infrastructure;
using Voter.Services.UserAPI.Infrastructure.Context;
using Voter.Services.UserAPI.Infrastructure.Context.Model;
using Voter.Services.UserAPI.Repositories;
using Voter.Services.UserAPI.Repositories.User;

namespace Voter.Services.UserAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.Configure<Settings>(
			options =>
			{
				options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
				options.Database = Configuration.GetSection("MongoDb:Database").Value;
			});

			services.AddTransient<IUsersContext, UsersContext>();


			services.AddTransient<IRepository<UserModel>, UserRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
