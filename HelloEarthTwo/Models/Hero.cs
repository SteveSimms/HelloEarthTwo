using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEarthTwo
{
    public class Hero : HeroService
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public string Powers { get; set; }
        public string SecretId { get; set; }
        public string HomeWorld { get; set; }
        public string TeamAffiliation { get; set; }
        public string IsClone { get; set; }
        public string TimeStamp { get; set; }

        [NotMapped]
        public List<object> HeroData { get; set; } = new List<object>();// Creating an instance of a List to store all of our above information Can use this to turn our powers property to a list 

    }



}
