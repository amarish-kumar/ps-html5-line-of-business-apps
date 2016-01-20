using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CodedHomes.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CodedHomes.Web.ViewModels
{
    public class HomesListViewModel : ViewModelBase
    {
        public IList<Home> Homes { get; set; }
        public string HomesJSON
        {
            get {
                // lowercase properties
                JsonSerializerSettings settings = new JsonSerializerSettings();

                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                var homes = JsonConvert.SerializeObject(this.Homes, settings);
                return homes;
            }
        }

        public string ImageUrlPrefix
        {
            get { return CodedHomes.Web.Config.ImagesUrlPrefix; }
        }
    }
}