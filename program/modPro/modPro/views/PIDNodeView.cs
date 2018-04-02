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
    public partial class PIDNodeView : UserControl
    {
        public PIDNodeView(stPIDNode node, ModMaster master)
        {
            InitializeComponent();
            _node = node;
            _node.setDriver(master);
            lblName.Text = _node.name;
        }

        stPIDNode _node;


        private void btnRead_Click(object sender, EventArgs e)
        {
            read();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tboxValue.Text,out double val))
            {
                _node.value.value = val;
                var result = _node.master.ExecuteWriteCommand(
                    ModbusCommand.FuncWriteMultipleRegisters,
                    _node.address, 
                    2, 
                    _node.value.toShorts());  
            } 
        }

        public bool read()
        {
            var result = _node.master.ExecuteReadCommand(
                   ModbusCommand.FuncReadMultipleRegisters,
                   _node.address,
                   2);
            if ((result == null) || (result.Status != CommResponse.Ack))
            {
                return false;
            }
            else
            {
                ushort[] us = ((ModbusCommand)result.Data.UserData).Data;
                short[] s = new short[us.Length];
                for (int i = 0; i < us.Length; i++)
                {
                    s[i] = (short)us[i];
                }     
                tboxValue.Text = _node.value.toValue(s).ToString();
                return true;
            }
        }
    }
}
