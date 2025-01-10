using Microsoft.EntityFrameworkCore;
using StripsBL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StripsDL.Models
{
    [Table("AuteurStrip", Schema = "dbo")]
    [PrimaryKey(nameof(AuteurId), nameof(StripId))]
    public class AuteurStrip
    {
        [Key]
        [Column("AuteursId", Order = 0)]
        public int AuteurId { get; set; }
        [Key]
        [Column("StripsId", Order = 1)]
        public int StripId { get; set; }

        [JsonIgnore]
        [ForeignKey("StripId")]
        public Strip Strip { get; set; }
        [JsonIgnore]
        [ForeignKey("AuteurId")]
        public Auteur Auteur { get; set; }
    }
}
