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
    /// 27.19 Language Window
    /// TC-ID: 22.19
    /// 
    /// This test case verifies the display of the ‘Language’ window on DMI that shall comply with [ERA-ERTMS] standard and [MMI-ETCS-gen].
    /// 
    /// Tested Requirements:
    /// MMI_gen 8065; MMI_gen 8066; MMI_gen 11286; MMI_gen 8067; MMI_gen 8064 (partly: half grid array, single input field, only data part, MMI_gen 5189 (partly: touch screen), MMI_gen 5944 (partly: touch screen), MMI_gen 4640 (partly: only data area), MMI_gen 4679, MMI_gen 4720, MMI_gen 4889 (partly: merge label and data), MMI_gen 4722 (partly: Table 12 <Close> button, Window title, Input field), MMI_gen 4637 (partly: Main-areas D and F), note under the MMI_gen 9412, MMI_gen 4912, MMI_gen 4678, MMI_gen 4913 (partly: MMI_gen 4384), MMI_gen 4634, MMI_gen 4651, MMI_gen 4682, MMI_gen 4681, MMI_gen 4647 (partly: left aligned), MMI_gen 4684 (partly: terminated)); MMI_gen 4392 (partly: [Close] NA11, returning to the parent window, [Enter], touch screen); MMI_gen 4350; MMI_gen 4351; MMI_gen 4353; MMI_gen 9390 (partly: Language window);
    /// 
    /// Scenario:
    /// Verify the Language window entered from Settings window.The Down-type button on keypad is verified.The data entry functionality of the Language window is verified.The revalidate data entry of the Language window is verified.
    /// 
    /// Used files:
    /// N/A
    /// </summary>
    public class Language_Window : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // Test system is powered onCabin is activeSettings window is opened.

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
            Action: Press ‘Language’ button
            Expected Result: DMI displays the Language window on the right half part of the window as shown in figure belowLayersThe layers of window on half-grid array is displayed as followsLayer 0: Main-Area D, F, G, Y and Z.Layer -1: A1, A2+A3*, A4, B*, C1, C2+C3+C4*, C5, C6, C7, C8, C9, E1, E2, E3, E4, E5-E9*Layer -2: B3, B4, B5, B6, B7Note: ‘*’ symbol is mean that specified areas are drawn as one area.Data Entry windowThe window title is displayed with text “Language”.Verify that the Language window is displayed in main area D, F and G as half-grid array.A data entry window is containing only one input field covers the Main area D, F and G.The following objects are displayed in Language window. Enabled Close button (NA11)Window TitleInput FieldInput fieldThe input field is located in main area D and F.For a single input field, the window title is clearly explaining the topic of the input field. The Language window is displayed as a single input field with only the data part.KeyboardThe keyboard associated to the Language window is displayed as dedicated keyboard and displayed with the possible language(s) in its (their) own language for driver selection.The keyboard is presented below the area of input field.General property of windowThe Language window is presented with objects and buttons which is the one of several levels and allocated to areas of DMIAll objects, text messages and buttons are presented within the same layer.The Default window is not displayed and covered the current window
            Test Step Comment: (1) MMI_gen 8064 (partly: MMI_gen 5189 (partly: touch screen), MMI_gen 5944 (partly: touch screen));(2) MMI_gen 8065;(3) MMI_gen 8064 (partly: half grid array);(4) MMI_gen 8064 (partly: MMI_gen 4640 (partly: only data area), MMI_gen 4720, MMI_gen 4889 (partly: merge label and data));(5) MMI_gen 8064 (party: MMI_gen 4722 (partly: Table 12 <Close> button, Window title, Input field)); MMI_gen 4392 (partly: [Close] NA11);(6) MMI_gen 8064 (partly: MMI_gen 4637 (partly: Main-areas D and F));(7) MMI_gen 8064 (partly: note under the MMI_gen 9412);(8) MMI_gen 8064 (partly: single input field, only data part);(9) MMI_gen 8067; MMI_gen 8064 (partly: MMI_gen 4912);(10) MMI_gen 8064 (partly: MMI_gen 4678);(11) MMI_gen 4350;(12) MMI_gen 4351;(13) MMI_gen 4353;
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press ‘Language’ button");


            /*
            Test Step 2
            Action: Press and hold every buttons on the dedicate keyboard respectively
            Expected Result: Verify the following information,The value of input field is replaced by the pressed button.Sound ‘Click’ is played once.The state of button is changed to ‘Pressed’ and immediately back to ‘Enabled’ state.The Input Field displays the language associated to the data key according to the pressings in state ‘Pressed’.An input field is used to enter the Language.The data value is displayed as black colour and the background of the data area is displayed as medium-grey colour.The data value of the input field is aligned to the left of the data area
            Test Step Comment: (1) MMI_gen 8064 (partly: MMI_gen 4679); (2) MMI_gen 8064 (partly: MMI_gen 4913 (partly: MMI_gen 4384 (partly: sound ‘Click’)));(3) MMI_gen 8064 (partly: MMI_gen 4913 (partly: MMI_gen 4384 (partly: Change to state ‘Pressed’ and immediately back to state ‘Enabled’)));   (4) MMI_gen 8064 (partly: MMI_gen 4913);                      (5) MMI_gen 8066 (partly: entry); MMI_gen 8064 (partly: MMI_gen 4634);(6) MMI_gen 8064 (partly: MMI_gen 4651);(7) MMI_gen 8064 (partly: MMI_gen 4647 (partly: left aligned));
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press and hold every buttons on the dedicate keyboard respectively");


            /*
            Test Step 3
            Action: Released the pressed button
            Expected Result: Verify the following information, The state of button is changed to ‘Enabled’
            Test Step Comment: (1) MMI_gen 8064 (partly: MMI_gen 4913 (partly: MMI_gen 4384 (partly: ETCS-MMI’s function associated to the button)));
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Released the pressed button");
            // Call generic Check Results Method
            DmiExpectedResults.Verify_the_following_information_The_state_of_button_is_changed_to_Enabled(this);


            /*
            Test Step 4
            Action: Select ‘Deutsch’ button.Then, press and hold an input field
            Expected Result: Verify the following information,(1)    The state of an input field is changed to ‘Pressed’, the border of button is removed
            Test Step Comment: (1) MMI_gen 9390 (partly: Language window);
            */
            // Call generic Check Results Method
            DmiExpectedResults
                .Verify_the_following_information_1_The_state_of_an_input_field_is_changed_to_Pressed_the_border_of_button_is_removed(this);


            /*
            Test Step 5
            Action: Slide out an input field
            Expected Result: Verify the following information,(1)    The state of an input field is changed to ‘Enabled, the border of button is shown without a sound
            Test Step Comment: (1) MMI_gen 9390 (partly: Language window);
            */
            // Call generic Action Method
            DmiActions.Slide_out_an_input_field(this);
            // Call generic Check Results Method
            DmiExpectedResults
                .Verify_the_following_information_1_The_state_of_an_input_field_is_changed_to_Enabled_the_border_of_button_is_shown_without_a_sound(this);


            /*
            Test Step 6
            Action: Slide back into an input field
            Expected Result: Verify the following information,(1)    The state of an input field is changed to ‘Pressed’, the border of button is removed
            Test Step Comment: (1) MMI_gen 9390 (partly: Language window);
            */
            // Call generic Action Method
            DmiActions.Slide_back_into_an_input_field(this);
            // Call generic Check Results Method
            DmiExpectedResults
                .Verify_the_following_information_1_The_state_of_an_input_field_is_changed_to_Pressed_the_border_of_button_is_removed(this);


            /*
            Test Step 7
            Action: Release the pressed area
            Expected Result: Verify the following information,Use the log file to confirm that DMI sends out the packet [MMI_NEW_LANGUAGE (EVC-122)] with variable [MMI_NEW_LANGUAGE (EVC-122).MMI_NID_LANGUAGE].Note: The correctness of value cannot verify because it’s not specify in the [GenVSIS].The language is updated, DMI displays all texts and button labeled as Deustch language.(2)   An input field is used to enter the Language
            Test Step Comment: (1) MMI_gen 11286;              MMI_gen 8064 (partly: MMI_gen 4682, MMI_gen 4684 (partly: terminated)); MMI_gen 9390 (partly: Language window);                         (2) MMI_gen 8064 (partly: MMI_gen 4681);                    
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Release the pressed area");


            /*
            Test Step 8
            Action: Perform the following procedure, Press ‘Language’ button.Select and confirm ‘English’ language
            Expected Result: Verify the following information,Use the log file to confirm that DMI sends out the packet [MMI_NEW_LANGUAGE (EVC-122)] with variable [MMI_NEW_LANGUAGE (EVC-122).MMI_NID_LANGUAGE].Note: The correctness of value cannot verify because it’s not specify in the [GenVSIS].The language is updated, DMI displays all texts and button labeled as English language
            Test Step Comment: (1) MMI_gen 11286;              MMI_gen 8064 (partly: MMI_gen 4682); MMI_gen 4392 (partly: [Enter], touch screen);                           (2) MMI_gen 8064 (partly: MMI_gen 4681);
            */


            /*
            Test Step 9
            Action: Perform the following procedure, Press ‘Language’ button.Confirm the current data without re-entry by press at input field
            Expected Result: Verify the following information,Use the log file to confirm that DMI sends out the packet [MMI_NEW_LANGUAGE (EVC-122)] with the value of variable  [MMI_NEW_LANGUAGE (EVC-122).MMI_NID_LANGUAGE] is same as action step 8.Note: The correctness of value cannot verify because it’s not specify in the [GenVSIS].The language is still same, DMI displays all texts and button labeled as English language
            Test Step Comment: (1) MMI_gen 11286;              MMI_gen 8064 (partly: MMI_gen 4682);                     MMI_gen 8066 (partly: revalidation);                         (2) MMI_gen 8064 (partly: MMI_gen 4681 (partly: accept the entered value));
            */


            /*
            Test Step 10
            Action: Press ‘Language’ buttonThen, press the ‘Close’ button
            Expected Result: Verify the following information,(1)   DMI displays Settings window
            Test Step Comment: (1) MMI_gen 4392 (partly: returning to the parent window);
            */
            // Call generic Check Results Method
            DmiExpectedResults.Verify_the_following_information_1_DMI_displays_Settings_window(this);


            /*
            Test Step 11
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}