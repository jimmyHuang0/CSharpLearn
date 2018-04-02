using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modPro
{
    public enum DisplayFormat
    {
        LED,
        Binary,
        Hex,
        Integer
    }

    public enum CommunicationMode
    {
        TCP,
        UDP,
        RTU
    }

    public enum Function
    {
        CoilStatus,
        InputStatus,
        HoldingRegister,
        InputRegister
    }
}
