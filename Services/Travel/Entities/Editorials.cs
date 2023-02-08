using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Editorials
    {
        public Editorials()
        {
            Books = new HashSet<Books>();
        }

        public int id { get; set; }

        [StringLength(45)]
        public string name { get; set; }

        [StringLength(45)]
        public string campus { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
