using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecurityWebModule.Models
{
    public class SecurityModel
    {
        [Required]
        public int Id { get; set; }

     
        public string Description { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "SecurityCode should not be more than 15")]
        public string SecurityCode { get; set; }
        [StringLength(12, ErrorMessage = "ISIN should not be more than 12")]
        public string ISIN { get; set; }
        [StringLength(9, ErrorMessage = "Cusip should not be more than 9")]
        public string Cusip { get; set; }
        [StringLength(20, ErrorMessage = "Sedol should not be more than 20")]
        public string Sedol { get; set; }
        [StringLength(20, ErrorMessage = "RIC should not be more than 20")]
        public string RIC { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}