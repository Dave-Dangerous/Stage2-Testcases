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
    static class EVC102_MMIStatusReport
    {
        private static SignalPool _pool;
        private static bool _bResult;
        private static string _modeRead;
        private static MMI_M_MODE_READBACK _modeReadBack;     

        private static void CheckModeReadBack(MMI_M_MODE_READBACK modeReadBack)
        {
            //For each element of enum MMI_M_MODE_READBACK 
            foreach (MMI_M_MODE_READBACK mmiMModeReadBackElement in Enum.GetValues(typeof(MMI_M_MODE_READBACK)))
            {
                //Compare to the value to be checked
                if (mmiMModeReadBackElement == modeReadBack)
                {
                    _modeRead = mmiMModeReadBackElement.ToString();
                    _bResult = _pool.SITR.CCUO.ETCS1StatusReport.MmiMModeReadback.Equals(modeReadBack);
                    break;
                }
            }

            //if check passes
            if (_bResult)
            {
                _pool.TraceReport("DMI->ETCS: EVC-102 [MMI_STATUS_REPORT.MMI_M_MODE_READBACK] = " + modeReadBack +
                    " - \"" + _modeRead + "\" PASSED.");
            }
            else
            {
                _pool.TraceError("DMI->ETCS: Check EVC-102 [MMI_STATUS_REPORT.MMI_M_MODE_READBACK] = " +
                                 _pool.SITR.CCUO.ETCS1StatusReport.MmiMModeReadback.Value
                                 + "FAILED.");
            }
        }
       
        public static MMI_M_MODE_READBACK Check_MMI_M_MODE_READBACK
        {
            set
            {
                _modeReadBack = value;
                CheckModeReadBack(_modeReadBack);
            }
        }

        public enum MMI_M_MODE_READBACK : ushort
        {
            ShownModeInvalid = 0,
            NoModeDisplayed = 1,
            FullSupervision = 255,
            OnSight = 254,
            StaffResponsible = 253,
            Shunting = 252,
            Unfitted = 251,
            Sleeping = 250,
            StandBy = 249,
            Trip = 248,
            PostTrip = 247,
            SystemFailure = 246,
            Isolation = 245,
            NonLeading = 244,
            LimitedSupervision = 243,
            NationalSystem = 242,
            Reversing = 241,
            PassiveShunting = 240,
            NoPower = 239
        }
    }
}