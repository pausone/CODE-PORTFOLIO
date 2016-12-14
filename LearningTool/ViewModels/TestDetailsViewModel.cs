using LearningTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningTool.ViewModels
{
    public class TestDetailsViewModel
    {
        public int TestId { get; set; }

        public string TestSubject { get; set;}

        public List<QuestionAndAnswer> Questions { get; set; }

    }
}