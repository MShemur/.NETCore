using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Entities
{
    public class OutcomeCategory : CategoryBase
    {
        public List<OutcomeTransaction> IncomeTransactions { get; set; } = new List<OutcomeTransaction>();

    }
}
