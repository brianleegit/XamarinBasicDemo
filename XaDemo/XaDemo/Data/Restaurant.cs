using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace XaDemo.Data
{
    class Restaurant
    {
        public string Id;
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; private set; }
        [JsonProperty(PropertyName = "Location")]
        public string Location { get; private set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; private set; }
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; private set; }

       

        public Restaurant(string name, string location, string description, string type = "")
        {
            Name = name;
            Location = location;
            Description = description;
            Type = type;
        }
    }
}
