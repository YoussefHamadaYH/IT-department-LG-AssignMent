using IT_department_Assienment.Models;

namespace IT_department_Assienment.View_Models
{
    public class DeviceVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string Memo { get; set; }
        public virtual DeviceCategories ?DeviceCategory { get; set; }
        public virtual ICollection<DevicePropertyValue> DevicePropertyValues { get; set; }
    }
}
