using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int City { get; set; }
        public int Country { get; set; }
        public ICollection<RestaurantReview> Reviews { get; set; }

    }
}
