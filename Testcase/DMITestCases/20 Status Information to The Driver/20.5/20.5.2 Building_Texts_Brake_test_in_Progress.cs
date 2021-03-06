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

// TODO This test case requires config file changes and other languages. Suggest to leave until later.

namespace Testcase.DMITestCases
{
    /// <summary>
    /// 20.5.2 Building Texts: Brake test in Progress!
    /// TC-ID: 15.4.2
    /// 
    /// This test case verifies that display texts shall be selected from one of character code and align with
    /// the currently active language
    /// 
    /// Tested Requirements:
    /// MMI_gen 3722;
    /// 
    /// Scenario:
    /// 1. Power on the system 
    /// 2. Verify the text message “Brake Test in Progress” shall not display when the character code language
    ///     does not match with the language selection
    /// 
    /// Used files:
    /// N/A
    /// </summary>
    public class TC_15_4_2_Adhesion_Factor : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // The system is powered OFF.
            // The default language is English
            // Set the following tags name in configuration file
            // (see the instruction in Appendix 1 and change configuration file to Language_mgr.xml)
            // Replace English text with Russian text
            // <ENG>Brake Test in Progress</ENG> to <ENG>Выполнение опробования тормозов</ENG>

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in SN mode, Level STM-ATB.

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint

            /*
            Test Step 1
            Action: Power on the system and activate cabin
            Expected Result: DMI displays the Driver ID window
            */
            // Call generic Action Method
            
            /*
            Test Step 2
            Action: Enter and confirm Driver ID. Then perform brake test
            Expected Result: DMI shall not display text message “Brake Test in Progress!” in any other languages
                            since the text is replaced with Russian character code language
            Test Step Comment: MMI_gen 3722 (partly:ETCS)
            */

            /*
            Test Step 3
            Action: Select ATB STM and complete Start of Mission
            Expected Result: DMI displays in SN mode, Level STM-ATB
            */

            /*
            Test Step 4
            Action: Press settings menu and start to perform brake test by pressing ‘Test’ button in the Brake window
            Expected Result: DMI shall not display text message “Brake Test in Progress!” in any other languages
                            since the text is replaced with Russian character code language
            Test Step Comment: MMI_gen 3722 (partly:NTC)
            */

            /*
            Test Step 5
            Action: End of test
            Expected Result: 
            */

            return GlobalTestResult;
        }
    }
}