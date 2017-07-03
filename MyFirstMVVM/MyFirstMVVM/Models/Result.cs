using System.Collections.Generic;

namespace MyFirstMVVM.Models
{
    public class Result<T>
    {
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int TotalResults { get; set; }
        public IEnumerable<T> Data { get; set; }
        public string Status { get; set; }
    }
}
