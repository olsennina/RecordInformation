using CDRecord.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CDRecord.Pages.Records
{
    public class DeleteModel : PageModel
    {
        private readonly IRecord recordRep;

        public DeleteModel(IRecord recordRep)
        {
            this.recordRep = recordRep;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (recordRep == null)
            {
                return NotFound();
            }
            var record = recordRep.GetById(id);

            if (record != null)
            {
                Record = record;
                recordRep.Delete(record);
            }

            return RedirectToPage("./Index");
        }
    }
}
