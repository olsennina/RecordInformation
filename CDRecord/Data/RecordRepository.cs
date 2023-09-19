namespace CDRecord.Data
{
    public class RecordRepository : IRecord
    {
        private readonly CDRecordContext cDRecordContext;

        public RecordRepository(CDRecordContext cDRecordContext)
        {
            this.cDRecordContext = cDRecordContext;
        }
        public void Add(Record record)
        {
            cDRecordContext.Record.Add(record);
            cDRecordContext.SaveChanges();
        }

        public void Delete(Record record)
        {
            cDRecordContext.Record.Remove(record);
            cDRecordContext.SaveChanges();
        }

        public IEnumerable<Record> GetAll()
        {
            return cDRecordContext.Record.OrderBy(s => s.ArtistName);
        }

        public Record GetById(int id)
        {
            return cDRecordContext.Record.FirstOrDefault(i => i.RecordId == id);
        }

        public void SaveChanges()
        {
            cDRecordContext.SaveChanges();
        }

        public void Update(Record record)
        {
            cDRecordContext.Record.Update(record);
            cDRecordContext.SaveChanges();
        }
    }
}
