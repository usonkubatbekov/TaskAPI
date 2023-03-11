using Microsoft.AspNetCore.Http;

namespace ServiceLayer.Dtos
{
    public class TaskDtofromPost : BaseIdDto
    {
        public DateTime DateTimeTask { get; set; }

        public string TaskName { get; set; }

        public string TaskStatus { get; set; }
        
        public List<IFormFile> TaskFiles { get; set; }
    }
}
