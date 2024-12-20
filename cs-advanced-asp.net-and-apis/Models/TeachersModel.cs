using System.Diagnostics.Eventing.Reader;
using System.Text.Json;

namespace cs_advanced_asp.net_and_apis.Models;

public class TeachersModel
{
    public List<Teacher> GetAllTeachers()
    {
        var data = File.ReadAllText("Resources/Teachers.json");
        var teachers = JsonSerializer.Deserialize<List<Teacher>>(data);
        return teachers ?? [];
    }

    public Teacher? GetTeacher(int id)
    {
        var teachers = GetAllTeachers();
        return teachers.Where(t => t.Id == id).FirstOrDefault();
    }

    public Teacher AddTeacher(Teacher teacher)
    {
        var teachers = GetAllTeachers();
        teacher.Id = teachers.LastOrDefault()?.Id+1 ?? 1;
        teachers.Add(teacher);
        WriteData(teachers);
        return teacher;
    }

    public bool DeleteTeacher(int id)
    {
        var teachers = GetAllTeachers();
        var teacherToDelete = teachers.Where(t => t.Id == id).FirstOrDefault();
        if (teacherToDelete == null) return false;
        teachers.Remove(teacherToDelete);
        WriteData(teachers);
        return true;
    }

    private void WriteData(List<Teacher> teachers)
    {
        File.WriteAllText("Resources/Teachers.json", JsonSerializer.Serialize(teachers));
    }
}
