﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CL345;

namespace Testcase.Telegrams
{
    /// <summary>
    /// This packet shall be sent when the driver acts during the Train Data Entry procedure. It covers the following use cases:
    /// 1. Driver accepts a data element by pressing 'Enter'.
    /// 2. Driver accepts a data element by pressing 'Enter_Delay_Type'.
    /// 3. Driver completes entering a data block by pressing 'Yes'.
    /// 4. Driver overrules an operational check rule by pressing 'Delay Type Yes'.
    /// </summary>
    static class EVC107_MMINewTrainData
    {
        private static SignalPool _pool;

        public static void ReceiveVariableTD(ushort mmiLTrain, ushort mmiVMaxTrain, SignalPool pool)
        {
            bool Result = false;

            _pool = pool;

            // Check packet ID
            _pool.SITR.CCUO.ETCS1NewTrainData.MmiMPacket.Value.Equals(107);
            
            // Check MMI_L_TRAIN
            Result = _pool.SITR.CCUO.ETCS1NewTrainData.MmiLTrain.Value.Equals(mmiLTrain);

            if (Result)
            {
                _pool.TraceInfo($"EVC-107 received: MMI_L_TRAIN = {mmiLTrain}");
            }
            
            // Check MMI_V_MAXTRAIN
            Result = _pool.SITR.CCUO.ETCS1NewTrainData.MmiVMaxtrain.Value.Equals(mmiVMaxTrain);

            if (Result)
            {
                _pool.TraceInfo($"EVC-107 received: MMI_V_MAXTRAIN = {mmiVMaxTrain}");
            }
        }
    }
}