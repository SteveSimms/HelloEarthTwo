using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEarthTwo.Models
{
    public class Villain : Hero
    {
        public new int Id { get; set; }
        public new string CodeName { get; set; }
        public new string Powers { get; set; }
        public new string SecretId { get; set; }
        public new string HomeWorld { get; set; }
        public new string TeamAffiliation { get; set; }
        public new string IsClone { get; set; }
        public new string TimeStamp { get; set; }

        [NotMapped]
        public List<object> VillainData { get; set; } = new List<object>();


    }
}
