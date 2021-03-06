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
    /// 27.7.3 Data view window for the text which longer than maximum width
    /// TC-ID: 22.7.3
    /// 
    /// This test case verifies the display of Data View Texts when the text is longer than the maximum width.
    /// 
    /// Tested Requirements:
    /// MMI_gen 7512; MMI_gen 7514;
    /// 
    /// Scenario:
    /// The ‘Data View’ window is opened and verify the display information.
    /// 
    /// Used files:
    /// N/A
    /// </summary>
    public class Data_view_window_for_the_text_which_longer_than_maximum_width : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // All value of Parameter ‘TR_OBU_TrainType’ is set to 2 (Flexible Train Data) in defaultValues_default.xml in OTE.Set the following information in language_mgr.xmlRevise wording from ‘PASS1’ to be ‘For Test Data View truncated by long text’Revise wording from ‘Train category’ to be ‘For Test Data View truncated by long text’SoM is performed in SR mode, Level 1.

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in SR mode, level 1.

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint


            /*
            Test Step 1
            Action: Press ‘Data view’ button
            Expected Result: Verify the following information,(1)   The label part of Data View item No.3 is changed to ‘For Test Data View truncated by long text’.  The text label which longer than the maximum width of label part is not display (truncated).(2)   The data part of Data View item No.3 is changed to ‘For Test Data View truncated by long text’.The data part is displayed as 2 lines.At the 2nd line, the text which longer than the maximum width of data part is not display (truncated)
            Test Step Comment: (1) MMI_gen 7512;(2) MMI_gen 7514;
            */
            // Call generic Action Method
            DmiActions.ShowInstruction(this, @"Press ‘Data view’ button");


            /*
            Test Step 2
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}