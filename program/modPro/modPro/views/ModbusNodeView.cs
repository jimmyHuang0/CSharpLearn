using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModbusLib;
using ModbusLib.Protocols;

namespace modPro
{
    public partial class ModbusNodeView : UserControl
    {
        public ModbusNodeView(stNode node, ModMaster master)
        {
            InitializeComponent();
            _node = node;
            _node.setDriver(master);
            lblName.Text = _node.name;
        }

        private stNode _node;

        private void btnRead_Click(object sender, EventArgs e)
        {
            read();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (short.TryParse(tboxValue.Text,out short val))
            {
                _node.master.WriteSingelHoldingRegister(_node.address,val);       
            } 
        }

        public bool read()
        {
            bool ret = false;
            if (_node.master.ReadSingelHoldingRegister(_node.address, out short val))
            {
                tboxValue.Text = val.ToString();
                ret = true;
            }
            return ret;
        }
    }
}
