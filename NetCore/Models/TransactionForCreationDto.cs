﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Models
{
    public class TransactionForCreationDto
    {
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double TransactionSum { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
        public Guid CategoryId { get; set; }
    }
}
