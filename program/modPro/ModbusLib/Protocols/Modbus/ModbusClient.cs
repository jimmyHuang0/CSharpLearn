﻿
/*
 * Copyright 2012 Mario Vernari (http://cetdevelop.codeplex.com/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace ModbusLib.Protocols
{
    /// <summary>
    /// Modbus client proxy
    /// 
    /// 
    /// 发送方法：
    ///     ExecuteGeneric：绑定需要发的端口，和传入一个发送的命令
    ///         ICommClient port,
    ///         ModbusCommand command
    ///     发送的编码类型，在实例类的时候指定：
    ///         IProtocolCodec Codec
    ///     触发两个事件：
    ///         OutgoingData
    ///         IncommingData
    /// 
    /// 编码方式：
    ///      IProtocolCodec Codec
    /// 
    /// 
    /// </summary>
    public class ModbusClient
        : IProtocol
    {
        public ModbusClient(IProtocolCodec codec)
        {
            Codec = codec;
        }

        /// <summary>
        /// The reference to the codec to be used
        /// </summary>
        public IProtocolCodec Codec { get; private set; }

        public event ModbusCommand.OutgoingData OutgoingData;
        public event ModbusCommand.IncommingData IncommingData;
        public void OnOutgoingData(byte[] data)
        {
            if (OutgoingData != null) OutgoingData(data);
        }

        public void OnIncommingData(byte[] data)
        {
            if (IncommingData != null) IncommingData(data);
        }

        /// <summary>
        /// The address of the remote device
        /// </summary>
        public byte Address { get; set; }



        /// <summary>
        /// Entry-point for submitting any command
        /// </summary>
        /// <param name="port">The client port for the transport</param>
        /// <param name="command">The command to be submitted</param>
        /// <returns>The result of the query</returns>
        public CommResponse ExecuteGeneric(
            ICommClient port,
            ModbusCommand command)
        {
            var data = new ClientCommData(this);
            data.UserData = command;
            Codec.ClientEncode(data);//因为data是一个引用类型，所以可以不用ref来注明是引用

            var rVal = port.Query(data);
            if (data.OutgoingData != null)
                OnOutgoingData(data.OutgoingData.ToArray());
            if (data.IncomingData != null)
                OnIncommingData(data.IncomingData.ToArray());
            return rVal;
        }

        public void ExecuteAsync(
            ICommClient port,
            ModbusCommand command)
        {
            var data = new ClientCommData(this);
            data.UserData = command;
            Codec.ClientEncode(data);
            port.QueryAsync(data);
        }

    }
}
