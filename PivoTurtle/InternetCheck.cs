/*
 Copyright 2012 Descom Consulting Ltd.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PivoTurtle
{
    public class InternetCheck
    {
        public static bool CheckInternetConnection()
        {
            InternetConnectionState flags = 0;
            return CheckInternetConnection(flags);
        }

        public static bool CheckInternetConnection(InternetConnectionState flags)
        {
            try
            {
                bool isConnected = InternetGetConnectedState(ref flags, 0);
                return isConnected;
            }
            catch
            {
                // do nothing
            }
            return false;
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        private extern static bool InternetGetConnectedState(ref InternetConnectionState lpdwFlags, int dwReserved);

        [Flags]
        public enum InternetConnectionState : int
        {
            INTERNET_CONNECTION_MODEM = 0x1,
            INTERNET_CONNECTION_LAN = 0x2,
            INTERNET_CONNECTION_PROXY = 0x4,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }
    }
}
