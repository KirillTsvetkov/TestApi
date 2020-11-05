using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public partial class Topics
    {
        public Topics()
        {
            Mssg = new HashSet<Mssg>();
        }

        public int TopicsId { get; set; }
        public string TopicsTitle { get; set; }

        public virtual ICollection<Mssg> Mssg { get; set; }
    }
}
