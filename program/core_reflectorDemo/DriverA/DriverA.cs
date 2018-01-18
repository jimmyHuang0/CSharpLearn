using System;
using CommonItf.RWItf;


namespace DriverA
{
    public class DriverA : ISingleRW
    {
        ITag ISingleRW.readSingle(ITag tag)
        {
            tag.name.NameInMaster = "I'm DriverA";
            tag.value.value = "1";
            return tag;
        }

        ITag ISingleRW.writeSingle(ITag tag)
        {
            tag.name.NameInMaster = "I'm DriverA";
            tag.value.value = "1";
            return tag;
        }
    }
}
