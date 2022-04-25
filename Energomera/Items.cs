using SQLite;

namespace Notes.Model
{
    public class Items
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}