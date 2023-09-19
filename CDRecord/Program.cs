﻿using CDRecord.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CDRecord
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CDRecordContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CDRecordContext") ?? throw new InvalidOperationException("Connection string 'CDRecordContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<ISong, SongRepository>();
            builder.Services.AddTransient<IRecord, RecordRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}