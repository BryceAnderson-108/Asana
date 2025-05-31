using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana.Library.Models
{
    public class ToDo
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }
        public bool? IsCompleted { get; set; }

        public int Id { get; set; }
        public int ProjectId { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Description}";
        }
    }
    
    public class Project
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        
        public double CompletePercent { get; set; }
        public int Id { get; set; }

        public int projToDos { get; set; }
        
        public override string ToString()
        {
            return $"[{Id}] [{CompletePercent}] {Name} - {Description}";
        }
    }
}
