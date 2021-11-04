using System;

namespace Tarteeb.Tasks.Core.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
