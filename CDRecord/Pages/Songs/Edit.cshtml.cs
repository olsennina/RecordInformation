using CDRecord.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CDRecord.Pages.Songs
{
    public class EditModel : PageModel
    {
        private readonly ISong songRep;

        public EditModel( ISong songRep)
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

            var song =  songRep.GetById(id);
            if (song == null)
            {
                return NotFound();
            }
            Song = song;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                songRep.Update(Song);
                songRep.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(Song.SongId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Records/Index", new { id = Song.RecordId });
        }

        private bool SongExists(int id)
        {
          return songRep.GetById(id)!= null;
        }
    }
}
