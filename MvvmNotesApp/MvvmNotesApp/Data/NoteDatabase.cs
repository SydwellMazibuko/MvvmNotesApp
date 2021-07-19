using MvvmNotesApp.Models;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MvvmNotesApp.Data
{
    public class NoteDatabase
    {
        /*
         * This class contains code to create the database, read data from it, 
         * write data to it, and delete data from it.
         */

        readonly SQLiteAsyncConnection _database;

        // Constructor takes the path of the database file as an argument
        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
        }

        // Get all notes
        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().OrderByDescending(d => d.Date).ToListAsync();
        }

        internal Task<IEnumerable> LoadNotes()
        {
            throw new NotImplementedException();
        }

        // Get a specific note
        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        // Save a note
        public Task<int> SaveNoteAsync(Note note)
        {
            // if note id exists
            if (note.ID != 0)
            {
                // Update an existing note.
                return _database.UpdateAsync(note);
            }
            else
            {
                // Save a new note
                return _database.InsertAsync(note);
            }
        }

        // Delete a note.
        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
