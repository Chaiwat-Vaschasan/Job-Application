using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DOMAIN.Common
{
    public class EntityProperties
    {
        [Column("IsDelete")]
        public bool IsDelete { get; set; }
        [Column("Created")]
        [StringLength(100)]
        public string Created { get; set; }
        [Column("Updated")]
        [StringLength(100)]
        public string Updated { get; set; }
        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }
        [Column("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
    }
}
