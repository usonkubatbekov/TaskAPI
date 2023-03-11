namespace DataLayer.Entities
{
    public class FilesPath : ID
    {
        public string FilePath { get; set; }

        public int TaskId { get; set; }

        public TaskEntity TaskEntity { get; set; }
    }
}
