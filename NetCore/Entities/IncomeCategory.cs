using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Entities
{
    public class IncomeCategory : CategoryBase
    {
        public List<IncomeTransaction> IncomeTransactions { get; set; } = new List<IncomeTransaction>();
    }
}
