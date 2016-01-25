using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CodedHomes.Web.Filters;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Validation.Providers;

namespace CodedHomes.Web
{
    public class CustomGlobalConfig
    {
        public static void Customize(HttpConfiguration config)
        {
            // fixes issues with overly-aggressive validation provider:
            //
            config.Services.RemoveAll(
                typeof(System.Web.Http.Validation.ModelValidatorProvider),
                v => v is InvalidModelValidatorProvider
            );

            // approach via @encosia
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // approach via @john_papa. ensure any json message follow this rule
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Filters.Add(new ValidationActionFilter());
        }
    }
}