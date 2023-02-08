using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Books
    {
        [NotMapped]
        public string nameAuthor { get; set; }
        [NotMapped]
        public string surnamesAuthor { get; set; }

    }
}
