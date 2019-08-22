using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_MVCapp_SERAFIN.Models
{
    public class TaxSystemOperatMODEL
    {
        public int operationId { get; set; }
        public string isin { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime purchaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime sellDate { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
    }
}