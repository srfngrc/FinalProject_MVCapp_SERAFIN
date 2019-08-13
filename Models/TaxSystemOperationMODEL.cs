using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_MVCapp_SERAFIN.Models
{
    public class TaxSystemOperationMODEL
    {
        public int operationId { get; set; }
        public string isin { get; set; }
        public DateTime purchaseDate { get; set; }
        public DateTime sellDate { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
    }
}