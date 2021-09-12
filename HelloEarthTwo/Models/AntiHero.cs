using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEarthTwo.Models
{
    public class AntiHero : Hero
    {

        public bool IsAntiHero { get; set; }
        [NotMapped]
        public List<object> AntiHeroData { get; set; } = new List<object>();
    }
}
