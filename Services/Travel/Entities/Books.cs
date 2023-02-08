using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Books
    {
        public Books()
        {
            Authors = new HashSet<Authors>();
        }

        [Key]
        public long ISBN { get; set; }

        public int? editorials_id { get; set; }

        [StringLength(45)]
        public string title { get; set; }

        public string synopsis { get; set; }

        [StringLength(45)]
        public string n_pages { get; set; }

        public virtual Editorials Editorials { get; set; }

        public virtual ICollection<Authors> Authors { get; set; }
    }
}
