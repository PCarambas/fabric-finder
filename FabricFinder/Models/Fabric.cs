using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using FabricFinder.Models;


namespace FabricFinder.Models
{
    public class Fabric
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        public double Yardage { get; set; }

        public string ImageUrl { get; set; }

        public int UserId { get; set; }

        public int FabricTypeId { get; set; }
        public UserProfile UserProfile { get; set; }

    }
}
      
