namespace CDRecord.Data
{
    public interface IRecord
    {
        Record GetById(int id);
        IEnumerable<Record> GetAll();
        void Add(Record record);
        void Update(Record record);
        void Delete(Record record);
        void SaveChanges();
    }
}

