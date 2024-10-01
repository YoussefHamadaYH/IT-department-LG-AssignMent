using System.ComponentModel.DataAnnotations.Schema;

namespace IT_department_Assienment.Models
{
    public class DevicePropertyValue
    {
        public int Id { get; set; }

        // Foreign key to Device (Many-to-One)
        [ForeignKey("Device")]
        public int DeviceID { get; set; }
        public virtual Device Device { get; set; }

        // Foreign key to PropertyItem (Many-to-One)
        [ForeignKey("PropertyItems")]  
        public int PropertyItemID { get; set; }
        public virtual PropertyItems PropertyItems { get; set; }

        // value for the property (e.g., "Core i7" for Processor)
        public string PropertyValue { get; set; }
    }
}
