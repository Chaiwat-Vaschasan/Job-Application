using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Entities.Users
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("UserId")]
        public Guid UserId { get; set; }
        [Column("RoleId")]
        public int RoleId { get; set; }

        public UserRole() { }

        public UserRole(Guid userId, int roleId) 
        {
            this.UserId = userId;
            this.RoleId = roleId;
        }
    }
}
