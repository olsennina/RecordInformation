using CDRecord.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CDRecord.Pages.Records
{
    public class IndexModel : PageModel
    {
        private readonly IRecord recordRep;

        public IndexModel(IRecord recordRep)
        {
            this.recordRep = recordRep;
        }

        public IList<Record> Record { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (recordRep != null)
            {
                Record = recordRep.GetAll().ToList();
            }
        }
    }
}
