﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime.Remoting.Contexts;
using SCMS.Models;
using Microsoft.AspNet.Identity.Owin;
using SCMS.Datas.DBContext;
namespace SCMS.UI.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            //var options = new CookieAuthenticationOptions();
            //options.AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active;
            //options.AuthenticationType = "ApplicationCookie";
            //options.LoginPath = new PathString("/auth/login");

            //app.UseCookieAuthentication(options);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login"),
            });
            app.CreatePerOwinContext(() => new SCMSDBContext());
            app.CreatePerOwinContext<UserManager<User>>((options, context) => new UserManager<User>(new UserStore<User>(context.Get<SCMSDBContext>())));
            app.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context) => new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context.Get<SCMSDBContext>())));
        }
    }
}