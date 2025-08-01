﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    // Concrete klasörü altında somut sınıflar bulunur.
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }

        public DateTime HeadingDate { get; set; }

        public bool HeadingStatus { get; set; }

        public int CategoryID { get; set; }
        public Category Category{ get; set; }

        public int WriterID { get; set; }
        public Writer Writer { get; set; } 

        public ICollection<Content> Contents { get; set; } // 1 - M

    }
}
