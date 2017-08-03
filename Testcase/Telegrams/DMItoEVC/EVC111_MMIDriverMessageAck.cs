﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CL345;
using Testcase.Telegrams.EVCtoDMI;

namespace Testcase.Telegrams.DMItoEVC
{
    /// <summary>
    /// This packet shall be sent when the driver requests for an action from the ATP, 
    /// typically by pressing a button..
    /// </summary>
    static class EVC111_MMIDriverMessageAck
    {
        private static SignalPool _pool;
        private static bool _bResult;
        private static Variables.MMI_Q_BUTTON _qButton;

        /// <summary>
        /// Initialise EVC-111 MMI_Driver_Message_Ack telegram.
        /// </summary>
        /// <param name="pool"></param>
        public static void Initialise(SignalPool pool)
        {
            _pool = pool;
        }

        private static void CheckButtonState(Variables.MMI_Q_BUTTON qButton)
        {
            // Convert byte EVC111_alias_1 into an array of bits.
            BitArray _evc111alias1 = new BitArray(new[] { _pool.SITR.CCUO.ETCS1DriverMessageAck.EVC111alias1.Value });
            // Extract bool MMI_Q_BUTTON (4th bit according to VSIS 2.9)
            bool _mmiQButton = _evc111alias1[3];

            // Convert byte buttonStateTested to bool
            BitArray _baqButton = new BitArray(new[] { (byte)qButton });
            bool _bqButton = _baqButton[0];

            //For each element of enum MMI_Q_BUTTON 
            foreach (Variables.MMI_Q_BUTTON mmiQButtonElement in Enum.GetValues(typeof(Variables.MMI_Q_BUTTON)))
            {
                //Compare to the value to be checked
                if (mmiQButtonElement == qButton)
                {
                    // Check MMI_Q_BUTTON value
                    _bResult = _mmiQButton.Equals(_bqButton);
                    break;
                }
            }

            if (_bResult) // if check passes
            {
                _pool.TraceReport("DMI->ETCS: EVC-111 [MMI_DRIVER_MESSAGE_ACK.MMI_Q_BUTTON] = \"" +
                    qButton.ToString() + "\" PASSED. TimeStamp = " +
                    _pool.SITR.CCUO.ETCS1DriverMessageAck.MmiTButtonEvent);
            }
            else // else display the real value extracted from EVC-111 [MMI_DRIVER_MESSAGE_ACK] 
            {
                _pool.TraceError("DMI->ETCS: Check EVC-111 [MMI_DRIVER_MESSAGE_ACK.MMI_Q_BUTTON] = \"" +
                    Enum.GetName(typeof(Variables.MMI_Q_BUTTON), _mmiQButton) + "\" FAILED. TimeStamp = " +                    
                    _pool.SITR.CCUO.ETCS1DriverMessageAck.MmiTButtonEvent);
            }


        }

        /// <summary>
        /// Button event (pressed or released)
        /// Values:
        /// 0 = "released"
        /// 1 = "pressed"
        /// </summary>
        public static Variables.MMI_Q_BUTTON Check_MMI_Q_BUTTON
        {
            set
            {
                _qButton = value;
                CheckButtonState(_qButton);
            }
        }      
    }
}