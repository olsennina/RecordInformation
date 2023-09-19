namespace CDRecord.Data
{
    public class SongRepository : ISong
    {
        private readonly CDRecordContext cDRecordContext;

        public SongRepository(CDRecordContext cDRecordContext)
        {
            this.cDRecordContext = cDRecordContext;
        }
        public void Add(Song song)
        {
            cDRecordContext.Song.Add(song);
            cDRecordContext.SaveChanges();
        }

        public void Delete(Song song)
        {
            cDRecordContext.Song.Remove(song);
            cDRecordContext.SaveChanges();
        }

        public IEnumerable<Song> GetAll()
        {
            return cDRecordContext.Song.OrderBy(s => s.SongId);
        }

        public Song GetById(int id)
        {
            return cDRecordContext.Song.FirstOrDefault(i => i.SongId == id);
        }

        public void SaveChanges()
        {
            cDRecordContext.SaveChanges();
        }

        public void Update(Song song)
        {
            cDRecordContext.Song.Update(song);
            cDRecordContext.SaveChanges();
        }
    }
}
