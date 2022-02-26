namespace TodoApp.Core.DTOs
{
    public class WorkUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
        public string UserId { get; set; }
    }
}
