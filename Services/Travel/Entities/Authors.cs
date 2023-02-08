﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Fields of class Authors
    /// </summary>
    public partial class Authors
    {
        public Authors()
        {
            Books = new HashSet<Books>();
        }

        /// <summary>
        /// Identification Author
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Name Author
        /// </summary>
        [StringLength(45)]
        public string name { get; set; }

        /// <summary>
        /// Surnames Author
        /// </summary>
        [StringLength(45)]
        public string surnames { get; set; }

        /// <summary>
        /// List Books Authors
        /// </summary>
        public virtual ICollection<Books> Books { get; set; }
    }
}
