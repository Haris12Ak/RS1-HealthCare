using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Uputnica
    {
        [Key]
        public int Id { get; set; }
        public string Odjeljenje { get; set; }
        public string Dijagnoza { get; set; }
        public string Primjedba { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public DateTime DatumVazenja { get; set; }

        [ForeignKey(nameof(PacijentId))]
        public Pacijent Pacijent { get; set; }
        public string PacijentId { get; set; }

        [ForeignKey(nameof(LjekarId))]
        public Ljekar Ljekar { get; set; }
        public string LjekarId { get; set; }
    }
}
