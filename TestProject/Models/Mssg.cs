using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public partial class Mssg
    {
        public int MssgId { get; set; }
        public string MssgText { get; set; }
        public int MssgContact { get; set; }
        public int MssgTopic { get; set; }

        public string MssgTel { get; set; }

        public string MssgEmail { get; set; }
        public string MssgName { get; set; }


        public virtual Contacts MssgContactNavigation { get; set; }
        public virtual Topics MssgTopicNavigation { get; set; }
    }
}
