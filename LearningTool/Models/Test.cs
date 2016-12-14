using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningTool.Models
{
    public class Test
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; } 

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Subject { get; set; }


        public List<QuestionAndAnswer> Questions { get; set; }
    }
}