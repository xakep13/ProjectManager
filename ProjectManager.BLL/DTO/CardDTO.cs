namespace ProjectManager.BLL.DTO
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int TaskListId { get; set; }
        public TaskListDTO TaskList { get; set; }
    }
}