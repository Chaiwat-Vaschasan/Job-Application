using DOMAIN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DOMAIN.Entities.Menus
{
    [Table("Menu")]
    public class Menu : EntityProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Group")]
        public int Group { get; set; }
        [Column("Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("Link")]
        [StringLength(120)]
        public string Link { get; set; }
        [Column("Icon")]
        [StringLength(50)]
        public string Icon { get; set; }
        [Column("Type")]
        [StringLength(50)]
        public string Type { get; set; }

    }
}
