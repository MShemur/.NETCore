using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Entities
{
    public class IncomeTransaction : TransactionBase
    {
        [ForeignKey("CategoryId")]
        public IncomeCategory Category { get; set; }
    }
}
