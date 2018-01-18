using System;
using CommonItf.RWItf;


namespace DriverB
{
    public class DriverB : ISingleRW
    {
        ITag ISingleRW.readSingle(ITag tag)
        {
            tag.name.NameInMaster = "I'm DriverB";
            tag.value.value = "2";
            return tag;
        }

        ITag ISingleRW.writeSingle(ITag tag)
        {
            tag.name.NameInMaster = "I'm DriverB";
            tag.value.value = "2";
            return tag;
        }
    }
}
