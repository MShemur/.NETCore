using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Models
{
    public class CategoryForCreationDto
    {
        [Required]
        public string Name { get; set; }
    }
}
