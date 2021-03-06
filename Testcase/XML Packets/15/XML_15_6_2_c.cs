﻿#region usings

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BT_Tools;
using BT_CSB_Tools;
using BT_CSB_Tools.Logging;
using BT_CSB_Tools.Utils.Xml;
using BT_CSB_Tools.SignalPoolGenerator.Signals;
using BT_CSB_Tools.SignalPoolGenerator.Signals.MwtSignal;
using BT_CSB_Tools.SignalPoolGenerator.Signals.MwtSignal.Misc;
using BT_CSB_Tools.SignalPoolGenerator.Signals.PdSignal;
using BT_CSB_Tools.SignalPoolGenerator.Signals.PdSignal.Misc;
using CL345;
using Testcase.Telegrams.EVCtoDMI;
using Testcase.DMITestCases;

#endregion

namespace Testcase.XML
{
    /// <summary>
    /// Values of 15.6.2_c.xml file
    /// </summary>
    static class XML_15_6_2_c
    {
        private static SignalPool _pool;

        public static void Send(SignalPool pool)
        {
            _pool = pool;

            EVC33_MMIAdditionalOrder.MMI_M_TRACKCOND_TYPE = Variables.MMI_M_TRACKCOND_TYPE.Level_Crossing;
            EVC33_MMIAdditionalOrder.MMI_NID_TRACKCOND = 0;
            EVC33_MMIAdditionalOrder.MMI_Q_TRACKCOND_ACTION = Variables.MMI_Q_TRACKCOND_ACTION.WithDriverAction;
            EVC33_MMIAdditionalOrder.MMI_Q_TRACKCOND_STEP = Variables.MMI_Q_TRACKCOND_STEP.AnnounceArea;
            EVC33_MMIAdditionalOrder.Send();
        }
    }
}