using ModbusLib;
using ModbusLib.Protocols;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modPro
{
    public struct stNode
    {
        public short value;
        public readonly ushort address;
        public readonly string name;
        public ModMaster master;

        public stNode(ushort address, string name, short initValue)
        {
            this.address = address;
            this.name = name;
            this.master = null;
            this.value = initValue;
        }
        public void setDriver(ModMaster master)
        {
            this.master = master;
        }
    }

    public struct stPIDNode
    {
        public nodeNum value;
        public readonly ushort address;
        public readonly string name;
        public ModMaster master;

        public stPIDNode(ushort address, string name, double initValue)
        {
            this.address = address;
            this.name = name;
            this.master = null;
            this.value = new nodeNum(initValue);
        }
        public void setDriver(ModMaster master)
        {
            this.master = master;
        }
    }

    public class nodeNum
    {
        public short valNum;//有效数字
        public short powNum;//小数位数
        public double value;

        public short[] toShorts()
        {
            setNodes(this.value);
            short[] n = new short[2];
            n[0] = valNum;
            n[1] = powNum;
            return n;
        }
        public double toValue(short[] s)
        {
            if (s.Length == 2)
            {
                value = s[0] * Math.Pow(10, (s[1]));
                return value;
            }
            else
                return value;
        }

        public nodeNum(double val)
        {
            this.value = val;
            setNodes(val);
        }

        private void setNodes(double val)
        {

            int dogPos = val.ToString().IndexOf(".");
            if (dogPos < 0)
            {
                this.powNum = (short)(0);
                this.valNum = (short)(val);
            }
            else
            {
                int length = val.ToString().Length;

                this.powNum = (short)(-(length - dogPos - 1));
                double d = val * Math.Pow(10, (-this.powNum));
                if(d>short.MaxValue)
                {
                    this.valNum = short.MaxValue;
                }
                else if(d<short.MinValue)
                {
                    this.valNum = short.MinValue;
                }
                else
                {
                    this.valNum = (short)(val * Math.Pow(10, (-this.powNum)));
                }  
            }
        }


        //public void test()
        //{
        //    while(value!=-999)
        //    {
        //        if(double.TryParse(Console.ReadLine(),out value))
        //        {
        //            getNodes();
        //            Console.WriteLine($"{_nodes[0]}, {_nodes[1]}, { _nodes[0]* Math.Pow(10, (_nodes[1])) }");
        //        }
        //    }
        //}
    }



    public class ModMaster
    {
        private int _transactionId;
        private ModbusClient _driver;
        private ICommClient _portClient;
        private SerialPort _uart;


        protected Socket _socket;
        protected readonly UInt16[] _registerData = new UInt16[100];
        private bool _logPaused = false;

        //protected CommunicationMode _CommunicationMode = CommunicationMode.RTU;
        //protected string _PortName= "COM1";
        //protected int _Baud= 19200;
        //protected Parity _Parity = Parity.None;
        //protected int _DataBits = 8;
        //protected StopBits _StopBits = StopBits.One;
        //protected IPAddress _IPAddress= IPAddress.Parse("127.0.0.1");
        //protected int _TCPPort=502;
        //protected byte _SlaveId=1;

        public void ConnectRTU(string PortName, int Baud, Parity Parity, int DataBits, StopBits StopBits,byte SlaveId)
        {
            try
            {
                _uart = new SerialPort(PortName, Baud, Parity, DataBits, StopBits);
                _uart.Open();
                _portClient = _uart.GetClient();
                _driver = new ModbusClient(new ModbusRtuCodec()) { Address = SlaveId };
                _driver.OutgoingData += DriverOutgoingData;
                _driver.IncommingData += DriverIncommingData;
                Console.WriteLine(String.Format("Connected using RTU to {0}", PortName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
                return;
            }
        }

        public void ConnectTCP(IPAddress IPAddress, int TCPPort, byte SlaveId)
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
                _socket.SendTimeout = 2000;
                _socket.ReceiveTimeout = 2000;
                _socket.Connect(new IPEndPoint(IPAddress, TCPPort));
                _portClient = _socket.GetClient();
                _driver = new ModbusClient(new ModbusTcpCodec()) { Address = SlaveId };
                _driver.OutgoingData += DriverOutgoingData;
                _driver.IncommingData += DriverIncommingData;
                Console.WriteLine(String.Format("Connected using TCP to {0}", _socket.RemoteEndPoint));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
                return;
            }
        }

        public void ConnectUDP(IPAddress IPAddress, int TCPPort, byte SlaveId)
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _socket.Connect(new IPEndPoint(IPAddress, TCPPort));
                _portClient = _socket.GetClient();
                _driver = new ModbusClient(new ModbusTcpCodec()) { Address = SlaveId };
                _driver.OutgoingData += DriverOutgoingData;
                _driver.IncommingData += DriverIncommingData;
                Console.WriteLine(String.Format("Connected using UDP to {0}", _socket.RemoteEndPoint));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
                return;
            }
        }



        //public void Connect()
        //{
        //    try
        //    {
        //        switch (CommunicationMode)
        //        {
        //            case CommunicationMode.RTU:
        //                //定义了一个串口类，并且返回一个拓展的通用接口
        //                _uart = new SerialPort(PortName, Baud, Parity, DataBits, StopBits);
        //                _uart.Open();
        //                _portClient = _uart.GetClient();
        //                _driver = new ModbusClient(new ModbusRtuCodec()) { Address = SlaveId };
        //                _driver.OutgoingData += DriverOutgoingData;
        //                _driver.IncommingData += DriverIncommingData;
        //                Console.WriteLine(String.Format("Connected using RTU to {0}", PortName));
        //                break;

        //            case CommunicationMode.UDP:
        //                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //                _socket.Connect(new IPEndPoint(IPAddress, TCPPort));
        //                _portClient = _socket.GetClient();
        //                _driver = new ModbusClient(new ModbusTcpCodec()) { Address = SlaveId };
        //                _driver.OutgoingData += DriverOutgoingData;
        //                _driver.IncommingData += DriverIncommingData;
        //                Console.WriteLine(String.Format("Connected using UDP to {0}", _socket.RemoteEndPoint));
        //                break;

        //            case CommunicationMode.TCP:
        //                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //                _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
        //                _socket.SendTimeout = 2000;
        //                _socket.ReceiveTimeout = 2000;
        //                _socket.Connect(new IPEndPoint(IPAddress, TCPPort));
        //                _portClient = _socket.GetClient();
        //                _driver = new ModbusClient(new ModbusTcpCodec()) { Address = SlaveId };
        //                _driver.OutgoingData += DriverOutgoingData;
        //                _driver.IncommingData += DriverIncommingData;
        //                Console.WriteLine(String.Format("Connected using TCP to {0}", _socket.RemoteEndPoint));
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Disconnect();
        //        return;
        //    }
        //}

        public void Disconnect()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket.Dispose();
                _socket = null;

                Console.WriteLine("close socket");
            }
            if (_uart != null)
            {
                _uart.Close();
                _uart.Dispose();
                _uart = null;

                Console.WriteLine("close serial port");
            }
            _portClient = null;
            _driver = null;
        }

        protected void DriverIncommingData(byte[] data)
        {
            if (_logPaused)
                return;
            var hex = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                hex.AppendFormat("{0:x2} ", b);
            Console.WriteLine(String.Format("RX: {0}", hex));
        }

        protected void DriverOutgoingData(byte[] data)
        {
            if (_logPaused)
                return;
            var hex = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                hex.AppendFormat("{0:x2} ", b);
            Console.WriteLine(String.Format("TX: {0}", hex));
        }



        public CommResponse ExecuteReadCommand(byte function, ushort StartAddress, ushort DataLength)
        {
            CommResponse result = null;
            try
            {
                var command = new ModbusCommand(function)
                {
                    Offset = StartAddress,
                    Count = DataLength,
                    TransId = _transactionId++
                };
                result = _driver.ExecuteGeneric(_portClient, command);
                if (result.Status == CommResponse.Ack)
                {
                    //UInt16[] Data = new ushort[command.Data.Length];
                    //command.Data.CopyTo(Data, StartAddress);
                    //foreach (var item in Data)
                    //{
                    //    Console.WriteLine(item);
                    //}
                    Console.WriteLine($"Read succeeded: Function code:{function}  {_transactionId}");
                }
                else
                {
                    Console.WriteLine(String.Format("Failed to execute Read: Error code:{0}", result.Status));
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public CommResponse ExecuteWriteCommand(byte function, ushort StartAddress, ushort DataLength, short[] data)
        {
            CommResponse result=null;
            try
            {
                var command = new ModbusCommand(function)
                {
                    Offset = StartAddress,
                    Count = DataLength,
                    TransId = _transactionId++,
                    Data = new ushort[DataLength]
                };
                for (int i = 0; i < DataLength; i++)
                {
                    //var index = StartAddress + i;
                    //if (index > data.Length)
                    //{
                    //    break;
                    //}
                    //command.Data[i] = (ushort)data[index];

                    if (i > data.Length)
                    {
                        break;
                    }
                    command.Data[i] = (ushort)data[i];
                }
                result = _driver.ExecuteGeneric(_portClient, command);
                Console.WriteLine(result.Status == CommResponse.Ack
                              ? String.Format("Write succeeded: Function code:{0}", function)
                              : String.Format("Failed to execute Write: Error code:{0}", result.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }


        public bool ReadSingelHoldingRegister(ushort Address,out short resultValue)
        {
            var result = ExecuteReadCommand(ModbusCommand.FuncReadMultipleRegisters, Address, 1);
            if ((result == null)||(result.Status != CommResponse.Ack))
            {
                resultValue = 0;
                return false;
            }
            else
            {
                resultValue=(short)((ModbusCommand)result.Data.UserData).Data[0];
                return true;
            }    
        }
        public bool WriteSingelHoldingRegister(ushort Address, short Value)
        {
            short[] sdata = { Value };
            var result = ExecuteWriteCommand(ModbusCommand.FuncWriteSingleRegister, Address, 1, sdata);
            if ((result == null) || (result.Status != CommResponse.Ack))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
