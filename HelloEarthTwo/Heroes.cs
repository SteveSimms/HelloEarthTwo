using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEarthTwo
{
    public class Heroes : HeroService
    {
        public string CodeName { get; set; }
        public string Powers { get; set; }
        public string SecretId { get; set; }
        public string HomeWorld { get; set; }
        public string TeamAffiliation { get; set; }
        public string IsClone { get; set; }

        /* public List<string> Powers { get; set; } = new();*/ // Can use this to turn our powers property to a list 

    }



}
