using System;
namespace VanGoghAPI.Models
{
    public class PaintingInfo
    {
        public int PaintingInfoId { get; set; }
        public int? YearFinished { get; set; }
        public bool IsPortrait { get; set; }
        public bool IsSelf { get; set; }
        public bool IsPlant { get; set; }
        public bool IsAnimal { get; set; }
        public bool IsLandscape { get; set; }
        public int PaintingId { get; set; } // Must declare FK in class as well
        public string Location { get; set; } = "Not listed.";

    }
}
