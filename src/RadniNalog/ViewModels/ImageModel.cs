using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ViewModels
{
    public class ImageModel
    {
        [Key]
        public int ID { get; set; }
        public int LocationID { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateAdded { get; set; }


    }
}
