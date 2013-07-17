using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Serialization;

namespace Atsumeru.Extensions
{
    public static class HtmlHelperExtensions
    {
        private static readonly JsonSerializerSettings JsonSettings;

        static HtmlHelperExtensions()
        {
            JsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new DefaultContractResolver()
            };
        }

        public static IHtmlString RawHtml(this HtmlHelper helper, string value)
        {
            return helper == null ? new HtmlString(value) : helper.Raw(value);
        }

        public static IHtmlString RenderAsJson(this HtmlHelper helper, object value)
        {
            return helper.Raw(JsonConvert.SerializeObject(value, JsonSettings));
        }

        public static IHtmlString RenderIfTrue(this HtmlHelper helper, bool statement, string valueToRender)
        {
            if (statement)
            {
                return helper.Raw(valueToRender);
            }
            return helper.Raw(string.Empty);
        }
    }
}