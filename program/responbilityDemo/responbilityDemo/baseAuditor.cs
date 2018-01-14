using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace responbilityDemo
{
    abstract class baseAuditor
    {
        private baseAuditor _baseAuditor = null;
        public void nextAuditor(baseAuditor baseAuditor)
        {
            this._baseAuditor = baseAuditor;
        }

        public baseAuditor getAuditor()
        {
            return this._baseAuditor;
        }

        abstract public void Audit(AuditContext auditContext);
    }
}
