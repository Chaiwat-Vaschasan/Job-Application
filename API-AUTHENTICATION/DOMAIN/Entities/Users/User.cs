using DOMAIN.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Entities.Users
{
    [Table("User")]
    public class User : EntityProperties
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("Username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Column("Password")]
        [StringLength(300)]
        public string Password { get; set; }
        [Column("Email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("Tel")]
        [StringLength(12)]
        public string Tel { get; set; }
        [Column("Address")]
        [StringLength(1000)]
        public string Address { get; set; }
        [Column("RoleId")]
        public int RoleId { get; set; }
    }
}
