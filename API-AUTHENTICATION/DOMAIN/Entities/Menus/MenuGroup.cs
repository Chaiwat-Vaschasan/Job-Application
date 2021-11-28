using DOMAIN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DOMAIN.Entities.Menus
{
    [Table("MenuGroup")]
    public class MenuGroup : EntityProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
