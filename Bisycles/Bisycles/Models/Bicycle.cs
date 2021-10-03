using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class Bicycle
    {
        public int? BicycleId { get; set; }
        public string Avatar { get; set; }
        public string BicycleTitle { get; set; }
        public decimal BicycleFrameSize { get; set; }
        public decimal BicycleWheelDiameter { get; set; }
        public string BicycleColor { get; set; }
        public int BicycleNumberOfSpeeds { get; set; }
        public string BicycleManufactureCountry { get; set; }
        public decimal BicucleWeight { get; set; }
        public decimal BicyclePrice { get; set; }
    }
}
