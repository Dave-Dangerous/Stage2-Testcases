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
    /// 27.6.2 Maintenance window
    /// TC-ID: 22.6.2
    /// 
    /// This test case verifies a display of Maintenance window which related to ‘Wheel diameter’ and ‘Radar’ button.
    /// 
    /// Tested Requirements:
    /// MMI_gen 11724; MMI_gen 11743 (partly: MMI_gen 7909, MMI_gen 4556, MMI_gen 4557, MMI_gen 4381, MMI_gen 4382, MMI_gen 4630 (partly: MMI gen 5944 (partly: touch screen))); MMI_gen 11744; MMI_gen 11745; MMI_gen 11746; MMI_gen 11747; MMI_gen 968; MMI_gen 9512; MMI_gen 4360 (partly: window title); MMI_gen 4392 (partly: [Close] NA11, returning to the parent window); MMI_gen 4350; MMI_gen 4351; MMI_gen 4353;
    /// 
    /// Scenario:
    /// The concerned buttons in the ‘Maintenance’ window are verified by the following actions:Press the button and holdSlide the button out with force appliedSlide the button back with force appliedRelease the buttonUse different script files to force different situations of sending of EVC-
    /// 30.Then, verify the effect on ‘Maintenance’, ‘Wheel diameter’ and ‘Radar’ button.The Maintenance window appearance is verified.The Up-Type button of ‘Wheel diameter’, ‘Radar’ and ‘Close’ buttons are verified.
    /// 
    /// Used files:
    /// 22_6_2_a.xml, 22_6_2_b.xml, 22_6_2_c.xml, 22_6_2_d.xml
    /// </summary>
    public class Maintenance_window : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // Test system is powered onCabin is active‘Settings’ button is pressed after cabin activation.

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in SB mode

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint


            /*
            Test Step 1
            Action: Use test script file 22_6_2_a.xml to disable wheel diameter and doppler by sending EVC-30 with,MMI_NID_WINDOW = 4MMI_Q_REQUEST_ENABLE_64 (#29) = 0MMI_Q_REQUEST_ENABLE_64 (#30) = 0
            Expected Result: Verify the following information,DMI received the EVC-30 with [MMI_ENABLE_REQUEST (EVC-30).MMI_Q_REQUEST_ENABLE_64] (#29) = 0 in order to disable wheel diameter.DMI received the EVC-30 with [MMI_ENABLE_REQUEST (EVC-30).MMI_Q_REQUEST_ENABLE_64] (#30) = 0 in order to disable doppler.The ‘Maintenance’ button is disabled
            Test Step Comment: (1) MMI_gen 11746 (partly: disable wheel diameter);(2) MMI_gen 11746 (partly: disable doppler);(3) MMI_gen 11724;
            */


            /*
            Test Step 2
            Action: Use test script file 22_6_2_b.xml to enable wheel diameter by sending EVC-30 with,MMI_NID_WINDOW = 4MMI_Q_REQUEST_ENABLE_64 (#29) = 1MMI_Q_REQUEST_ENABLE_64 (#30) = 0
            Expected Result: Verify the following information, DMI received the EVC-30 with [MMI_ENABLE_REQUEST (EVC-30).MMI_Q_REQUEST_ENABLE_64] (#29) = 1 in order to enable wheel diameter.DMI received the EVC-30 with [MMI_ENABLE_REQUEST (EVC-30).MMI_Q_REQUEST_ENABLE_64] (#30) = 0 in order to disable doppler.The ‘Maintenance’ button is enabled
            Test Step Comment: (1) MMI_gen 11746 (partly: enable wheel diameter);(2) MMI_gen 11746 (partly: disable doppler);(3) MMI_gen 11724;
            */


            /*
            Test Step 3
            Action: Perform the following procedure,Press ‘Maintenance’ button.Enter the Maintenance window by entering the password same as a value in tag ‘PASS_CODE_MTN’ of the configuration file and confirming the password
            Expected Result: Verify the following information,The Wheel diameter button is enabled.The Radar button is disabled
            Test Step Comment: (1) MMI_gen 11746 (partly: enable wheel diameter);(2) MMI_gen 11746 (partly: disable doppler);
            */
            // Call generic Action Method
            DmiActions
                .Perform_the_following_procedure_Press_Maintenance_button_Enter_the_Maintenance_window_by_entering_the_password_same_as_a_value_in_tag_PASS_CODE_MTN_of_the_configuration_file_and_confirming_the_password(this);


            /*
            Test Step 4
            Action: Perform the following procedure,Return to the Setting window by pressing Close’ button.Use test script file 22_6_2_a.xml to disable wheel diameter and doppler by sending EVC-30 with,MMI_NID_WINDOW = 4MMI_Q_REQUEST_ENABLE_64 (#29) = 0MMI_Q_REQUEST_ENABLE_64 (#30) = 0
            Expected Result: The ‘Maintenance’ button is disabled
            */
            // Call generic Action Method
            DmiActions
                .Perform_the_following_procedure_Return_to_the_Setting_window_by_pressing_Close_button_Use_test_script_file_22_6_2_a_xml_to_disable_wheel_diameter_and_doppler_by_sending_EVC_30_with_MMI_NID_WINDOW_4MMI_Q_REQUEST_ENABLE_64_29_0MMI_Q_REQUEST_ENABLE_64_30_0(this);
            // Call generic Check Results Method
            DmiExpectedResults.The_Maintenance_button_is_disabled(this);


            /*
            Test Step 5
            Action: Use test script file 22_6_2_c.xml to enable doppler by sendingSend EVC-30 with,MMI_NID_WINDOW = 4MMI_Q_REQUEST_ENABLE_64 (#29) = 0MMI_Q_REQUEST_ENABLE_64 (#30) = 1
            Expected Result: Verify the following information,DMI received the EVC-30 with [MMI_ENABLE_REQUEST (EVC-30).MMI_Q_REQUEST_ENABLE_64] (#29) = 0 in order to disable wheel diameter.DMI received the EVC-30 with [MMI_ENABLE_REQUEST (EVC-30).MMI_Q_REQUEST_ENABLE_64] (#30) = 1 in order to enable doppler.The ‘Maintenance’ button is enabled
            Test Step Comment: (1) MMI_gen 11746 (partly: disable wheel diameter);(2) MMI_gen 11746 (partly: enable doppler);(3) MMI_gen 11724;
            */


            /*
            Test Step 6
            Action: Perform the following procedure,Press ‘Maintenance’ button.Enter the Maintenance window by entering the password same as a value in tag ‘PASS_CODE_MTN’ of the configuration file and confirming the password
            Expected Result: Verify the following information,The Wheel diameter button is disabled.The Radar button is enabled
            Test Step Comment: (1) MMI_gen 11746 (partly: disable wheel diameter);(2) MMI_gen 11746 (partly: enable doppler);          
            */
            // Call generic Action Method
            DmiActions
                .Perform_the_following_procedure_Press_Maintenance_button_Enter_the_Maintenance_window_by_entering_the_password_same_as_a_value_in_tag_PASS_CODE_MTN_of_the_configuration_file_and_confirming_the_password(this);


            /*
            Test Step 7
            Action: Perform the following procedure,Return to the Setting window by pressing Close’ button.Use test script file 22_6_2_a.xml to disable wheel diameter and doppler by sending EVC-30 with,MMI_NID_WINDOW = 4MMI_Q_REQUEST_ENABLE_64 (#29) = 0MMI_Q_REQUEST_ENABLE_64 (#30) = 0
            Expected Result: The ‘Maintenance’ button is disabled
            */
            // Call generic Action Method
            DmiActions
                .Perform_the_following_procedure_Return_to_the_Setting_window_by_pressing_Close_button_Use_test_script_file_22_6_2_a_xml_to_disable_wheel_diameter_and_doppler_by_sending_EVC_30_with_MMI_NID_WINDOW_4MMI_Q_REQUEST_ENABLE_64_29_0MMI_Q_REQUEST_ENABLE_64_30_0(this);
            // Call generic Check Results Method
            DmiExpectedResults.The_Maintenance_button_is_disabled(this);


            /*
            Test Step 8
            Action: Use test script file 22_6_2_d.xml to enable wheel diameter and doppler by sending EVC-30 with,MMI_NID_WINDOW = 4MMI_Q_REQUEST_ENABLE_64 (#29) = 1MMI_Q_REQUEST_ENABLE_64 (#30) = 1
            Expected Result: Verify the following information,DMI received the EVC-30 with [MMI_ENABLE_REQUEST (EVC-30).MMI_Q_REQUEST_ENABLE_64] (#29) = 1 in order to enable wheel diameter.DMI received the EVC-30 with [MMI_ENABLE_REQUEST (EVC-30).MMI_Q_REQUEST_ENABLE_64] (#30) = 1 in order to enabled doppler.The ‘Maintenance’ button is enabled
            Test Step Comment: (1) MMI_gen 11746 (partly: enable wheel diameter);(2) MMI_gen 11746 (partly: enable doppler);(3) MMI_gen 11724;
            */


            /*
            Test Step 9
            Action: Perform the following procedures,Press ‘Maintenance’ button.Enter the Maintenance window by entering the password same as a value in tag ‘PASS_CODE_MTN’ of the configuration file and confirming the password
            Expected Result: Verify the following information,Menu windowThe window title is ‘Maintenance’.The Maintenance window is in the D, F and G area.The following objects are display in Maintenance window. Enabled Close button (NA11)Window TitleButton 1 with label ‘Wheel diameter’Button 2 with label ‘Radar’Note: See the position of buttons in picture below,The state of each button in Brake window are displayed correctly as follows,Wheel diameter = EnableRadar = EnableLayersThe level of layers in each area of window as follows,Layer 0: Area D, F, G, E10, E11, Y, and ZLayer -1: Area A1, (A2+A3)*, A4, B*, C1, (C2+C3+C4)*, C5, C6, C7, C8, C9, E1, E2, E3, E4, (E5-E9)*.Layer -2: Area B3, B4, B5, B6 and B7.Note: ‘*’ symbol is mean that specified area are drawn as one area.General property of windowThe Maintenance window is presented with objects and buttons which is the one of several levels and allocated to areas of DMI. All objects, text messages and buttons are presented within the same layer.The Default window is not displayed and covered the current window
            Test Step Comment: (1) MMI_gen 11744; MMI_gen 4360 (partly: window title);(2) MMI_gen 11743 (partly: MMI_gen 7909);(3) MMI_gen 11743 (MMI_gen 4556 (partly: Close button, Window Title, Button 1, Button 2)); MMI_gen 11745; MMI_gen 4392 (partly: [Close] NA11);(4) MMI_gen 11746;(5) MMI_gen 11743 (partly: MMI_gen 4630, MMI gen 5944 (partly: touch screen));        (6) MMI_gen 4350;(7) MMI_gen 4351;(8) MMI_gen 4353;     
            */


            /*
            Test Step 10
            Action: Press and hold ‘Wheel diameter’ button
            Expected Result: Verify the following information,The sound ‘Click’ played once.The ‘Wheel diameter’ button is shown as pressed state, the border of button is removed
            Test Step Comment: (1) MMI_gen 11743 (partly: MMI_gen 4381 (partly: the sound for Up-Type button)); MMI_gen 9512; MMI_gen 968;(2) MMI_gen 11743 (partly: partly: MMI_gen 4557 (partly: button ‘Wheel diameter’), MMI_gen 4381 (partly: change to state ‘Pressed’ as long as remain actuated)); MMI_gen 4375;
            */


            /*
            Test Step 11
            Action: Slide out ‘Wheel diameter’ button
            Expected Result: The border of the button is shown (state ‘Enabled’) without a sound
            Test Step Comment: MMI_gen 11743 (partly: MMI_gen 4557 (partly: button ‘Wheel diameter’, MMI_gen 4382 (partly: state ‘Enabled’ when slide out with force applied, no sound))); MMI_gen 4374;
            */
            // Call generic Check Results Method
            DmiExpectedResults.The_border_of_the_button_is_shown_state_Enabled_without_a_sound(this);


            /*
            Test Step 12
            Action: Slide back into ‘Wheel diameter’ button
            Expected Result: The button is back to state ‘Pressed’ without a sound
            Test Step Comment: MMI_gen 11743 (partly: MMI_gen 4557 (partly: button ‘Wheel diameter’, MMI_gen 4382 (partly: state ‘Pressed’ when slide back, no sound))); MMI_gen 4375;
            */
            // Call generic Check Results Method
            DmiExpectedResults.The_button_is_back_to_state_Pressed_without_a_sound(this);


            /*
            Test Step 13
            Action: Release ‘Wheel diameter’ button
            Expected Result: Verify the following information,DMI displays Wheel diameter windowUse the log file to confirm that DMI sends out the packet [MMI_DRIVER_REQUEST (EVC-101)] with variable [MMI_DRIVER_REQUEST (EVC-101).MMI_M_REQUEST] = 53 (Change Wheel diameter)
            Test Step Comment: (1) MMI_gen 11743 (partly: MMI_gen 4557 (partly: button ‘Wheel diameter’, MMI_gen 4381 (partly: exit state ‘Pressed’, execute function associated to the button)));(2) MMI_gen 11747 (partly: wheel diameter);
            */


            /*
            Test Step 14
            Action: Press ‘Close’ button
            Expected Result: DMI displays the Maintenance window
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press ‘Close’ button");
            // Call generic Check Results Method
            DmiExpectedResults.DMI_displays_the_Maintenance_window(this);


            /*
            Test Step 15
            Action: Follow action step 10 – step 14 for ‘Radar’ button
            Expected Result: See the expected results of Step 10 – Step 14 and the following additional information,DMI displays Radar window refer to released button from action step 13.Use the log file to confirm that DMI sends out the packet [MMI_DRIVER_REQUEST (EVC-101)] with variable [MMI_DRIVER_REQUEST (EVC-101).MMI_M_REQUEST] = 52 (Change Radar)
            Test Step Comment: (1) MMI_gen 11743 (partly: MMI_gen 4557 (partly: button ‘Radar’));(2) MMI_gen 11747 (partly: Radar);
            */


            /*
            Test Step 16
            Action: Press ‘Close’ button
            Expected Result: Verify the following information, (1)   DMI displays Setting window
            Test Step Comment: (1) MMI_gen 4392 (partly: returning to the parent window);
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press ‘Close’ button");
            // Call generic Check Results Method
            DmiExpectedResults.Verify_the_following_information_1_DMI_displays_Setting_window(this);


            /*
            Test Step 17
            Action: Press the ‘Maintenance’ window.Then, follow action step 10 – step 13 ‘Close’ button
            Expected Result: See the expected results of Step 10 – Step 13 and the following additional information,DMI displays Settings window
            Test Step Comment: (1) MMI_gen 11743 (partly: MMI_gen 4557 (partly: button ‘Close’));
            */


            /*
            Test Step 18
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}