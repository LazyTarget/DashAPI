namespace DashAPI.Models
{
    public class PageResult<T>
    {
        public T[] Result { get; set; }
        public string NextUrl { get; set; }
    }
}