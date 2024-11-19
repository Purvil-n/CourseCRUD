namespace CourseCRUD.RequestResponse
{
    public class Response
    {
        public int CourseId { get; set; } = 0; //same fieldname as CourseEntity or different like this
        public string CourseName { get; set; } = string.Empty;
        public int CoursePrice { get; set; } = 0;
    }
}
