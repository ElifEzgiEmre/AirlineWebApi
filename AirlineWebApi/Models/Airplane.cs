using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineWebApi.Models
{
    public class Airplane
    {
        public int airplane_id { get; set; }

        public int total_number_of_seats { get; set; }

        public string airplane_models { get; set; }

        public string airplane_type { get; set; }

        public int leg_number { get; set; }

        public int flight_number { get; set; }
    }
}
