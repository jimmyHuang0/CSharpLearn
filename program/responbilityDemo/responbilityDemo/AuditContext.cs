using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace responbilityDemo
{
    class AuditContext
    {
        public string name { get; set; }
        public uint time { get; set; }
        public bool AuditResult { get; set; }
        public string AuditRemark { get; set; }
    }
}
