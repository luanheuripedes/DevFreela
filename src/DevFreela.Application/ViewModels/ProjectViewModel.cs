using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string title, DateTime createdAt, int id)
        {
            Title = title;
            CreatedAt = createdAt;
            Id = id;
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
