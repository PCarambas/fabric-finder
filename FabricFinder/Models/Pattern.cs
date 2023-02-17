using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using FabricFinder.Models;

namespace FabricFinder.Models
{
    public class Pattern
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public string ImageUrl { get; set; }

        public int UserId { get; set; }
        public UserProfile UserProfile { get; set; }


    }
}
