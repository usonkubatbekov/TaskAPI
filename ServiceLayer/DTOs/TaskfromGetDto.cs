namespace ServiceLayer.Dtos
{
    public class TaskfromGetDto : BaseIdDto
    {
        public DateTime DateTimeTask { get; set; }

        public string TaskName { get; set; }

        public string TaskStatus { get; set; }

        public List<string> FilePath { get; set; }

    }
}
