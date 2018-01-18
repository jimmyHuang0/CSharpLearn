using System;
using System.Collections.Generic;
using System.Text;

namespace CommonItf.RWItf
{
    public interface ISingleRW
    {
        ITag readSingle(ITag tag);
        ITag writeSingle(ITag tag);
    }
}
