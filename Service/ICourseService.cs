using CourseCRUD.RequestResponse;

namespace CourseCRUD.Service
{
    public interface ICourseService
    {
        Task<List<Response>> GetCourses();
        Task<Response> GetCourseById(int id);
        Task<string> AddCourse(Response Course);
        Task<string> UpdateCourse(int id, Response Course);
        Task<string> DeleteCourseById(int id);
    }
}
