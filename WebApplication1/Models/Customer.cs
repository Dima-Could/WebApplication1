using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string  FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }

    }
}