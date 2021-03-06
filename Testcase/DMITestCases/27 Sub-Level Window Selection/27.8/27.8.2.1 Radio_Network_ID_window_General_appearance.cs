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
    /// 27.8.2.1 Radio Network ID window: General appearance
    /// TC-ID: 22.8.2.1
    /// 
    /// This test case verifies the display of the ‘Radio Network ID’ window for touch screen technology that shall comply with [ERA-ERTMS] standard and [MMI-ETCS-gen].
    /// 
    /// Tested Requirements:
    /// MMI_gen 8047; MMI_gen 9448; MMI_gen 12139; MMI_gen 8045; MMI_gen 8046; MMI_gen 9447; MMI_gen 9449; MMI_gen 9981; MMI_gen 9465; MMI_gen 8044 (partly: half grid array, single input field, only data part, MMI_gen 5189 (partly: touch screen, MMI_gen 5944 (partly: touch screen), MMI_gen 4640 (partly: only data area), MMI_gen 4720, MMI_gen 4889 (partly: merge label and data), MMI_gen 4722 (partly: Table 12 <Close> button, Window title, Input field), MMI_gen 4637 (partly: Main-areas D and F), note under the MMI_gen 9412, MMI_gen 4912, MMI_gen 4678, MMI_gen 4913 (partly: MMI_gen 4384), MMI_gen 4682, MMI_gen 4681, MMI_gen 4684); MMI_gen 4392 (partly: [Close NA11], returning to the parent window, [Enter]); MMI_gen 4350; MMI_gen 4351; MMI_gen 4353; MMI_gen 9390 (partly: Radio Network ID window); MMI_gen 8864 (partly: Radio Network ID window);
    /// 
    /// Scenario:
    /// The test system is powered on and the cabin is inactive.Radio Network ID window in cabin inactive state is verified.After performed SoM until level 2 is selected and confirmed, the Radio Network ID window appearance is verified.The data entry functionality of the Radio Network ID window is verified.The revalidate data entry of the Radio Network IDwindow is verified.The updating of Network ID’s list refer to EVC-22 is verified.The window closure is verified.
    /// 
    /// Used files:
    /// 22_8_2_1.utt, 22_8_2_1_a.xml, 22_8_2_1_b.xml
    /// </summary>
    public class Radio_Network_ID_window_General_appearance : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // System is power on.

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in SB mode, Level 2

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint


            /*
            Test Step 1
            Action: Use the test script file 22_8_2_1_a.xml to send EVC-22 with,MMI_NID_WINDOW = 9MMI_N_NETWORKS = 2MMI_N_CAPTION_NETWORK[0] = 6MMI_X_CAPTION_NETWORK[0][0] = 71MMI_X_CAPTION_NETWORK[0] [1] = 83MMI_X_CAPTION_NETWORK[0] [2] = 77MMI_X_CAPTION_NETWORK[0] [3] = 82MMI_X_CAPTION_NETWORK[0] [4] = 45MMI_X_CAPTION_NETWORK[0] [5] = 65MMI_N_CAPTION_NETWORK[1] = 6MMI_X_CAPTION_NETWORK[1][0] = 71MMI_X_CAPTION_NETWORK[1][1] = 83MMI_X_CAPTION_NETWORK[1][2] = 77MMI_X_CAPTION_NETWORK[1][3] = 82MMI_X_CAPTION_NETWORK[1][4] = 45MMI_X_CAPTION_NETWORK[1][5] = 66
            Expected Result: Verify the following information,DMI does not display Radio Network ID window
            Test Step Comment: (1) MMI_gen 9448 (partly: NEGATIVE, inactive);
            */


            /*
            Test Step 2
            Action: Activate Cabin A
            Expected Result: DMI displays Driver ID window
            */
            // Call generic Action Method
            DmiActions.Activate_Cabin_1(this);
            // Call generic Check Results Method
            DmiExpectedResults.Driver_ID_window_displayed(this);


            /*
            Test Step 3
            Action: Use the test script file 22_8_2_1_b.xml to Send EVC-22 with,MMI_NID_WINDOW = 9MMI_N_NETWORKS = 0
            Expected Result: DMI still displays Driver ID window
            Test Step Comment: 1) MMI_gen 9448 (partly: NEGATIVE, MMI_N_NETWORKS = 0);
            */


            /*
            Test Step 4
            Action: Perform the following procedure,Enter Driver ID and perform brake test.Select and confirm Level 2.Press ‘Radio Network ID’ button
            Expected Result: Verify the following information,LayersThe layers of window on half-grid array are displayed as followsLayer 0: Main-Area D, F, G, Y and Z.Layer -1: A1, A2+A3*, A4, B*, C1, C2+C3+C4*, C5, C6, C7, C8, C9, E1, E2, E3, E4, E5-E9*Layer -2: B3, B4, B5, B6, B7Note: ‘*’ symbol is mean that specified areas are drawn as one area.Data Entry windowThe window title is displayed with text “Radio network ID”.Verify that the Radio Network ID window is displayed in main area D, F and G as half-grid array.A data entry window is containing only one input field covers the Main area D, F and G.The following objects are displayed in Radio Network ID window. Enabled Close button (NA11)Window TitleInput FieldInput fieldThe input field is located in main area D and F.For a single input field, the window title is clearly explaining the topic of the input field. The Radio Network ID window is displayed as a single input field with only the data part.KeyboardThe keyboard associated to the Radio Network ID window is displayed as dedicated keyboard.The keyboard is presented below the area of input field.The list of Network ID buttons are corrected refer to received packet EVC-22 as follows,MMI_N_NETWORKS = number of labels (amount of keypad button).MMI_N_CAPTION_NETWORK [x] = number of character in each keypad button.MMI_X_CAPTION_NETWORK [y] = label of characters.Note:- X is index of button.- Y is index of character.The order of each button is displayed corresponse with received packet EVC-22.Packet ReceivingUse the log file to confirm that DMI received packet EVC-22 with variable MMI_NID_WINDOW = 9 and MMI_M_N_NETWORKS != 0.DMI displays Radio Network ID window.General property of windowThe Radio Network ID window is presented with objects, text messages and buttons which is the one of several levels and allocated to areas of DMI. All objects, text messages and buttons are presented within the same layer.The Default window is not covering the current window
            Test Step Comment: (1) MMI_gen 8044 (partly: MMI_gen 5189 (partly: touch screen), MMI_gen 5944 (partly: touch screen));(2) MMI_gen 8045;(3) MMI_gen 8044 (partly: half grid array);(4) MMI_gen 8044 (partly: MMI_gen 4640 (partly: only data area), MMI_gen 4720, MMI_gen 4889 (partly: merge label and data));(5) MMI_gen 8044 (party: MMI_gen 4722 (partly: Table 12 <Close> button, Window title, Input field)); MMI_gen 4392 (partly: [Close] NA11);(6) MMI_gen 8044 (partly: MMI_gen 4637 (partly: Main-areas D and F));(7) MMI_gen 8044 (partly: note under the MMI_gen 9412);(8) MMI_gen 8044 (partly: single input field, only data part);(9) MMI_gen 8047 (partly: keyboard); MMI_gen 8044 (partly: MMI_gen 4912);(10) MMI_gen 8044 (partly: MMI_gen 4678);(11) MMI_gen 9465; MMI_gen 8047 (partly: list of available); MMI_gen 9981; (12) MMI_gen 9448 (partly: EVC-22);(13) MMI_gen 9448 (partly: Open Radio Network ID window);(14) MMI_gen 4350;(15) MMI_gen 4351;(16) MMI_gen 4353;
            */


            /*
            Test Step 5
            Action: Press and hold the data key up
            Expected Result: Verify the following information,Sound ‘Click’ is played once.The state of button is changed to ‘Pressed’ and its immediately back to ‘Enabled’ state.Pressed key is displayed in an input field after pressing the button.The data value is displayed as black colour and the background of the data area is displayed as medium-grey colour
            Test Step Comment: (1) MMI_gen 8044 (partly: MMI_gen 4913, MMI_gen 4384 (partly: sound ‘Click’));(2) MMI_gen 8044 (partly: MMI_gen 4913, MMI_gen 4384 (partly: Change to state ‘Pressed’ and immediately back to state ‘Enabled’));   (3) MMI_gen 8044 (partly: MMI_gen 4913,MMI_gen 4384 (partly: ETCS-MMI’s function associated to the button));(4) MMI_gen 8044 (partly: MMI_gen 4651, MMI_gen 4642, MMI_gen 4679);
            */


            /*
            Test Step 6
            Action: Release the pressed button
            Expected Result: Verify the following information,The state of button is changed to ‘Enabled’ state.An input field is used to enter the Radio Network ID.The data value of the input field is aligned to the left of the data area
            Test Step Comment: (1) MMI_gen 8044 (partly: MMI_gen 4913, MMI_gen 4384 (partly: ETCS-MMI’s function associated to the button));(2) MMI_gen 8044 (partly: MMI_gen 4634); MMI_gen 8046 (partly: entry);(3) MMI_gen 8044 (partly: MMI_gen 4647 (partly: left aligned));
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Release the pressed button");


            /*
            Test Step 7
            Action: Press and hold an input field
            Expected Result: Verify the following information,(1)    The state of an input field is changed to ‘Pressed’, the border of button is removed
            Test Step Comment: (1) MMI_gen 9390 (partly: Radio Network ID window);
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press and hold an input field");
            // Call generic Check Results Method
            DmiExpectedResults
                .Verify_the_following_information_1_The_state_of_an_input_field_is_changed_to_Pressed_the_border_of_button_is_removed(this);


            /*
            Test Step 8
            Action: Slide out an input field
            Expected Result: Verify the following information,(1)    The state of an input field is changed to ‘Enabled, the border of button is shown without a sound
            Test Step Comment: (1) MMI_gen 9390 (partly: Radio Network ID window);
            */
            // Call generic Action Method
            DmiActions.Slide_out_an_input_field(this);
            // Call generic Check Results Method
            DmiExpectedResults
                .Verify_the_following_information_1_The_state_of_an_input_field_is_changed_to_Enabled_the_border_of_button_is_shown_without_a_sound(this);


            /*
            Test Step 9
            Action: Slide back into an input field
            Expected Result: Verify the following information,(1)    The state of an input field is changed to ‘Pressed’, the border of button is removed
            Test Step Comment: (1) MMI_gen 9390 (partly: Radio Network ID window);
            */
            // Call generic Action Method
            DmiActions.Slide_back_into_an_input_field(this);
            // Call generic Check Results Method
            DmiExpectedResults
                .Verify_the_following_information_1_The_state_of_an_input_field_is_changed_to_Pressed_the_border_of_button_is_removed(this);


            /*
            Test Step 10
            Action: Release the pressed area
            Expected Result: Verify the following information,DMI closes the Radio Network ID window.Use the log file to confirm that DMI sends EVC-112 with the following variables,MMI_M_BUTTONS = 254MMI_N_DATA_ELEMENTS = 1MMI_M_NID_DATA = 3MMI_NID_MN = index of selected network ID (refer to EVC-22 from previous step, the 1st index is start with 0)
            Test Step Comment: (1) MMI_gen 9449 (partly: closed); MMI_gen 8044 (partly: MMI_gen 4682, MMI_gen 4681 (partly: accept the entered value), MMI_gen 4684 (partly: terminated));(2) MMI_gen 9449 (partly: EVC-112); MI_gen 8044 (partly: MMI_gen 4682, MMI_gen 4681 (partly: accept the entered value)); MMI_gen 4392 (partly: [Enter], touch screen); MMI_gen 9390 (partly: Radio Network ID window); MMI_gen 8864 (partly: the value stored onboard);
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Release the pressed area");
            // Call generic Check Results Method
            DmiExpectedResults
                .Verify_the_following_information_DMI_closes_the_Radio_Network_ID_window_Use_the_log_file_to_confirm_that_DMI_sends_EVC_112_with_the_following_variables_MMI_M_BUTTONS_254MMI_N_DATA_ELEMENTS_1MMI_M_NID_DATA_3MMI_NID_MN_index_of_selected_network_ID_refer_to_EVC_22_from_previous_step_the_1st_index_is_start_with_0(this);


            /*
            Test Step 11
            Action: Press ‘Radio Network ID’ button
            Expected Result: Verify the following information,An input field is used to revalidation the Radio Network ID
            Test Step Comment: (1) MMI_gen 8046 (partly: revalidation);
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press ‘Radio Network ID’ button");


            /*
            Test Step 12
            Action: Confirm the current data without re-entry Radio Network ID
            Expected Result: Verify the following information,DMI closes the Radio Network ID window.Use the log file to confirm that DMI sends EVC-112 with the following variables,MMI_M_BUTTONS = 254MMI_N_DATA_ELEMENTS = 1MMI_M_NID_DATA = 3MMI_NID_MN = index of selected network ID (refer to EVC-22 from previous step, the 1st index is start with 0)
            Test Step Comment: (1) MMI_gen 9449 (partly: closed); MMI_gen 8044 (partly: MMI_gen 4682, MMI_gen 4681 (partly: accept the entered value), MMI_gen 4684 (partly: terminated));(2) MMI_gen 9449 (partly: EVC-112); MMI_gen 8046 (partly: revalidation); MMI_gen 8044 (partly: MMI_gen 4682, MMI_gen 4681 (partly: accept the entered value));
            */
            // Call generic Check Results Method
            DmiExpectedResults
                .Verify_the_following_information_DMI_closes_the_Radio_Network_ID_window_Use_the_log_file_to_confirm_that_DMI_sends_EVC_112_with_the_following_variables_MMI_M_BUTTONS_254MMI_N_DATA_ELEMENTS_1MMI_M_NID_DATA_3MMI_NID_MN_index_of_selected_network_ID_refer_to_EVC_22_from_previous_step_the_1st_index_is_start_with_0(this);


            /*
            Test Step 13
            Action: Perform the following procedure,Press ‘Radio Network ID’ button.Select the new Radio Network ID.Observe the new entered data on the input field
            Expected Result: Verify the following information,(1)    The current data value in the input field is displayed according to the new selection Radio Network ID
            Test Step Comment: (1) MMI_gen 8864 (partly: the value stored onboard is replaced by the new entered data);
            */


            /*
            Test Step 14
            Action: Confirm an entered data by pressing an input field
            Expected Result: Verify the following information,(1)   DMI closes the Radio Network ID  window
            Test Step Comment: (1) MMI_gen 4681 (partly: accept the entered value); MMI_gen 8864 (partly: driver accepts the data value by pressing the input field);
            */
            // Call generic Action Method
            DmiActions.Confirm_an_entered_data_by_pressing_an_input_field(this);


            /*
            Test Step 15
            Action: Press ‘Radio Network ID’ button
            Expected Result: Verify the following information,(1)    The value of input field is changed refer to selected Radio Network ID from step 13
            Test Step Comment: (1) MMI_gen 8864 (partly: Radio Network ID window); MMI_gen 4681 (partly: replace the current data value with the entered data value);
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press ‘Radio Network ID’ button");


            /*
            Test Step 16
            Action: Press ‘Close’ button
            Expected Result: DMI displays RBC contact window
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press ‘Close’ button");
            // Call generic Check Results Method
            DmiExpectedResults.DMI_displays_RBC_contact_window(this);


            /*
            Test Step 17
            Action: Press ‘Radio Network ID’ button.Then, use the test script file 22_8_2_1_a.xml to send EVC-22
            Expected Result: Verify the following information,The list of netowrk ID is updated refer to received packet EVC-22, there are only 2 buttons ‘GSM-A’ and ’GSM-B’ are displayed in Radio Network ID window
            Test Step Comment: (1) MMI_gen 9447;
            */


            /*
            Test Step 18
            Action: Press ‘Close’ button
            Expected Result: Verify the following information,Use the log file to confirm that DMI sent out packet EVC-101 with MMI_M_REQUEST = 61 (Exit RBC Network ID).DMI displays RBC contact window
            Test Step Comment: (1) MMI_gen 12139;(2) MMI_gen 4392 (partly: returning to the parent window);
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press ‘Close’ button");


            /*
            Test Step 19
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}