using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CDRecord.Data;

namespace CDRecord.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly ISong songRep;

        public IndexModel(ISong songRep)
        {
            this.songRep = songRep;
        }

        public IList<Song> Song { get;set; } = default!;

        public async Task OnGetAsync(Song song)
        {
            if (songRep != null)
            {
               Song = songRep.GetAll().ToList();
            }
        }
    }
}
