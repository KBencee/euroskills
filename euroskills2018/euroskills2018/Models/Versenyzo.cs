using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace euroskills2018.Models
{
    public class Versenyzo
    {
        [Key]
        public int Id { get; set; }
        public string Nev { get; set; }
        public int SzakmaId { get; set; }
        public int OrszagId { get; set; }
        public int Pont {  get; set; }

        [ForeignKey(nameof(SzakmaId))]
        [JsonIgnore]
        public Szakma? Szakma { get; set; }

        [ForeignKey(nameof(Orszag))]
        [JsonIgnore]
        public Orszag? Orszag { get; set; }
    }
}
