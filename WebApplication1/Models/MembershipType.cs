﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}