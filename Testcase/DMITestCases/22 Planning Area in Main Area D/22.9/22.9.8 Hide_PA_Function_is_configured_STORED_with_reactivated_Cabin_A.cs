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
    /// 22.9.8 Hide PA Function is configured ‘STORED’ with reactivated Cabin A
    /// TC-ID: 17.9.8
    /// 
    /// This test case verifies that the default state of Planning area is shown/hidden refer to ‘STORED’ configuration of Hide PA function included with correctness of displayed Planning area when activate ‘Hide’/’Show’ buttons after cabin re-activation.
    /// 
    /// Tested Requirements:
    /// MMI_gen 7340; MMI_gen 2996 (partly: Stored);
    /// 
    /// Scenario:
    /// Activate Cabin A.Perform SoM in SR mode, Level 1.Drive the train forward pass BG1 at position 100m.BG1: Packet 12, 21 and 27 (mode changes to FS)Press ‘Hide PA’ button.Stop the train at position 300m.De-activate cabin A and activate cabin A again.Drive the train forward pass BG2 at position 600m. Then, verify that PA is hidden by stored configuration.BG2: packet 12, 21 and 27 (mode changes to FS)
    /// 
    /// Used files:
    /// 17_9_8.tdg
    /// </summary>
    public class Hide_PA_Function_is_configured_STORED_with_reactivated_Cabin_A : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // Set the following tags name in configuration file (See the instruction in Appendix 1)HIDE_PA_FUNCTION = 2 (‘Stored’ state)HIDE_PA_SR_MODE = 0 (PA will not show in SR mode)System is power OFF.

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in FS mode, Level 1. 

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint


            /*
            Test Step 1
            Action: Power On the system.
            Expected Result: The DMI displays the default window.
            */

            /*
            Test Step 2
            Action: Activate cabin A and Perform SoM to SR mode, Level 1.
            Expected Result: The DMI displays in SR mode,  level 1.
            */

            /*
            Test Step 3
            Action: Drive the train forward with speed = 40 km/h pass BG1.
            Expected Result: DMI displays in FS mode, Level 1 with PA in area D.
            */

            /*
            Test Step 4
            Action: Press Hide PA button.
            Expected Result: The Planning area is disappeared from the area D of the DMI.
            */

            /*
            Test Step 5
            Action: Stop the train. Then, deactivate cabin A.
            Expected Result: The train is at standstill.DMI is displays in SB mode.
            */

            /*
            Test Step 6
            Action: Activate cabin A and Perform SoM to SR mode, Level 1.
            Expected Result: DMI displays in SR mode, Level 1.
            */

            /*
            Test Step 7
            Action: Drive the train forward with speed = 40 km/h pass BG2.
            Expected Result: DMI displays in FS mode, Level 1.There is no PA display on DMI.
            Test Step Comment: MMI_gen 7340;MMI_gen 2996 (partly: Stored);
            */

            /*
            Test Step 8
            Action: Press the main area D.
            Expected Result: The Hide PA button is appeared on  the area D of the DMI.
            */

            /*
            Test Step 9
            Action: End of test
            Expected Result: 
            */

            return GlobalTestResult;
        }
    }
}