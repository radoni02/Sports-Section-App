using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Keycloak
{
    internal sealed class GroupRepresentation
    {
        public GroupRepresentation(string name)
        {
            Name = name;
        }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
