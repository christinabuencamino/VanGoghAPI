using System;
namespace VanGoghAPI.Models
{
    public class Painting
    {
        public int PaintingId { get; set; }
        public string PaintingName { get; set; }
        public PaintingInfo PaintingInfo { get; set; }
    }
}
