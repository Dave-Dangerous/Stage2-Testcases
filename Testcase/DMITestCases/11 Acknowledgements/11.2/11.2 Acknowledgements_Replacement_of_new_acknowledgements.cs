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
    /// 11.2 Acknowledgements: Replacement of new acknowledgements
    /// TC-ID: 6.2
    /// 
    /// This test case verifies the display of an acknowledgement list refer to received the multiple packets EVC-8 which have the same index number.
    /// 
    /// Tested Requirements:
    /// MMI_gen 7036; MMI_gen 4499 (partly: symbol step back as non-acknowledgementable); MMI_gen 11470 (partly: Bit # 24);
    /// 
    /// Scenario:
    /// 1.Use the test script file to send a packet information EVC-
    /// 8.Then, press an acknowledgement in specify area and verify the display of acknowledgement on DMI.
    /// 
    /// Used files:
    /// 6_2_a.xml, 6_2_b.xml, 6_2_c.xml
    /// </summary>
    public class Acknowledgements_Replacement_of_new_acknowledgements : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // System is powered onCabin is activatedPerform SoM until level 1 is selected and confirmedMain window is closed.
            
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
            Action: Use the test script file 6_2_a.xml to send EVC-8 with,MMI_Q_TEXT = 280MMI_Q_TEXT_CRITERIA = 1MMI_I_TEXT = 1
            Expected Result: DMI displays the text message ‘Emergency stop’ in sub-area E5 with yellow flashing frame
            */
            
            
            /*
            Test Step 2
            Action: (Continue from step 1)Send EVC-8 with,MMI_Q_TEXT = 1MMI_Q_TEXT_CRITERIA = 1MMI_I_TEXT = 1
            Expected Result: Verify the following information,(1)   DMI displays the text message 'Acknowledgement' in sub-area E5 with yellow flashing frame
            Test Step Comment: (1) MMI_gen 7036 (partly: immediately replaced in the foreground);
            */
            
            
            /*
            Test Step 3
            Action: Press an acknowledgement in sub-area E5
            Expected Result: The acknowledgement is remove, no message display on sub-area E5.(1)    Use the log file to confirm that DMI sends out packet [MMI_DRIVER_ACTION (EVC-152)] with the value of variable MMI_M_DRIVER_ACTION refer to sequence below,a)   MMI_M_DRIVER_ACTION = 24 (Ack of Fixed Text information)
            Test Step Comment: (1) MMI_gen 11470 (partly: Bit # 24);
            */
            
            
            /*
            Test Step 4
            Action: Use the test script file 6_2_b.xml to send EVC-8 with,MMI_Q_TEXT = 1MMI_Q_TEXT_CRITERIA = 1MMI_I_TEXT = 1
            Expected Result: DMI displays the text message 'Acknowledgement' in sub-area E5 with yellow flashing frame
            */
            
            
            /*
            Test Step 5
            Action: (Continue from step 4)Send EVC-8 with,MMI_Q_TEXT = 260MMI_Q_TEXT_CRITERIA = 0MMI_I_TEXT = 2
            Expected Result: The acknowledgement in sub-area E5 is disappeared, DMI displays ST01 symbol with yellow flashing frame in sub-area C9 instead
            */
            
            
            /*
            Test Step 6
            Action: Use the test script file 6_2_c.xml to send EVC-8 with,MMI_Q_TEXT = 269MMI_Q_TEXT_CRITERIA = 1MMI_I_TEXT = 1
            Expected Result: Verify the following information,(1)    DMI still displays ST01 symbol in sub-area C9
            Test Step Comment: (1) MMI_gen 7036 (partly: focus shall not move);
            */
            
            
            /*
            Test Step 7
            Action: Press an acknowledgement in sub-area C9
            Expected Result: Verify the following information,(1)  There is only the yellow flashing frame around ST01 symbol is removed.(2)  DMI displays text message ‘Runaway movement’ with yellow flashing frame in sub-area E5
            Test Step Comment: (1) MMI_gen 4499 (partly: symbol step back as non-acknowledgementable);(2) MMI_gen 7036 (partly: NEGATIVE, replaced in the background);
            */
            
            
            /*
            Test Step 8
            Action: End of test
            Expected Result: 
            */
            

            return GlobalTestResult;
        }
    }
}
