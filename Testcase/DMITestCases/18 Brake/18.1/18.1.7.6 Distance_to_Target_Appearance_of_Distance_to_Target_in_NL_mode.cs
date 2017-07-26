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

namespace Testcase.DMITestCases
{
    /// <summary>
    /// 18.1.7.6 Distance to Target: Appearance of Distance to Target in NL mode
    /// TC-ID: 13.1.7.6
    /// 
    /// This test case verifies the display information of the distance to target bar and digital in NL mode. The display of distance to target bar and digital is comply with the received packet EVC-1 and EVC-7.  
    /// 
    /// Tested Requirements:
    /// MMI_gen 2567 (partly: Table 38, NL mode); MMI_gen 107 (partly: Table 37, NL mode); MMI_gen 6658; MMI_gen 6774;
    /// 
    /// Scenario:
    /// 1.Enter NL mode. Then, verify the display of distance to target bar and digital when received packet EVC-1 and EVC-7.
    /// 
    /// Used files:
    /// N/A
    /// </summary>
    public class Distance_to_Target_Appearance_of_Distance_to_Target_in_NL_mode : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // System is powered on.Cabin is activated.Driver ID is entered.Level 1 is selected and confirmed.

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in NL mode, level 1

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint


            /*
            Test Step 1
            Action: Perform the following procedure, Force the simulation to ‘Non-leadingPress and hold ‘Non-leading’ button at least 2 second.Release the pressed button. 
            Expected Result: DMI displays in NL mode, level 0Verify the following information(1)    Use the log file to confirm that DMI receives the following packets information with a specific value,  EVC-7: OBU_TR_M_MODE = 11 (NL mode) (2)   The distance to target bar is not display in sub-area A3. (3)   The distance to target digital is not display in sub-area A2.(4)   Use the log file to confirm that DMI receives the packet EVC-1 with variable MMI_O_BRAKETARGET = -1 (Default).
            Test Step Comment: (1) MMI_gen 107 (partly: OBU_TR_M_MODE, NL mode); MMI_gen 2567 (partly: OBU_TR_M_MODE, NL mode);(2) MMI_gen 6658 (partly: not be shown); MMI_gen 107 (partly: Table 37, NL mode);(3) MMI_gen 2567 (partly: Table 38, NL mode); MMI_gen 6774 (partly: not be shown);(4) MMI_gen 6658 (partly: MMI_O_BRAKETARGET is less than zero); MMI_gen 6774 (partly: MMI_O_BRAKETARGET is less than zero);
            */

            /*
            Test Step 2
            Action: End of test
            Expected Result: 
            */

            return GlobalTestResult;
        }
    }
}