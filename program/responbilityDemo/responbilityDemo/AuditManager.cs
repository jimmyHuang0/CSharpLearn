using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace responbilityDemo
{
    class AuditManager : baseAuditor
    {
        private uint _time;
        private string _name;
        public AuditManager(uint time,string name)
        {
            this._time = time;
            this._name = name;
        }
        public override void Audit(AuditContext auditContext)
        {
            if(auditContext.time<=this._time)
            {
                auditContext.AuditResult = true;
                auditContext.AuditRemark = auditContext.AuditRemark + $"{this._name},批准通过";
            }
            else
            {
                if(base.getAuditor() == null)
                {
                    auditContext.AuditResult = false;
                    auditContext.AuditRemark = auditContext.AuditRemark + "时间太长，审批不通过";
                }
                else
                {
                    auditContext.AuditRemark = auditContext.AuditRemark + $"{this._name}向上级申请，";
                    base.getAuditor().Audit(auditContext);
                }
            }
        }
    }
}
