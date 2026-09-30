using System.ComponentModel.DataAnnotations;

namespace Matemaatika_Funktsioonid.Models
{
    public class FunktsiooniUurimine
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Valem on kohustuslik")]
        [Display(Name = "Funktsiooni valem")]
        public string Valem { get; set; } = string.Empty;              // nt "x^3 - 3*x"

        [Display(Name = "Määramispiirkond")]
        public string Maaramispiirkond { get; set; } = string.Empty;   // X: (-inf, inf)

        [Display(Name = "Tuletis")]
        public string Tuletis { get; set; } = string.Empty;            // f'(x): 3*x^2 - 3

        [Display(Name = "Kriitilised punktid")]
        public string KriitilisedPunktid { get; set; } = string.Empty; // x1 = -1, x2 = 1

        [Display(Name = "Ekstreemumid")]
        public string Ekstreemumid { get; set; } = string.Empty;       // max = 2, min = -2

        public DateTime LuodudAeg { get; set; } = DateTime.UtcNow;
    }
}
