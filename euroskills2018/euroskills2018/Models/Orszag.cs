using System.ComponentModel.DataAnnotations;

namespace euroskills2018.Models
{
    public class Orszag
    {
        [Key]
        public int Id { get; set; }
        public string SzakmaNev { get; set; }
        public ICollection<Versenyzo> Versenyzok { get; set; }
    }
}
