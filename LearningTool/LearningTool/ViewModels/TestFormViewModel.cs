using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningTool.ViewModels
{
    public class TestFormViewModel
    {
        [Required]
        [StringLength(255)]
        public string Subject { get; set; }
    }
}