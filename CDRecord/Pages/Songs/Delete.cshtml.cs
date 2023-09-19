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
    public class DeleteModel : PageModel
    {
        private readonly ISong songRep;

        public DeleteModel(ISong songRep)
        {
            this.songRep = songRep;
        }

        [BindProperty]
        public Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || songRep == null)
            {
                return NotFound();
            }

            var song = songRep.GetById(id);

            if (song == null)
            {
                return NotFound();
            }
            else
            {
                Song = song;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || songRep == null)
            {
                return NotFound();
            }
            var song = songRep.GetById(id);

            if (song != null)
            {
                Song = song;
                songRep.Delete(song);

            }
            return RedirectToPage("/Records/Details", new { id = Song.RecordId });
        }
    }
}
