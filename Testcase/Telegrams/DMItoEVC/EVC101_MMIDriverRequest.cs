﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CL345;

namespace Testcase.Telegrams
{
    /// <summary>
    /// This packet shall be sent when the driver requests for an action from the ATP, 
    /// typically by pressing a button..
    /// </summary>
    static class EVC101_MMIDriverRequest
    {
        private static SignalPool _pool;        

        public static void Receive(byte mmiMRequest, bool mmiQButton)
        {
            bool bResult = false;
            
            // Checking packet id
            _pool.SITR.CCUO.ETCS1DriverRequest.MmiMPacket.Value.Equals(101);
            // Checking packet length
            _pool.SITR.CCUO.ETCS1DriverRequest.MmiLPacket.Value.Equals(80);
            // Checking MMI_M_REQUEST
            bResult = _pool.SITR.CCUO.ETCS1DriverRequest.MmiMRequest.Value.Equals(mmiMRequest);
            if (bResult) { _pool.TraceInfo("EVC-101 received: MMI_M_REQUEST = {0}", mmiMRequest); }
            // Extracting EVC101alias1 into an array of byte
            BitArray evc101alias1 = new BitArray(new[]
            { _pool.SITR.CCUO.ETCS1DriverRequest.EVC101alias1.Value });
            // Checking bool MMI_Q_BUTTON
            bResult = evc101alias1[7].Equals(mmiQButton);
            if (bResult) { _pool.TraceInfo("EVC-101 received: MMI_Q_BUTTON = {0}", mmiQButton); }
        }
    }
}