using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IOTKeyAndValues.Models.DB
{
    [Table("KeyValues")]
    public class KeyValue
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
