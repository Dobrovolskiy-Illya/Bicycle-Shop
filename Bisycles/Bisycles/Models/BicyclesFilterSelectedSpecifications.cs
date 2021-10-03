using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class BicyclesFilterSelectedSpecifications
    {
        public List<string> AllFrameSize { get; set; }
        public List<string> AllWheelDiameter { get; set; }
        public List<string> AllColor { get; set; }
        public List<string> AllNumberOfSpeeds { get; set; }
        public List<string> AllManufactureCountry { get; set; }
        public decimal WeightMin { get; set; }
        public decimal WeightMax { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public List<Bicycle> Bicycles { get; set; }
        public List<Bicycle> AllBicycles { get; set; }
        public int CountOfSpecifications { get; set; }

        public BicyclesFilterSelectedSpecifications()
        {
            AllFrameSize = new List<string>();
            AllWheelDiameter = new List<string>();
            AllColor = new List<string>();
            AllNumberOfSpeeds = new List<string>();
            AllManufactureCountry = new List<string>();
            Bicycles = new List<Bicycle>();
            AllBicycles = new List<Bicycle>();
        }
    }
}
