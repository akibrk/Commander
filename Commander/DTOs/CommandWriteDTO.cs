using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.DTOs
{
    public class CommandWriteDTO
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
