﻿using System;
using IdentitySample.Areas.Identity.Data;
using IdentitySample.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IdentitySample.Areas.Identity.IdentityHostingStartup))]
namespace IdentitySample.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentitySampleContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentitySampleContextConnection")));

                services.AddDefaultIdentity<IdentitySampleUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentitySampleContext>();
            });
        }
    }
}