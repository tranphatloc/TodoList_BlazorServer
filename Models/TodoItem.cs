

using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoItem
    {
        public int id { get; set; }
        public string task { get; set; }
        public bool? status { get; set; } = false;

        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }

}
