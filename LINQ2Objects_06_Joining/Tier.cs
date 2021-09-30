using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2Objects_06_Joining
{
    public class Tier
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(OwnerId)}={OwnerId.ToString()}}}";
        }
    }
}
