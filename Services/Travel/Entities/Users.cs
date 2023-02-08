using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Users
    {
        [Key]
        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(150)]
        public string password { get; set; }
    }
}
