using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class BicyclesFilterSpecifications
    {
        public string WeightMin { get; set; }
        public string WeightMax { get; set; }
        public string PriceMin { get; set; }
        public string PriceMax { get; set; }
        public List<string> FrameSize { get; set; }
        public List<string> WheelDiametr { get; set; }
        public List<string> Color { get; set; }
        public List<string> NumberOfSpeeds { get; set; }
        public List<string> Manufacturer { get; set; }
        public Dictionary<string, int> FrameSizesAndCount { get; set;}
        public Dictionary<string, int> WheelsDiametrAndCount { get; set; }
        public Dictionary<string, int> ColorsAndCount { get; set; }
        public Dictionary<string, int> NumbersOfSpeedsAndCount { get; set; }
        public Dictionary<string, int> ManufacturersAndCount { get; set; }
        public BicyclesFilterSpecifications()
        {
            FrameSize = new List<string>();
            WheelDiametr = new List<string>();
            Color = new List<string>();
            NumberOfSpeeds = new List<string>();
            Manufacturer = new List<string>();
            FrameSizesAndCount = new Dictionary<string, int>();
            WheelsDiametrAndCount = new Dictionary<string, int>();
            ColorsAndCount = new Dictionary<string, int>();
            NumbersOfSpeedsAndCount = new Dictionary<string, int>();
            ManufacturersAndCount = new Dictionary<string, int>();
        }

    }
}
