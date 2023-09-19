using CDRecord.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CDRecord.Pages.Songs
{
    public class CreateModel : PageModel
    {
        private readonly ISong songRep;

        public CreateModel(ISong songRep)
        {
            this.songRep = songRep;
        }

        public IActionResult OnGet(int id)
        {
            Song = new Song();
            Song.RecordId = id;
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Song song)
        {
            
          if (!ModelState.IsValid || songRep == null || Song == null)
            {
                return Page();
            }

            songRep.Add(song);

            return RedirectToPage("/Records/Details", new { id = Song.RecordId });
        }
        
    }
}
