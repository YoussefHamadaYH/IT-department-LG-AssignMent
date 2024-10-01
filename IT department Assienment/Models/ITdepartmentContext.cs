using Microsoft.EntityFrameworkCore;

namespace IT_department_Assienment.Models
{
    public class ITdepartmentContext :DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceCategories> DeviceCategories { get; set; }
        public DbSet<DevicePropertyValue> DevicePropertyValue { get; set; }
        public DbSet<PropertyItems> PropertyItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Device Categories
            modelBuilder.Entity<DeviceCategories>().HasData(
                new DeviceCategories { Id = 1, CategoryName = "Printer" },
                new DeviceCategories { Id = 2, CategoryName = "Laptop" },
                new DeviceCategories { Id = 3, CategoryName = "Switch" }
            );

            // Seed Property Items
            modelBuilder.Entity<PropertyItems>().HasData(
                new PropertyItems { Id = 1, Description = "IP", DeviceCategoryID = 1 },  
                new PropertyItems { Id = 2, Description = "Is Color", DeviceCategoryID = 1 },  
                new PropertyItems { Id = 3, Description = "Brand", DeviceCategoryID = 1 },  

                new PropertyItems { Id = 4, Description = "Processor", DeviceCategoryID = 2 },  
                new PropertyItems { Id = 5, Description = "HD", DeviceCategoryID = 2 },  
                new PropertyItems { Id = 6, Description = "RAM", DeviceCategoryID = 2 },  
                new PropertyItems { Id = 7, Description = "Display", DeviceCategoryID = 2 },  
                new PropertyItems { Id = 8, Description = "Current User", DeviceCategoryID = 2 },  

                new PropertyItems { Id = 9, Description = "Ports", DeviceCategoryID = 3 },  
                new PropertyItems { Id = 10, Description = "Speed", DeviceCategoryID = 3 },  
                new PropertyItems { Id = 11, Description = "Brand", DeviceCategoryID = 3 }   
            );

            // Seed Devices
            modelBuilder.Entity<Device>().HasData(
                new Device
                {
                    Id = 1,
                    Name = "HP Desktop 1190",
                    AcquisitionDate = new DateTime(2014, 1, 1),
                    Memo = "Office Desktop",
                    DeviceCategoryID = 2  // Laptop
                },
                new Device
                {
                    Id = 2,
                    Name = "Canon Printer 3000",
                    AcquisitionDate = new DateTime(2018, 2, 15),
                    Memo = "Color Printer",
                    DeviceCategoryID = 1  // Printer
                },
                new Device
                {
                    Id = 3,
                    Name = "Cisco Switch 2960",
                    AcquisitionDate = new DateTime(2020, 5, 30),
                    Memo = "Network Switch",
                    DeviceCategoryID = 3  // Switch
                }
            );

            // Seed Device Property Values
            modelBuilder.Entity<DevicePropertyValue>().HasData(
                new DevicePropertyValue
                {
                    Id = 1,
                    DeviceID = 1,  // HP Desktop
                    PropertyItemID = 4,  // Processor
                    PropertyValue = "Core i7"
                },
                new DevicePropertyValue
                {
                    Id = 2,
                    DeviceID = 1,  // HP Desktop
                    PropertyItemID = 1,  // IP
                    PropertyValue = "192.168.1.5"
                },
                new DevicePropertyValue
                {
                    Id = 3,
                    DeviceID = 2,  // Canon Printer
                    PropertyItemID = 1,  // IP
                    PropertyValue = "192.168.1.10"
                },
                new DevicePropertyValue
                {
                    Id = 4,
                    DeviceID = 2,  // Canon Printer
                    PropertyItemID = 2,  // Is Color
                    PropertyValue = "Yes"
                },
                new DevicePropertyValue
                {
                    Id = 5,
                    DeviceID = 3,  // Cisco Switch
                    PropertyItemID = 9,  // Ports
                    PropertyValue = "24"
                },
                new DevicePropertyValue
                {
                    Id = 6,
                    DeviceID = 3,  // Cisco Switch
                    PropertyItemID = 10,  // Speed
                    PropertyValue = "1G"
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        public ITdepartmentContext(DbContextOptions<ITdepartmentContext> options) : base(options)
        {

        }
        public ITdepartmentContext() : base()
        { }

    }
}
