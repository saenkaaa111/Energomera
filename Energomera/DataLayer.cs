using Notes.Model;
using SQLite;

namespace Notes.Data
{
    public class DataLayer
    {
        readonly SQLiteConnection database;
        private const string _connection = "Data Source = (local); Database=Energomera; Integrated Security=True;";

        public DataLayer()
        {
            database = new SQLiteConnection(_connection);
            database.CreateTable<Items>();
        }

        public List<Items> GetItems() 
        {
            return database.Table<Items>().ToList();
        }

        public Items GetItem(int id)
        {
            return database.Table<Items>()
                            .Where(i => i.Id == id)
                            .FirstOrDefault();
        }

        public void CreateItem(Items note) => database.Insert(note);         

        public void UpdateItem(Items note) => database.InsertOrReplace(note);      
                
        public void DeleteItem(int id) => database.Delete(GetItem(id));
        
    }
}