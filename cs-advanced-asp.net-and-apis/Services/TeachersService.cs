using cs_advanced_asp.net_and_apis.Models;

namespace cs_advanced_asp.net_and_apis.Services;

public class TeachersService(TeachersModel teachersModel)
{
    private readonly TeachersModel teachersModel = teachersModel;

    public Teacher? GetTeacherById(int id)
    {
        return teachersModel.GetTeacher(id);
    }

    public Teacher PostTeacher(Teacher teacher)
    {
        return teachersModel.AddTeacher(teacher);
    }
}
