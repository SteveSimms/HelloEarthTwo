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

        public bool IsVillian { get; set; }
        [NotMapped]
        public List<object> VillainData { get; set; } = new List<object>();


    }
}
