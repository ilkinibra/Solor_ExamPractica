using Solor_BackEnd.Models;
using System.Collections.Generic;

namespace Solor_BackEnd.View_Models
{
    public class HomeVM
    {
       public IEnumerable<Slider>Sliders { get; set; }
        public About About { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
