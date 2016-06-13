using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.Model
{
    [DataContract]
    public class UserModel : BaseModel
    {
        [DataMember, JsonProperty("Name")]
        public string Name { get; set; }
        [DataMember, JsonProperty("id")]
        public string Id { get; set; }
        [DataMember, JsonProperty("given_name")]
        public string GivenName { get; set; }
        [DataMember, JsonProperty("family_name")]
        public string FamilyName { get; set; }
        [DataMember, JsonProperty("role")]
        public string Role { get; set; }
        [DataMember, JsonProperty("permissions")]
        public string Permissions { get; set; }

    }
}
