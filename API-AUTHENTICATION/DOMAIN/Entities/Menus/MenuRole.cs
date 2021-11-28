using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DOMAIN.Entities.Menus
{
    [Table("MenuRole")]
    public class MenuRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("RoleId")]
        public int RoleId { get; set; }
        [Column("MenuId")]
        public int MenuId { get; set; }
    }
}
