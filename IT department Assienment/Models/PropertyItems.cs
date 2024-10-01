using System.ComponentModel.DataAnnotations.Schema;

namespace IT_department_Assienment.Models
{
    public class PropertyItems
    {
        public int Id { get; set; }
        public string Description { get; set; }

        // Foreign key to DeviceCategory (One-to-Many)
        [ForeignKey("DeviceCategory")]
        public int DeviceCategoryID { get; set; }
        public virtual DeviceCategories DeviceCategory { get; set; }

        // Many-to-Many relation through DevicePropertyValues
        public virtual ICollection<DevicePropertyValue> DevicePropertyValues { get; set; }
    }
}
