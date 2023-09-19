using CDRecord.Data;
using Microsoft.AspNetCore.Mvc;

namespace CDRecord.Components
{
    public class SongListViewComponent: ViewComponent
    {
        private readonly ISong songRepo;
        private readonly IRecord recordRepo;

        public SongListViewComponent(ISong songRepo, IRecord recordRepo)
        {
            this.songRepo = songRepo;
            this.recordRepo = recordRepo;
        }
        public IViewComponentResult Invoke(int recordid)
        {
            var item = songRepo.GetAll().Where(x=>x.RecordId==recordid);
            
           
            return View(item.ToList());
        }
    }
}
