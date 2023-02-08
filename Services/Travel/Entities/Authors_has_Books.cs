using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Authors_has_Books
    {
        [Key]
        public int authors_id { get; set; }
        [Key]
        public long books_ISBN { get; set; }
    }
}
