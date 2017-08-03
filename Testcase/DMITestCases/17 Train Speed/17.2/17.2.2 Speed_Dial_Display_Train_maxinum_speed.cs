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
    /// 17.2.2 Speed Dial: Display Train maxinum speed
    /// TC-ID: 12.2.2
    /// 
    /// This test case is to verify that DMI provide the full service train speed up to 550 Km/h and possible to configure lower values lfor specific project requirements. 
    /// 
    /// Tested Requirements:
    /// MMI_gen 67;
    /// 
    /// Scenario:
    /// 1.Power on the system and activate cabin.
    /// 2.Perform SoM in SR mode, level 1.
    /// 3.Verify the maximum speed display on DMI is align with the configuration setting.
    /// 
    /// Used files:
    /// N/A
    /// </summary>
    public class Speed_Dial_Display_Train_maxinum_speed : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // Power off the system Set the following tags name in configuration file (See the instruction in Appendix 1)SPEED_DIAL_V_MAX = 550SPEED_DIAL_V_TRANS = 100 

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays SR mode.

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint


            /*
            Test Step 1
            Action: Power on the system and activate the cabin
            Expected Result: DMI displays SB mode
            */
            // Call generic Action Method
            DmiActions.Power_on_the_system_and_activate_the_cabin(this);
            // Call generic Check Results Method
            DmiExpectedResults.SB_Mode_displayed(this);


            /*
            Test Step 2
            Action: Perform SoM to  SR mode, level 1
            Expected Result: Mode changes to SR mode , level 1Verify the following information:The speed dial displays 550 km/h as a mixminum speed
            Test Step Comment: MMI_gen 67 (partly:550 km/h);
            */


            /*
            Test Step 3
            Action: Change the configuration: SPEED_DIAL_V_MAX  to 200, 300 and 400 then retest with step 1 to 2
            Expected Result: Verify the following information:The speed dial displays the maxinum speed accroding to configuration setting
            Test Step Comment: MMI_gen 67 (partly: configure lower values);
            */


            /*
            Test Step 4
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}