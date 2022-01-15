using DOMAIN.Common;
using DOMAIN.Models.Users;
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
        [StringLength(20)]
        public string Tel { get; set; }
        [Column("Address")]
        [StringLength(1000)]
        public string Address { get; set; }

        public void Create(UserModel userModel, string actionUser = "") 
        {
            Id = Guid.NewGuid();
            Username = userModel.Username;
            Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
            Email = userModel.Email;
            Tel = userModel.Tel;
            Address = userModel.Address;
            Created = actionUser;
            CreatedDate = DateTime.Now;
            Updated = actionUser;
            UpdatedDate = DateTime.Now;
            IsDelete = false;
        }
    }
}
