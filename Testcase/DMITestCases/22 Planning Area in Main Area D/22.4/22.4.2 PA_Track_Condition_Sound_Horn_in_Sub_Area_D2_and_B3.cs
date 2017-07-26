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
    /// 22.4.2 PA Track Condition: Sound Horn in Sub-Area D2 and B3
    /// TC-ID: 17.4.2
    /// 
    /// This test case is to verify PA Track Condition”Sound Horn” in Sub-Area D2 and B3. The track condition shall comply with [ERA] standard and [MMI-ETCS-gen].
    /// 
    /// Tested Requirements:
    /// MMI_gen 619(PL24); MMI_gen 9980(partly:Table45(PL24)); MMI_gen 9979(partly: START); MMI_gen 662 (partly: TC35); MMI_gen 10465 (partly:Table40(TC35)); MMI_gen 9965; MMI_gen 636 (partly: START); MMI_gen 2604 (partly: bottom of the symbol, D2);
    /// 
    /// Scenario:
    /// 1.Drive the train forward pass BG0 at position 10m.BG0: pkt 12, 21 and 27 (Entering FS) 
    /// 2.Drive the train forward pass BG1 at position 100m. Then,verify the display of PA track condition based on received packet EVC-32.BG1: pkt 68 (M_TRACKCOND = 2) (Sound Horn)
    /// 3.Verify the Track condition symbol in sub-Area D2 and B3
    /// 
    /// Used files:
    /// 17_4_2.tdg
    /// </summary>
    public class PA_Track_Condition_Sound_Horn_in_Sub_Area_D2_and_B3 : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // Configure atpcu configuration file as following:TC_T_Panto_Down = 100TC_T_MainSwitch_Off = 100TC_T_Airtight_Close =100TC_T_Inhib_RBBrake = 100TC_T_ Inhib_ECBrake = 100TC_T_ Inhib_MSBrake = 100TC_T_Change_TractionSyst = 100TC_T_Allowed_CurrentConsump = 100 TC_T_StationPlatform = 100Test system is power on.SoM is performed in SR mode, level 1.

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays FS mode, level 1

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint


            /*
            Test Step 1
            Action: Drive the train forward with speed = 20km/h
            Expected Result: The speed pointer is indicated as 20  km/h
            */

            /*
            Test Step 2
            Action: Drive the train forward pass BG0 with MA and Track descriptionPkt 12,21 and 27
            Expected Result: Mode changes to FS mode , L1
            */

            /*
            Test Step 3
            Action: Continue to drive the train forward pass BG1 with Track condition Pkt 68:D_TRACKCOND = 200L_TRACKCOND = 200M_TRACKCOND = 2(Sound Horn)
            Expected Result: Mode remins in FS mode
            */

            /*
            Test Step 4
            Action: Enter Anouncement of Track condition “Sound Horn”  
            Expected Result: Verify the following information(1)   DMI displays PL24 symbol in sub-area D2.
            Test Step Comment: (1) MMI_gen 619(PL24);
            */

            /*
            Test Step 5
            Action: Stop the train 
            Expected Result: Verify the following information(1)   Use the log file to confirm that DMI recieved packet information MMI_DRIVER_MESSAGE_ACK (EVC-32) and MMI_ETCS_MISC_OUT_SIGNALS (EVC-7) with the following variables,MMI_M_TRACkCOND_TYPE = 2MMI_Q_TRACKCOND_STEP = 1 or 0 (<2)MMI_O_TRACKCOND_START - OBU_TR_O_TRAIN (EVC-7)  =  Remaining distance from PL24 symbol on area D2 to the first distance scale line (zero line)(2)    The bottom of PL24 symbol is displayed with the correct position in the PA distance scale refer to the result of calculation from expected result (1).
            Test Step Comment: (1) MMI_gen 9980 (partly:Table45(PL24));MMI_gen 9979 (partly: START); MMI_gen 636 (partly: START);(2) MMI_gen 2604 (partly: bottom of the symbol, D2);
            */

            /*
            Test Step 6
            Action: Drive the train forward with speed = 20 km/h
            Expected Result: The speed pointer is indicated as 20  km/h
            */

            /*
            Test Step 7
            Action: Stop the train when the TC 35 symbol displays in sub-area B3
            Expected Result: Verify the following information(1)   DMI displays TC35 symbol in sub-area B3.(2)   Use the log file to confirm that DMI recieved packet information MMI_DRIVER_MESSAGE_ACK (EVC-32) and MMI_ETCS_MISC_OUT_SIGNALS (EVC-7) with the following variables,MMI_M_TRACkCOND_TYPE = 2MMI_Q_TRACKCOND_STEP = 1MMI_Q_TRACKCOND_ACTION_START = 0
            Test Step Comment: (1) MMI_gen 10465 (partly:Table40(TC35));(2) MMI_gen 662 (partly: TC35);
            */

            /*
            Test Step 8
            Action: Drive the train forward with speed = 20 km/h
            Expected Result: The speed pointer is indicated as 20  km/h
            */

            /*
            Test Step 9
            Action: Stop the train when the track condition symbol has been removed from sub-area B3  
            Expected Result: Verify the following information(1)   Use the log file to confirm that DMI received packet information MMI_TRACK_CONDITIONS (EVC-32) with the following variables,MMI_Q_TRACKCOND_STEP = 4MMI_NID_TRACKCOND = same value with expected result No.2 of step 7.
            Test Step Comment: (1) MMI_gen 9965;
            */

            /*
            Test Step 10
            Action: End of test
            Expected Result: 
            */

            return GlobalTestResult;
        }
    }
}