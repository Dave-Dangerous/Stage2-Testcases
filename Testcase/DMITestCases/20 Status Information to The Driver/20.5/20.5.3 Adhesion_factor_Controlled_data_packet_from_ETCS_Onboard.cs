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
    /// 20.5.3 Adhesion factor: Controlled data packet from ETCS Onboard
    /// TC-ID: 15.5.2
    /// 
    /// This test case verifies the display of the adhesion factor indication on DMI when the factor is activated by both driver and Trackside together, which the condition is complied with [MMI-ETCS-gen], [MMIIS] and [ERA-ERTMS] standard.
    /// 
    /// Tested Requirements:
    /// MMI_gen 7088; MMI_gen 600; MMI_gen 8435;
    /// 
    /// Scenario:
    /// Drive the train passes BG0 at position 100m: pkt 3 Q_NVDRIVER_ADHES=0 (to reset the value if it has been set)Drive the train passes BG1 at position 250m: pkt 3 Q_NVDRIVER_ADHES=1The adhesion factor indication is verified with the following events: (Redundant Case)Activate Slippery button at Adhesion window.The ‘Adhesion’ button is revoked when drive the train passes BG2 at position 600m: pkt 71 D_ADHESION=0, L_ADHESION=200, M_ADHESION=0 (Slippery)Drive the train passes length of reduced adhesion at 800m.Deactivates Slippery button.
    /// 
    /// Used files:
    /// 15_5_2.tdg
    /// </summary>
    public class Adhesion_factor_Controlled_data_packet_from_ETCS_Onboard : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // Test system is powered on.Activate Cain A.SoM is completed in SR mode, Level 1.

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
            Action: Driver drives the train forward passing BG1.Then, press ‘Special’ button
            Expected Result: DMI still displays in SR mode.Verify that ‘Adhesion’ button is enabled
            */
            // Call generic Check Results Method
            DmiExpectedResults.DMI_still_displays_in_SR_mode_Verify_that_Adhesion_button_is_enabled();


            /*
            Test Step 2
            Action: Press ‘Adhesion’ button.Then, press ‘Slippery rail’ button
            Expected Result: Verify the following information,Use the log file to confirm that DMI receives EVC-2 with variable MMI_M_ADHESION (#0) = 1, bit ‘Low Adhesion by Driver’ is set.DMI displays symbol ST02 in sub-area A4, by driver
            Test Step Comment: (1) MMI_gen 7088 (partly: EVC-2, ‘Low Adhesion by Driver’)(2) MMI_gen 111;     
            */


            /*
            Test Step 3
            Action: Drive the train forward passing BG2
            Expected Result: Verify the following information,Use the log file to confirm that DMI receives EVC-2 with variable MMI_M_ADHESION (#1) = 1, bit ‘Low Adhesion from Trackside’ is set.DMI displays symbol ST02 in sub-area A4
            Test Step Comment: (1) MMI_gen 7088 (partly: EVC-2, ‘Low Adhesion from Trackside’, ‘Low Adhesion by Driver’);(2) MMI_gen 111;
            */
            // Call generic Action Method
            DmiActions.Drive_the_train_forward_passing_BG2();
            // Call generic Check Results Method
            DmiExpectedResults
                .Verify_the_following_information_Use_the_log_file_to_confirm_that_DMI_receives_EVC_2_with_variable_MMI_M_ADHESION_1_1_bit_Low_Adhesion_from_Trackside_is_set_DMI_displays_symbol_ST02_in_sub_area_A4();


            /*
            Test Step 4
            Action: Drive the train forward
            Expected Result: Verify the following information,Use the log file to confirm that DMI receives EVC-2 with following variable,MMI_M_ADHESION (#1) = 0, bit ‘Low Adhesion from Trackside’ is not set.DMI displays symbol ST02 in sub-area A4, by driver
            Test Step Comment: (1) MMI_gen 7088 (partly: EVC-2, ‘Low Adhesion by Driver’)(2) MMI_gen 111;     
            */
            // Call generic Action Method
            DmiActions.Drive_the_train_forward();


            /*
            Test Step 5
            Action: Perform the following procedure,Press ‘Special’ button.Press ‘Adhesion’ button.Select and confirm ‘Non slippery rail’ button
            Expected Result: No adhesion factor indication is displayed.Verify the following information,Use the log file to confirm that DMI receives EVC-2 with following variable,MMI_M_ADHESION (#0) = 0, bit ‘Low Adhesion by Driver’ is not set
            Test Step Comment: (1) MMI_gen 7088 (partly: No symbol displayed);    
            */
            // Call generic Action Method
            DmiActions
                .Perform_the_following_procedure_Press_Special_button_Press_Adhesion_button_Select_and_confirm_Non_slippery_rail_button();


            /*
            Test Step 6
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}