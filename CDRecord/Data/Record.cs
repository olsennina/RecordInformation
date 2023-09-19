using CDRecord.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace CDRecord.Data
{
    public class Record
    {
        [Display(Name = "Id")]
        public int RecordId { get; set; }
        [Display(Name = "Artist")]
        public string ArtistName { get; set; } = "";
        [Display(Name = "Album")]
        public string AlbumName { get; set; } = "";
        [Display(Name = "Release")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Company")]
        public string RecordCompany { get; set; } = "";
        public List<Song>? Song { get; set; }
    }
}

