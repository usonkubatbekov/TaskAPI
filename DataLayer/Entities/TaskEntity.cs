

namespace DataLayer.Entities
{
    public class TaskEntity : ID
    {
        public DateTime DateTimeTask { get; set; }

        public string TaskName { get; set; }

        public string TaskStatus { get; set; }

        public List<FilesPath> FilesPaths { get; set; } = new List<FilesPath>();

    }
}