using CDRecord.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CDRecord.Pages.Records
{
    public class CreateModel : PageModel
    {
        private readonly IRecord recordRep;

        public CreateModel(IRecord recordRep)
        {
            this.recordRep = recordRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Record Record { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Record record)
        {
          if (!ModelState.IsValid || recordRep == null || Record == null)
            {
                return Page();
            }

            recordRep.Add(record);

            return RedirectToPage("./Index");
           
        }
    }
}
