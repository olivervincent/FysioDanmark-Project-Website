using FysioDanmark_Project_Website.Data;
using FysioDanmark_Project_Website.Interfaces;
using FysioDanmark_Project_Website.Models;

namespace FysioDanmark_Project_Website.Repositories;

public class JsonStaffRepository:IStaffRepository
{
    private string JsonStaffPath = new Paths().JsonStaffPath;
    private List<Staff> JsonStaff { get; set; }
    
    public List<Models.Staff> GetAllStaff()
    {
        return JsonFileReader.ReadJsonStaff(JsonStaffPath);
    }
    
    public void UpdateStaff(Staff staff)
    {
        if (staff != null)
        {
            JsonStaff = JsonFileReader.ReadJsonStaff(JsonStaffPath);
            DeleteStaff(staff.Id);
            JsonStaff.Add(staff);
            JsonFileWritter.WriteToJsonStaff(JsonStaff, JsonStaffPath);
        }
    }
    
    public void DeleteStaff(int Id)
    {
        JsonStaff = JsonFileReader.ReadJsonStaff(JsonStaffPath);
        JsonStaff.RemoveAll(s => s.Id == Id);
        JsonFileWritter.WriteToJsonStaff(JsonStaff, JsonStaffPath);
    }
    
    public void CreateStaff(Staff staff)
    {
        JsonStaff = JsonFileReader.ReadJsonStaff(JsonStaffPath);
        int Id = 1;
        if (JsonStaff.Any()) 
        {
            Id = JsonStaff.Max(x => x.Id) + 1;
        }
        staff.Id = Id;

        JsonStaff.Add(staff);
        JsonFileWritter.WriteToJsonStaff(JsonStaff.OrderBy(x => x.Id).ToList(), JsonStaffPath);
    }
    
    public Staff GetStaff(string name)
    {
        foreach (var item in GetAllStaffs())
        {
            if (item.Name == name)
                return item;
        }

        return new Models.Staff();
    }
    
    public List<Models.Staff> GetAllStaffs()
    {
        return JsonFileReader.ReadJsonStaff(JsonStaffPath);
    }
}