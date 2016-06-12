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

        [DataMember, Required]
        public string UserName { get; set; }
        [DataMember, Required]
        public string FromattedName { get; set; }


    }
}
