using CDRecord.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CDRecord.Pages.Songs
{
    public class DetailsModel : PageModel
    {
        private readonly ISong songRep;

        public DetailsModel( ISong songRep)
        {
            this.songRep = songRep;
        }

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
    }
}
