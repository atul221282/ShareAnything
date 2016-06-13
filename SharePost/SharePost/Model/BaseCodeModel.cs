using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePost.Model
{
    public abstract class BaseCodeModel : BaseModel
    {
        public int SortOrder { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
