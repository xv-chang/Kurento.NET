using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurentoDemo.Infrastructure.Kurento
{
    public class KMSServerOption
    {
        public string Name { set; get; }
        public string URI { set; get; }
        public bool IsMaster { set; get; }
    }
}
