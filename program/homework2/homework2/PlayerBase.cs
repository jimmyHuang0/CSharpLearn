using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    abstract class PlayerBase
    {
        string people { get; set; }
        string desk { get; set; }
        string chair { get; set; }
        string  fan{ get; set; }
        string ruler { get; set; }

        public void start() { Console.WriteLine("开始表演"); }
        public abstract void Bark();
        public abstract void Voice();
        public abstract void WindSound();

        public virtual void Prologue() { Console.WriteLine("开场白"); }
        public virtual void InStop() { Console.WriteLine("表演结束"); }
    }
}
