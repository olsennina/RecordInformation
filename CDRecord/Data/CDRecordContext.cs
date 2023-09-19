using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CDRecord.Data;

    public class CDRecordContext : DbContext
    {
        public CDRecordContext (DbContextOptions<CDRecordContext> options)
            : base(options)
        {
        }

        public DbSet<CDRecord.Data.Song> Song { get; set; } = default!;

        public DbSet<CDRecord.Data.Record> Record { get; set; } = default!;
    }
