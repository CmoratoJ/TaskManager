namespace TaskManager.Entities
{
    public class EntityTasks
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public DateTime DateScheduleInitial { get; set; }
        public DateTime DateScheduleFinal { get; set; }
        public string Description { get; set; }
        public string ServiceTime { get; set; } 
    }
}
