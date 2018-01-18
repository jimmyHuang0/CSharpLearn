using System;
using System.Collections.Generic;
using System.Text;

namespace CommonItf.RWItf
{
    public interface IMultiRW
    {
        List<ITag> readMulti(List<ITag> list);
        List<ITag> writeMulti(List<ITag> list);
    }
}
