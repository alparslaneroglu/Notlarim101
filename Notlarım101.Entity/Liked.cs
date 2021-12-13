using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notlarım101.Entity
{
    [Table("tblLiked")]
    public class Liked
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Note Note { get; set; } //Notlar like edilir.
        public virtual NotlarimUser LikedUser { get; set; }

    }
}
