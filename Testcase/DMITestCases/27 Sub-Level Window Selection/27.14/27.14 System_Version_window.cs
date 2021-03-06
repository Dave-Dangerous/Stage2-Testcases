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
    /// 27.14 System Version window
    /// TC-ID: 22.14
    /// 
    /// This test case verifies the display information of System version window refer to chapter 6.5.6.4 of requirement specification document and verifies the value of displayed information is correct refer to received data from packet sending EVC-34.
    /// 
    /// Tested Requirements:
    /// MMI_gen 8767; MMI_gen 11987; MMI_gen 11988; MMI_gen 8768; MMI_gen 8766 (partly: MMI_gen 5338, MMI_gen 5383 (partly: MMI_gen 5944 (partly: touchscreen)), MMI_gen 5337, MMI_gen 5339, MMI_gen 5336 (partly: valid), MMI_gen 7510, MMI_gen 5306 (partly: Close button, Window title)); MMI_gen 4392 (partly: [Close] NA11, returning to the parent window); MMI_gen 4350; MMI_gen 4351; MMI_gen 4353;
    /// 
    /// Scenario:
    /// The ‘System version’ window is opened.The ‘System version’ window is verified.Use the test script file to open System version window and verify the display information on screen.
    /// 
    /// Used files:
    /// 22_14.xml
    /// </summary>
    public class System_Version_window : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // Test system is powered ON.Cabin is activated.Settings window is opened.

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in SB mode, level 1

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint


            /*
            Test Step 1
            Action: Press ‘System version’ button
            Expected Result: Verify the following information,The System version window is displayed.Use the log file to confirm that DMI received packet EVC-34.Data View WindowThe Data view window is covered in main area D, F and G.LayersThe level of layers in each area of window as follows,Layer 0: Area D, F, G, E10, E11, Z, YLayer -1: Area A1, (A2+A3)*, A4, B*, C1, (C2+C3+C4)*, C5, C6, C7, C8, C9, E1, E2, E3, E4, (E5-E9)*.Layer -2: Area B3, B4, B5, B6 and B7.LabelThe data view text is composed of a Label Part and Data Part. The labels of data view items are right aligned.The data of data view items are left aligned.Data view text colour is grey.The window title is displayed with text ‘System version’.Data View ItemsDMI displays the following information respectively:Operated system versionThe following objects are displayed in Data View window Enabled Close button (NA11)Window titleGeneral property of windowThe System version window is presented with objects, text messages and buttons which is the one of several levels and allocated to areas of DMI.All objects, text messages and buttons are presented within the same layer.The Default window is not displayed and covered the current window
            Test Step Comment: (1) MMI_gen 11987 (partly: open);     (2) MMI_gen 11987 (partly: EVC-34);(3) MMI_gen 8766 (partly: MMI_gen 5338);  (4) MMI_gen 8766 (partly: MMI_gen 5383 (partly: MMI_gen 5944 (partly: touchscreen)));(5) MMI_gen 8766 (partly: MMI_gen 5335);  (6) MMI_gen 8766 (partly: MMI_gen 5340 (partly: right aligned));  (7) MMI_gen 8766 (partly: MMI_gen 5342 (partly: left aligned));  (8) MMI_gen 8766 (partly: MMI_gen 5337);  (9) MMI_gen 8767; (10) MMI_gen 8768;(11) MMI_gen 8766 (partly: MMI_gen 5306 (partly: Close button, Window title)); MMI_gen 4392 (partly: [Close] NA11);(12) MMI_gen 4350;(13) MMI_gen 4351;(14) MMI_gen 4353;
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press ‘System version’ button");


            /*
            Test Step 2
            Action: Use the test script file 22_14.xml  to send EVC-34 with MMI_M_OPERATED_SYSTEM_VERSION = 65535
            Expected Result: Verify the following information,InformationThe data view is display a following information correctly refer to received packet informationOperated system version = 255.255
            Test Step Comment: (1) MMI_gen 11988; MMI_gen 8766 (partly: MMI_gen 5336 (partly: valid));  
            */


            /*
            Test Step 3
            Action: Send EVC-34 with MMI_M_OPERATED_SYSTEM_VERSION = 0
            Expected Result: Verify the following information,InformationThe data view is displayed a following information correctly refer to received packet informationOperated system version = 0.0
            Test Step Comment: (1) MMI_gen 11988; MMI_gen 8766 (partly: MMI_gen 5336 (partly: valid));  
            */


            /*
            Test Step 4
            Action: Send EVC-34 with MMI_M_OPERATED_SYSTEM_VERSION = 28,638
            Expected Result: Verify the following information,InformationThe data view is display a following information correctly refer to received packet informationOperated system version = 111.222
            Test Step Comment: (1) MMI_gen 11988; MMI_gen 8766 (partly: MMI_gen 5336 (partly: valid));  
            */


            /*
            Test Step 5
            Action: Press the ‘Close’ button
            Expected Result: Verify the following information, (1)   DMI displays Setting window
            Test Step Comment: (1) MMI_gen 4392 (partly: returning to the parent window);
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press the ‘Close’ button");
            // Call generic Check Results Method
            DmiExpectedResults.Verify_the_following_information_1_DMI_displays_Setting_window(this);


            /*
            Test Step 6
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}