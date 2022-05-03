using System;

namespace VanGoghAPI.Models
{
    public class Response
    {
        // Represents HTTP error code
        public int statusCode { get; set; }

        // Describes meaning of statusCode
        public string statusDescription { get; set; } 

        // Used for GET method properties for both painting and paintinginfo
        public List<Painting> paintings { get; set; }

    }
}