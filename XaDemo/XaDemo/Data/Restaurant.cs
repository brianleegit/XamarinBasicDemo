using System;
using System.Collections.Generic;
using System.Text;

namespace XaDemo.Data
{
    class Restaurant
    {
        public string Name { get; private set; }
        public string Location { get; private set; }
        public string Description { get; private set; }
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
