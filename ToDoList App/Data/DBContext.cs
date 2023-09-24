using Microsoft.EntityFrameworkCore;
using ToDoList_App.Models;

namespace ToDoList_App.Data
{
    public class DBContext : DbContext
    {
       //add Table
        public DbSet<Note> NotesList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filename = Path.Combine(path, "AppNotesDB.db");
            optionsBuilder.UseSqlite("FileName = "+filename);
        }
    }
}
