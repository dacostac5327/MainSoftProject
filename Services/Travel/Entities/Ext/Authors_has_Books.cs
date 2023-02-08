using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Additional fields of the class Authors_has_Books
    /// </summary>
    public partial class Authors_has_Books
    {
        /// <summary>
        /// Name of Author
        /// </summary>
        [NotMapped]
        public string nameAuthor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public string surnamesAuthor { get; set; }
        [NotMapped]
        public string title { get; set; }
        [NotMapped]
        public string synopsis { get; set; }
        [NotMapped]
        public string n_pages { get; set; }
    }
}
