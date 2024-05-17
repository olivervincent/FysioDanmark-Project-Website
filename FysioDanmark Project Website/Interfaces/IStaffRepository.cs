using FysioDanmark_Project_Website.Models;

namespace FysioDanmark_Project_Website.Interfaces;

public interface IStaffRepository
{
    List<Models.Staff> GetAllStaff();
    void DeleteStaff(int Id);
    void CreateStaff(Staff staff);
    Staff GetStaff(string name);
    void UpdateStaff(Staff staff);
}