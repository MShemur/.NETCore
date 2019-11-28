using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Models
{
    public class TransactionForUpdateDto
    {
        public DateTime DateTime { get; set; }
        public double TransactionSum { get; set; }
        public string Comment { get; set; }
        public Guid CategoryId { get; set; }
    }
}
