using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Enums
{
    [NotMapped]
    public class Enums
    {
        public enum TestRoomStatusType : byte
        {
            [Display(Name = "Not Started")] NotStarted = 1,
            [Display(Name = "Inprogress")] Inprogress,
            [Display(Name = "Finished")] Finished
        }

        public enum PublishQuestionLevel : byte
        {
            [Display(Name = "Beginner")] Beginner = 1,
            [Display(Name = "Intermediate")] Intermediate,
            [Display(Name = "Advanced")] Advanced,
            [Display(Name = "Mixed-Level")] MixedLevel
        }

        public enum OperationType
        {
            Create = 1,
            ReadAll = 2,
            ReadById = 3,
            Update = 4,
            Delete = 5
        }

        public enum Airlines
        {
            Unknown = 0,
            BritishAirways = 1,
            VirginAtlantic = 2,
            AirFrance = 3
        }
    }
}