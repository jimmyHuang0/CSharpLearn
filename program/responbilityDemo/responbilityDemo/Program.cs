using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace responbilityDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            ///生成责任链关系
            baseAuditor PM = new AuditManager(8, "PM");
            baseAuditor charge = new AuditManager(16, "主管");
            baseAuditor manager = new AuditManager(24, "经理");
            PM.nextAuditor(charge);
            charge.nextAuditor(manager);


            //使用责任链，这里请假的人员只需要向PM请假，PM会向上一级，逐级批准
            AuditContext auditContext = new AuditContext();

            auditContext.time = 8;
            auditContext.name = "meimei";
            PM.Audit(auditContext);
            Console.WriteLine($"{auditContext.name}请假{auditContext.time}小时,{auditContext.AuditRemark}");

            auditContext.AuditRemark = "";
            auditContext.time = 16;
            auditContext.name = "dada";
            PM.Audit(auditContext);
            Console.WriteLine($"{auditContext.name}请假{auditContext.time}小时,{auditContext.AuditRemark}");

            auditContext.AuditRemark = "";
            auditContext.time = 24;
            auditContext.name = "nimei";
            PM.Audit(auditContext);
            Console.WriteLine($"{auditContext.name}请假{auditContext.time}小时,{auditContext.AuditRemark}");

            auditContext.AuditRemark = "";
            auditContext.time = 30;
            auditContext.name = "helloWorld";
            PM.Audit(auditContext);
            Console.WriteLine($"{auditContext.name}请假{auditContext.time}小时,{auditContext.AuditRemark}");


            Console.ReadLine();
        }
    }
}
