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
    /// 19.4 Toggling function: Default state reset for Configuration ‘ON’ when communication loss
    /// TC-ID: 14.4
    /// 
    /// This test case verifies that toggling function is reset to default state, configuration “ON” when communication between DMI and ETCS onboard is loss. The togglling function’s default state will be applied when communication is re-establish.
    /// 
    /// Tested Requirements:
    /// Information (paragraph 1) under, MMI_gen 6898 (partly: configuration “ON”, mode OS); MMI_gen 6588 (partly: configuration “ON”, mode OS, The Toggling Function's Default state shall be applied); MMI_gen 6589 (partly: configuration “ON”, mode OS, The Toggling Function's Default state shall be applied); MMI_gen 6878 (partly: configuration “ON”, mode OS, The Toggling Function's Default state shall be applied); MMI_gen 6879 (partly: configuration “ON”, mode OS, The Toggling Function's Default state shall be applied); MMI_gen 6453; Information under MMI_gen 6453;
    /// 
    /// Scenario:
    /// Drive the train forward pass BG1 at position 200mBG1: packet 12, 21 and 27 (Entering FS mode)Drive the train forward pass BG2 at position 300mBG4: packet 12, 21, 27 and 80 (Entering OS mode)Press an sensitive area for making display information of specifix objects are different from default of toggling function.Simulate loss-communication. Then, re-establish communication to verify that specifix obejects are displayed refer to configuration of toggle function.
    /// 
    /// Used files:
    /// 14_4.tdg
    /// </summary>
    public class Toggling_function_Default_state_reset_for_Configuration_ON_when_communication_loss : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // The DMI is configured TOGGLE_FUNCTION = 0 (‘ON’)System is power on.SoM is performed in SR mode, Level1.

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in OS mode, Level 1.

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint


            /*
            Test Step 1
            Action: Drive the train forward pass BG1
            Expected Result: DMI displays in FS mode, Level 1
            */
            // Call generic Action Method
            DmiActions.Drive_the_train_forward_pass_BG1(this);
            // Call generic Check Results Method
            DmiExpectedResults.DMI_displays_in_FS_mode_level_1(this);


            /*
            Test Step 2
            Action: Drive the train forward pass BG2.Then, stop the train
            Expected Result: DMI displays in OS mode, Level 1
            */
            // Call generic Action Method
            DmiActions.Drive_the_train_forward_pass_BG2_Then_stop_the_train(this);
            // Call generic Check Results Method
            DmiExpectedResults.DMI_displays_in_OS_mode_Level_1(this);


            /*
            Test Step 3
            Action: Press a sensitivity area (areas A1-A4 or B) to make a Basic Speed Hook not appear.Then simulate loss-communication between ETCS onboard and DMI (1 second).Note: Stopwatch is required for accuracy of test result
            Expected Result: DMI displays the  message “ATP Down Alarm” with sound alarm.Verify the following information,The objects below are not displayed on DMI,White Basic speed HookMedium-grey basic speed hookDistance to target (digital)Release Speed Digital
            Test Step Comment: (1) Information (paragraph 1) under, MMI_gen 6898 (inoperable); MMI_gen 6588 (partly: configuration “ON”, mode OS); MMI_gen 6878 (partly: configuration “ON”, mode OS); MMI_gen 6453;
            */
            // Call generic Check Results Method
            DmiExpectedResults
                .DMI_displays_the_message_ATP_Down_Alarm_with_sound_alarm_Verify_the_following_information_The_objects_below_are_not_displayed_on_DMI_White_Basic_speed_HookMedium_grey_basic_speed_hookDistance_to_target_digitalRelease_Speed_Digital(this);


            /*
            Test Step 4
            Action: Re-establish communication between ETCS onboard and DMI (in 1 second).Note: Stopwatch is required for accuracy of test result
            Expected Result: DMI displays in OS mode, Level 1.Verify the following information,The objects below are displayed on DMI,White Basic speed HookMedium-grey basic speed hookDistance to target (digital)Release Speed Digital
            Test Step Comment: (1) MMI_gen 6898 (partly: configuration ‘ON”, mode OS), Information (paragraph 2) under MMI_gen 6898 (re-establish); MMI_gen 6589 (partly: configuration “ON”, mode OS); MMI_gen 6879 (partly: configuration “ON”, mode OS); Information under MMI_gen 6453; MMI_gen 6879 (partly: The Toggling Function's Default state shall be applied); MMI_gen 6589 (partly: The Toggling Function's Default state shall be applied); MMI_gen 6588 (partly: The Toggling Function's Default state shall be applied); MMI_gen 6878 (partly: The Toggling Function's Default state shall be applied);
            */
            // Call generic Action Method
            DmiActions
                .Re_establish_communication_between_ETCS_onboard_and_DMI_in_1_second_Note_Stopwatch_is_required_for_accuracy_of_test_result(this);


            /*
            Test Step 5
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}