namespace IT_department_Assienment.Models
{
    public class DeviceCategories
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // One-to-Many relationship with PropertyItem
        public virtual ICollection<PropertyItems> PropertyItems { get; set; }

        // One-to-Many relationship with Device
        public virtual ICollection<Device> Devices { get; set; }
    }
}
