using System.ComponentModel.DataAnnotations;

namespace MHDecora.Site.Domain.Entities
{
    public class MidiaSocial
    {
        [Key]
        public int Id { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string WhatsApp { get; set; }
        public string? GoogleAnalytics { get; set; }
        public string? GoogleAds { get; set; }
        public string? Meta { get; set; }
    }
}
