﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notlarım101.Entity
{
    [Table("tblNotlarimUsers")]
    public class NotlarimUser : MyEntityBase
    {
       [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Surname { get; set; }
        [StringLength(30),Required]
        public string Username { get; set; }
        [StringLength(100),Required]
        public string Email { get; set; }
        [StringLength(100),Required]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public Guid ActivateGuid { get; set; }
        public bool IsAdmin { get; set; }

        public List<Note> Notes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Liked> Likes { get; set; }


    }
}
