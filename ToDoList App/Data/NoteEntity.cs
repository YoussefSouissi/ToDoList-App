using Microsoft.EntityFrameworkCore;
using ToDoList_App.Models;

namespace ToDoList_App.Data
{
    public class NoteEntity : IDataHelper<Note>
    {
        private DBContext db;
        public NoteEntity() { 
        db = new DBContext();
        }
        public async Task AddDataAsync(Note table)
        {
            await db.NotesList.AddAsync(table);
            await db.SaveChangesAsync();
        }

        public async Task DeleteDataAsync(Note table)
        {    db.NotesList.Remove(table);
            await db.SaveChangesAsync();
        }

        public async  Task<Note> FindAsync(int Id)
        {
            return await db.NotesList.FindAsync(Id);
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await db.NotesList.ToListAsync();
        }

        public async Task UpdateDataAsync(Note table)
        {
            db = new DBContext();
            db.NotesList.Update(table); 
            await db.SaveChangesAsync();

        }
    }
}
