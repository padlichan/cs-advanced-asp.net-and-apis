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
}
