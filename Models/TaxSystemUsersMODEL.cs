using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_MVCapp_SERAFIN.Models
{
    public class TaxSystemUsersMODEL
    {
        public int loginId { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string description { get; set; }
        public string isAdmin { get; set; }
    }
}