using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebApplication1.Enums.Enums;

namespace WebApplication1.Models
{
    [NotMapped]
    public class StudentModel
    {
        public int StudentId { get; set; }

        [Display(Name = "Student Name ")]
        public string Name { get; set; }

        [Display(Name= "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public OperationType OperationType { get; set; }
        public PublishQuestionLevel PublishQuestionLevel { get; set; }
        public TestRoomStatusType TestRoomStatusType { get; set; }
        public Airlines Airlines { get; set; }
    }
}