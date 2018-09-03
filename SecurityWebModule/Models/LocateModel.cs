using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecurityWebModule.Models
{
    public class LocateModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(20,ErrorMessage = "Name should not be more than 20")]  
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Public/Private is Required")]
        public bool IsPublic { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}