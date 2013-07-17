﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Atsumeru.Api;
using Raven.Client;

namespace Atsumeru.Api.Filters
{
    public class RavenSessionManagementAttribute : ActionFilterAttribute
    {
        private readonly IDocumentStore store;

        public RavenSessionManagementAttribute(IDocumentStore store)
        {
            if (store == null) throw new ArgumentNullException("store");
            this.store = store;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controller = actionContext.ControllerContext.Controller as AbstractApiController;
            if (controller == null)
                return;

            // Can be set explicitly in unit testing
            if (controller.RavenSession != null)
                return;

            controller.RavenSession = store.OpenSession();
            controller.RavenSession.Advanced.UseOptimisticConcurrency = true;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var controller = actionExecutedContext.ActionContext.ControllerContext.Controller as AbstractApiController;
            if (controller == null)
                return;

            using (var session = controller.RavenSession)
            {
                if (session == null)
                    return;

                if (actionExecutedContext.Exception != null)
                {
                    session.SaveChanges();
                }
            }
        }
    }
}