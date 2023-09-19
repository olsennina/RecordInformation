﻿namespace CDRecord.Data
{
    public interface ISong
    {
        Song GetById(int id);
        IEnumerable<Song> GetAll();
        void Add(Song song);
        void Update(Song song);
        void Delete(Song song);
        void SaveChanges();
    }
}

