using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IT_department_Assienment.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string Memo { get; set; }

        // Foreign key to DeviceCategory (Many Devices to One DeviceCategory)
        [ForeignKey("DeviceCategory")]
        public int DeviceCategoryID { get; set; }
        public virtual DeviceCategories DeviceCategory { get; set; }  

        // Many-to-Many relation through DevicePropertyValues
        public virtual ICollection<DevicePropertyValue> DevicePropertyValues { get; set; }
    }
}
