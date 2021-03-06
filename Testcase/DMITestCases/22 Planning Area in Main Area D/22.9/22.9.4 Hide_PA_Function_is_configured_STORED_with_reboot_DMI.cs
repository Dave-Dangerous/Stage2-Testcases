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
    /// 22.9.4 Hide PA Function is configured ‘STORED’ with reboot DMI
    /// TC-ID: 17.9.4
    /// 
    /// This test case verifies that if the Hide PA Function is configured as “Stored” and then reboot the DMI. The all PA’s objects shall be hidden, configuration of Hide PA Function is not effect when DMI reboot.
    /// 
    /// Tested Requirements:
    /// MMI_gen 7341; MMI_gen 2996 (partly: Stored);
    /// 
    /// Scenario:
    /// Activate cabin A. Driver enters the Driver ID and performs brake test. Then the driver selects level 1, Train data, and validate the train data. After that driver enter Train running number and confirm SR mode. At 100 m, pass BG1 with pkt 12, pkt 21 and pkt 
    /// 27.Mode changes to FS modeTurn off and then turn on DMI. The Hide PA button is appeared on the area D of the DMI.
    /// 
    /// Used files:
    /// 17_9_4.tdg
    /// </summary>
    public class Hide_PA_Function_is_configured_STORED_with_reboot_DMI : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // Set the following tags name in configuration file (See the instruction in Appendix 1)HIDE_PA_FUNCTION = 2 (‘Stored’ state)System is power off

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
            Action: Power On the system
            Expected Result: DMI displays the default window
            */
            // Call generic Action Method
            DmiActions.Power_On_the_system(this);
            // Call generic Check Results Method
            DmiExpectedResults.DMI_displays_the_default_window(this);


            /*
            Test Step 2
            Action: Activate cabin A and Perform SoM to SR mode, Level 1
            Expected Result: DMI displays in SR mode and level 1
            */
            // Call generic Action Method
            DmiActions.Activate_cabin_A_and_Perform_SoM_to_SR_mode_Level_1(this);
            // Call generic Check Results Method
            DmiExpectedResults.SR_Mode_displayed(this);


            /*
            Test Step 3
            Action: Drive the train forward with speed = 40 km/h pass BG1
            Expected Result: DMI shows “Entering FS” messageDMI displays the Planning area in main area D.The Hide PA button is appeared on  the main area D of the DMI
            Test Step Comment: (1) MMI_gen 7341;   
            */
            // Call generic Action Method
            DmiActions.Drive_the_train_forward_with_speed_40_kmh_pass_BG1(this);


            /*
            Test Step 4
            Action: Press Hide PA button
            Expected Result: The Planning area is disappeared from the main area D of DMI
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press Hide PA button");


            /*
            Test Step 5
            Action: Turn off power of DMI
            Expected Result: DMI is power off
            */
            // Call generic Action Method
            DmiActions.Turn_off_power_of_DMI(this);
            // Call generic Check Results Method
            DmiExpectedResults.DMI_is_power_off(this);


            /*
            Test Step 6
            Action: Turn on power of DMI
            Expected Result: DMI is power on DMI displays the Planning area. The Hide PA button is appeared on the main area D of DMI
            Test Step Comment: MMI_gen 7341;  MMI_gen 2996 (partly: Stored); Hide PA icon
            */
            // Call generic Action Method
            DmiActions.Turn_on_power_of_DMI(this);


            /*
            Test Step 7
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}