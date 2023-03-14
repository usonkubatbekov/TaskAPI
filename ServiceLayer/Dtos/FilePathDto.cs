

namespace ServiceLayer.Dtos
{
    public class FilePathDto : BaseIdDto
    {
        public string? FilePath { get; set; }

        public int TaskId { get; set; }

        public TaskfromPostDto TaskFromPostDto { get; set; }
    }
}
