using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public partial class Contacts
    {
        public Contacts()
        {
            Mssg = new HashSet<Mssg>();
        }

        public int ContaccsId { get; set; }
        public string ContactsName { get; set; }
        public string ContactsTel { get; set; }
        public string ContactsEmail { get; set; }

        public virtual ICollection<Mssg> Mssg { get; set; }
    }
}
