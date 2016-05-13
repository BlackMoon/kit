﻿using System;
using System.Threading.Tasks;
using Kit.Kernel.Web.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;

namespace Kit.Kernel.Web.Mvc
{
    /// <summary>
    /// Для Internet Explorer 8 заменяет contentType = text/html вместо application/json
    /// <para/>IE8 prompts to open or save json result from server
    /// </summary>
    public class JsonResultIe : JsonResult
    {
        public JsonResultIe(object value) : base(value)
        {
        }
        
        public override void ExecuteResult(ActionContext context)
        {
            if (context.HttpContext.Request.IsIe8())
                ContentType = new MediaTypeHeaderValue("text/html");

            base.ExecuteResult(context);
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (context.HttpContext.Request.IsIe8())
                ContentType = new MediaTypeHeaderValue("text/html");

            return base.ExecuteResultAsync(context);
        }
    }
}
