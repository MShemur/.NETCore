using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Entities
{
    public abstract class TransactionBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double TransactionSum { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
        public Guid CategoryId { get; set; }
    }
}
