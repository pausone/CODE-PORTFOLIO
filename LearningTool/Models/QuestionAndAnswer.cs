using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningTool.Models
{
    public class QuestionAndAnswer
    {
        public int Id { get; set; }

        [Required]
        public int TestId { get; set; }

        [Required]
        [StringLength(255)]
        public string Question { get; set; }

        [Required]
        [StringLength(255)]
        public string Answer { get; set; }

        [StringLength(255)]
        public string Hint { get; set; }

        [StringLength(255)]
        public string Mnemonic { get; set; }
    }
}