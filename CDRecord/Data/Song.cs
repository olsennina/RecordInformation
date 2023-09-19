using System.ComponentModel.DataAnnotations;

namespace CDRecord.Data
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        [Display(Name = "Id")]
        public int RecordId { get; set; }
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public TimeSpan Length { get; set; }
        [Required]
        public string Author { get; set; } = "";
    }
}
