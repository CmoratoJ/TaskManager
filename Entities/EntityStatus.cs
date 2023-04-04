namespace TaskManager.Entities
{
    public class EntityStatus
    {
        public EntityStatus(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
