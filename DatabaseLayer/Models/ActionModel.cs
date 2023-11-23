using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    //Name of action that represent requested task
    public enum ActionName
    {
        Cut, 
        Merge,
        ConvertToNumeric
    }

    //Types of action that folow each other in the order 
    //TODO: Replace this system with customisable priorities
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

        public List<ActionDataModel>? actionData { get; set; }
    }
}
