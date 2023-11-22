using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public enum ActionName
    {
        Cut, 
        CutLeft,
        CutRight,
        Merge,
        ConvertToNumeric
    }

    public enum ActionType
    {
        Editing,
        Merging,
        Converting
    }

    public class ActionModel
    {
        [Key]
        public int actionId { get; set; }
        [Required]
        public ActionName actionName { get; set; }
        [Required]
        public string productPropertyName { get; set; } = string.Empty;


        public string actionData1 { get; set; } = string.Empty;
        public string actionData2 { get; set;} = string.Empty;

    }
}
