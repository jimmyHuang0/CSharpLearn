using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ModbusLib;
using ModbusLib.Protocols;

namespace modPro
{

    public partial class MainForm : Form
    {
        ModMaster _master = new ModMaster();

        private stNode[] NodeList =
        {
            //new stNode( 0x01 ,"Kp小数位     " ,0),
            //new stNode( 0x02 ,"Kp有效位     " ,0),
            //new stNode( 0x03 ,"Ki小数位     " ,0),
            //new stNode( 0x04 ,"Ki有效位     " ,0),
            //new stNode( 0x05 ,"Kd小数位     " ,0),
            //new stNode( 0x06 ,"Kd有效位     " ,0),
            //new stNode( 0x07 ,"Kp100小数位  " ,0),
            //new stNode( 0x08 ,"Kp100有效位  " ,0),
            //new stNode( 0x09 ,"Ki100小数位  " ,0),
            //new stNode( 0x0A ,"Ki100有效位  " ,0),
            //new stNode( 0x0B ,"Kd100小数位  " ,0),
            //new stNode( 0x0C ,"Kd100有效位  " ,0),
            new stNode( 0x0D ,"初始位置     " ,0),
        };
        private stPIDNode[] PIDNodeList =
       {
            new stPIDNode( 0x01 ,"Kp     " ,0),
           // new stPIDNode( 0x02 ,"Kp有效位     " ,0),
            new stPIDNode( 0x03 ,"Ki     " ,0),
           // new stPIDNode( 0x04 ,"Ki有效位     " ,0),
            new stPIDNode( 0x05 ,"Kd     " ,0),
            //new stPIDNode( 0x06 ,"Kd有效位     " ,0),
            new stPIDNode( 0x07 ,"Kp100  " ,0),
            //new stPIDNode( 0x08 ,"Kp100有效位  " ,0),
            new stPIDNode( 0x09 ,"Ki100 " ,0),
            //new stPIDNode( 0x0A ,"Ki100有效位  " ,0),
            new stPIDNode( 0x0B ,"Kd100  " ,0),
            //new stPIDNode( 0x0C ,"Kd100有效位  " ,0),
            //new stPIDNode( 0x0D ,"初始位置     " ,0),
        };

        List<ModbusNodeView> NodeViews = new List<ModbusNodeView>();
        List<PIDNodeView> PIDViews = new List<PIDNodeView>();
        ConnectView connectView;

        public MainForm()
        {
            InitializeComponent();

            //加载通讯通用按钮
            connectView = new ConnectView(this._master);
            connectView.Location= new System.Drawing.Point(10, 0);
            this.Controls.Add(connectView);

            //加载列表
            getNodeListByXml();


            return;
            for (int i = 0; i < NodeList.Length; i++)
            {
                NodeViews.Add(new ModbusNodeView(NodeList[i], _master));
                NodeViews[i].Location = new System.Drawing.Point(30, 200 + i * 30);
                this.Controls.Add(NodeViews[i]);
            }

            for (int i = 0; i < PIDNodeList.Length; i++)
            {
                PIDViews.Add(new PIDNodeView(PIDNodeList[i], _master));
                PIDViews[i].Location = new System.Drawing.Point(350, 200 + i * 30);
                this.Controls.Add(PIDViews[i]);
            }
        }

        private void getNodeListByXml()
        {
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load("nodeList.xml");
                XmlNode root = xmldoc.FirstChild;
                XmlNode pidNodes=null;
                XmlNode commNodes = null;
                foreach (XmlNode item in root.ChildNodes)
                {
                    switch (item.Name)
                    {
                        case "PIDNode":
                            pidNodes = item;
                            break;
                        case "CommNode":
                            commNodes = item;
                            break;
                    }
                }
                int i = 0;
                foreach (XmlNode item in commNodes.ChildNodes)
                {
                    //是否可用16进制表示
                    ushort address = Convert.ToUInt16(item.Attributes["add"].Value,16);
                    string name = $"{item.Attributes["name"].Value}:{item.Attributes["add"].Value}";
                    short.TryParse(item.Attributes["add"].Value, out short initValue);

                    stNode node = new stNode(address, name, initValue);
                    NodeViews.Add(new ModbusNodeView(node, _master));
                    NodeViews[i].Location = new System.Drawing.Point(30, 200 + i * 30);
                    this.Controls.Add(NodeViews[i]);
                    i++;
                }
                i = 0;
                foreach (XmlNode item in pidNodes.ChildNodes)
                {
                    //是否可用16进制表示
                    ushort address = Convert.ToUInt16(item.Attributes["add"].Value, 16);
                    string name = $"{item.Attributes["name"].Value}:{item.Attributes["add"].Value}";
                    short.TryParse(item.Attributes["add"].Value, out short initValue);

                    stPIDNode node = new stPIDNode(address, name, initValue);
                    PIDViews.Add(new PIDNodeView(node, _master));
                    PIDViews[i].Location = new System.Drawing.Point(350, 200 + i * 30);
                    this.Controls.Add(PIDViews[i]);
                    i++;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        private void btnRead_Click(object sender, EventArgs e)
        {
            foreach (var item in NodeViews)
            {
                item.read();
            }
            foreach (var item in PIDViews)
            {
                item.read();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connectView.SaveUserData();
        }
    }
}
