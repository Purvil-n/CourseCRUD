using Microsoft.EntityFrameworkCore;
using CourseCRUD.Context;
using CourseCRUD.Models;
using CourseCRUD.RequestResponse;

namespace CourseCRUD.Service
{
    public class CourseService : ICourseService
    {
        private readonly CourseContext _context;
        public CourseService(CourseContext context)
        {
            _context = context;
        }

        //add
        public async Task<string> AddCourse(Response course)
        {
            CourseEntity obj = new CourseEntity()
            {
                Id = course.CourseId,
                Name = course.CourseName,
                Price = course.CoursePrice,
            };
            _context.Courses.Add(obj);
            await _context.SaveChangesAsync();
            return "Added";
        }

        //get all
        public async Task<List<Response>> GetCourses()
        {
            var res = await _context.Courses.Select(item => new Response
            {
                CourseId = item.Id,
                CourseName = item.Name,
                CoursePrice = item.Price,
            }).ToListAsync();
            return res;
        }

        //get single
        public async Task<Response> GetCourseById(int id)
        {
            var res = await _context.Courses.Where(item => item.Id == id).Select(item => new Response
            {
                CourseId = item.Id,
                CourseName = item.Name,
                CoursePrice = item.Price
            }).FirstOrDefaultAsync();
            return res;
        }

        //delete
        public async Task<string> DeleteCourseById(int id)
        {
            var res = await _context.Courses.Where(item => item.Id == id).FirstOrDefaultAsync();
            if (res != null)
            {
                _context.Courses.Remove(res);
                await _context.SaveChangesAsync();
                return "Deleted";
            }
            return null;
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Course"></param>
        /// <returns></returns>
        public async Task<string> UpdateCourse(int id, Response Course)
        {
            var res = await _context.Courses.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (res != null)
            {
                res.Name = Course.CourseName;
                res.Price = Course.CoursePrice;

                //_context.Courses.AddOrUpdate(res);
                await _context.SaveChangesAsync();
                return "Updated";
            }
            return null;
        }
    }
}
