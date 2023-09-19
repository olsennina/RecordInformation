using CDRecord.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CDRecord.Pages.Records
{
    public class DetailsModel : PageModel
    {
        private readonly IRecord recordRep;

        public DetailsModel(IRecord recordRep)
        {
            
            this.recordRep = recordRep;
        }

      public Record Record { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (recordRep == null)
            {
                return NotFound();
            }

            var record = recordRep.GetById(id);
            if (record == null)
            {
                return NotFound();
            }
            else 
            {
                Record = record;
            }
            return Page();
        }
    }
}
