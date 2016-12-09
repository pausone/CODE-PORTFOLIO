using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningTool.ViewModels
{
    public class QnAFormViewModel
    {
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