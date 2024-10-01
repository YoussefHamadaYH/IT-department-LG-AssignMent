using IT_department_Assienment.IRepository;
using IT_department_Assienment.Models;
using IT_department_Assienment.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class DeviceController : Controller
{
    private readonly IGenericRepository<Device> deviceRepository;
    private readonly IGenericRepository<DevicePropertyValue> devicePropertyRepo;
    private readonly IGenericRepository<DeviceCategories> deviceCategoriesRepository;
    public DeviceController(IGenericRepository<Device> deviceRepository, IGenericRepository<DevicePropertyValue> devicePropertyRepo, IGenericRepository<DeviceCategories> deviceCategoriesRepository)
    {
        this.devicePropertyRepo = devicePropertyRepo;
        this.deviceRepository = deviceRepository;
        this.deviceCategoriesRepository = deviceCategoriesRepository;
    }

    public IActionResult GetAllDevices()
    {
        var devices = deviceRepository.GetAll();
        return View("GetAllDevices", devices);
    }

    public IActionResult Details(int id)
    {
        var device = deviceRepository.GetById(id);
        return View("Details", device);
    }

    public IActionResult Delete(int id)
    {
        var device = deviceRepository.GetById(id);
        if (device != null)
        {
            deviceRepository.DeleteById(id);
            deviceRepository.SaveChanges();
        }
        return RedirectToAction("GetAllDevices");
    }

    [HttpGet]
    public IActionResult Add()
    {
        // Device Categories for dropdown
        ViewBag.DeviceCategoryID = new SelectList(deviceCategoriesRepository.GetAll(), "Id", "CategoryName");

        DeviceVM deviceVM = new DeviceVM
        {
            DevicePropertyValues = devicePropertyRepo.GetAll().ToList()
        };
        return View("Add", deviceVM);
    }


    [HttpPost]
    public IActionResult SaveAdd(DeviceVM deviceVM)
    {
        if (ModelState.IsValid)
        {
            Device device = new Device
            {
                Name = deviceVM.Name,
                AcquisitionDate = deviceVM.AcquisitionDate,
                Memo = deviceVM.Memo,
                DeviceCategory = deviceVM.DeviceCategory,
                DevicePropertyValues = deviceVM.DevicePropertyValues.Select(v => new DevicePropertyValue
                {
                    PropertyValue = v.PropertyValue
                }).ToList()
            };
            deviceRepository.Add(device);
            deviceRepository.SaveChanges();
            return RedirectToAction("GetAllDevices");
        }
        return View("Add", deviceVM);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var device = deviceRepository.GetById(id);
        if (device == null)
        {
            return NotFound();
        }

        // Device Categories for dropdown
        ViewBag.DeviceCategory = new SelectList(deviceCategoriesRepository.GetAll(), "Id", "CategoryName", device.DeviceCategory.Id);

        DeviceVM deviceVM = new DeviceVM
        {
            Id = device.Id,
            Name = device.Name,
            AcquisitionDate = device.AcquisitionDate,
            Memo = device.Memo,
            DeviceCategory = device.DeviceCategory,
            DevicePropertyValues = devicePropertyRepo.GetAll().ToList()
        };

        return View(deviceVM);
    }


    [HttpPost]
    public IActionResult SaveEdit(DeviceVM deviceVM)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit", deviceVM);
        }

        var device = deviceRepository.GetById(deviceVM.Id);
        if (device == null)
        {
            return NotFound();
        }
        device.Name = deviceVM.Name;
        device.AcquisitionDate = deviceVM.AcquisitionDate;
        device.Memo = deviceVM.Memo;
        device.DeviceCategory = deviceVM.DeviceCategory;
        device.DevicePropertyValues = deviceVM.DevicePropertyValues
            .Select(pv => new DevicePropertyValue
            {
                Id = pv.Id,
                PropertyValue = pv.PropertyValue
            }).ToList();

        deviceRepository.Update(device);
        deviceRepository.SaveChanges();

        return RedirectToAction("GetAllDevices");
    }
}
