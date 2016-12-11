﻿using System;
using Microsoft.Azure.Devices.Client;
using System.Threading.Tasks;
using System.Text;

namespace IoTHubUwp
{
    public class IoTHubConnection : IDisposable
    {
        private DeviceClient _deviceClient { get; set; }

        public IoTHubConnection()
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(GetConnectionString(), TransportType.Amqp);
        }

        public async Task SendEventAsync(string payload)
        {
            await _deviceClient.SendEventAsync(new Message(Encoding.ASCII.GetBytes(payload)));
        }

        private string GetConnectionString()
        {
            return "your-device-connection-string";
        }

        public void Dispose()
        {
            _deviceClient.Dispose();
        }
    }
}
