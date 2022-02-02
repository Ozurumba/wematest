using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemcoBank.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

    }
}
