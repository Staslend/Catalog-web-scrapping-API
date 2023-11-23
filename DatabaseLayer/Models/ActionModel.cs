using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public enum ActionName
    {
        Cut, 
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

        //TODO: Shoul it be nullable?
        public List<ActionDataModel>? actionData { get; set; }
    }
}
