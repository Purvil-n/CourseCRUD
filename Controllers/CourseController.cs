using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseCRUD.RequestResponse;
using CourseCRUD.Service;

namespace CourseCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _repository;
        public CourseController(ICourseService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("getcourses")]
        public async Task<IActionResult> GetCourses()
        {
            var res = await _repository.GetCourses();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("getcoursebyid")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var res = await _repository.GetCourseById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("addcourse")]
        public async Task<IActionResult> AddCourse(Response course)
        {
            var res = await _repository.AddCourse(course);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPut]
        [Route("updatecourse")]
        public async Task<IActionResult> UpdateCourse(int id, Response course)
        {
            var res = await _repository.UpdateCourse(id, course);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route("deletecoursebyid")]

        public async Task<IActionResult> DeleteCourseById(int id)
        {
            var res = await _repository.DeleteCourseById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
