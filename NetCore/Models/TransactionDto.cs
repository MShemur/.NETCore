using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCore.Entities;

namespace NetCore.Models
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public double TransactionSum { get; set; }
        public string Comment { get; set; }
        public  string CategoryName { get; set; }
    }
}
