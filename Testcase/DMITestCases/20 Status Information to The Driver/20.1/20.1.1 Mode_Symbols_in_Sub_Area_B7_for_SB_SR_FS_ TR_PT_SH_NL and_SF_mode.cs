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
using Testcase.Telegrams;
using Testcase.Telegrams.EVCtoDMI;
using Testcase.TemporaryFunctions;

namespace Testcase.DMITestCases
{
    /// <summary>
    /// 20.1.1 Mode Symbols in Sub-Area B7 for SB, SR, FS, TR, PT, SH, NL and SF mode
    /// TC-ID: 15.1.1
    /// 
    /// This test case verifies  a display of ETCS Mode symbol (SB, SR, FS, TR, PT, SH, NL and SF) in area B7 and ETCS-Object ETCS Mode symbol (acknowledgement for SR, TR and SH) in area C1. The symbol of each ETCS Mode shall comply with [ERA] standard.
    /// 
    /// Tested Requirements:
    /// MMI_gen 11084 (partly: current ETCS mode); MMI_gen 110 (partly: MO13, MO09, MO11, MO04, MO06, MO01,MO12, MO18); MMI_gen 1227 (partly:MO10, MO05); MMI_gen 9474; MMI_gen 11233; MMI_gen 3375; MMI_gen 12161;
    /// 
    /// Scenario:
    /// Activate cabin. Then, verify a display of SB symbol.Perform the Start of Mission in level1 until the ‘Start’ button is pressed. Then, verify a display of acknowledgement for SR symbol and SR symbol after acknowledgement.Drive the train pass BG
    /// 1.Then, verify a display of FS symbol.Drive the train pass the EOA. Then, verify a display of TR symbol and acknowledgement for TR symbol after train standstill.Acknowledge the acknowledgement for TR symbol. Then, verify a display of PT symbol.Force the train to Staff responsibility mode.Force the train to Shunting mode. Then, verify a display of acknowledgement for SH symbol and SH symbol after acknowledgement.Force the train to Non-leading. Then, verify a display of NL symbol.De-activate Cabin A.Force the train to System failure. Then, verify a display of SF symbol.
    /// 
    /// Used files:
    /// 15_1_1.tdg
    /// </summary>
    public class Mode_Symbols_in_Sub_Area_B7_for_SB_SR_FS_TR_PT_SH_NL_and_SF_mode : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // - Test system is powered on- Cabin is active

            // Call the TestCaseBase PreExecution
            base.PreExecution();
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in SF mode.

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint

            #region Test Step 1
            /*           
            Action: Verify mode symbol in sub-area B7
            Expected Result: Verify the following information,Use the log file to verify that DMI received the EVC-7 with [MMI_ETCS_MISC_OUT_SIGNALS.OBU_TR_M_MODE] = 6 
            in order to display the Stand By symbol.The Stand By symbol (MO13) is displayed in area B7
            Test Step Comment: (1) MMI_gen 11084 (partly: current ETCS mode);
                               (2) MMI_gen 110 (partly: MO13);
            */

            // EVC-1 & EVC-7 telegram are automatically sent to the DMI. However, we want to make sure that EVC-7 is sent with OBU_TR_M_MODE = 6
            EVC7_MMIEtcsMiscOutSignals.Initialise(this);
            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_Mode = EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_MODE.StandBy;

            // Check feedback on DMI to verify SB Mode ie. EVC-102 [MMI_STATUS_REPORT.MMI_M_MODE_READBACK] = 6
            EVC102_MMIStatusReport.Check_MMI_M_MODE_READBACK = EVC102_MMIStatusReport.MMI_M_MODE_READBACK.StandBy;
            #endregion

            #region Test Step 2
            /*
            Action: Perform SoM in Level1 until the ‘Start’ button is pressed
            */

            // Performing L1 SoM which results with a SR Mode acknowledgement request ie. EVC-8 [MMI_DRIVER_MESSAGE (EVC-8).MMI_Q_TEXT] = 263
            TestcaseRunner.AddTestcase(typeof(SoM_Level1));

            /*
            Expected Result: Verify the following information,The acknowledgement for Staff Responsible symbol (MO10) is displayed in area C1.
            Use the log file to confirm that DMI received the EVC-8 with [MMI_DRIVER_MESSAGE (EVC-8).MMI_Q_TEXT] = 263 
            in order to display the acknowledgement for Staff Responsible symbol
            Test Step Comment: (1) MMI_gen 1227 (partly:MO10);                                
                               (2) MMI_gen 11233;
            */

            EVC8_MMIDriverMessage.MMI_Q_TEXT = 263;
            EVC8_MMIDriverMessage.Send();
            // VISUAL CHECK in order to confirm that SR Mode acknowledgement symbol (MO10) is displayed on DMI area C1.

            #endregion

            #region Test Step 3
            /*
            Action: Press the symbol MO10 in sub-area C1
            */

            // Symbol MO10 on DMI area C1 is pressed and released 
            //ie. EVC-111 sent twice with different value of MMI_T_BUTTONEVENT and MMI_Q_BUTTON (1 = pressed, 0 = released)
            EVC111_MMIDriverMessageAck.Check_MMI_Q_BUTTON = EVC111_MMIDriverMessageAck.MMI_Q_BUTTON.Pressed;
            EVC111_MMIDriverMessageAck.Check_MMI_Q_BUTTON = EVC111_MMIDriverMessageAck.MMI_Q_BUTTON.Released;

            /*
            Expected Result: Verify the following information,The symbol MO10 is disappear from sub-area C1 and re-appear again.
            Use the log file to confirm that DMI sends EVC-111 twice with different value of MMI_T_BUTTONEVENT and MMI_Q_BUTTON (1 = pressed, 0 = released).
            Note: DMI still display in SB mode, Level 1
            Test Step Comment: (1) MMI_gen 9474;
                               (2) MMI_gen 9474; MMI_gen 3375;
            */

            // VISUAL CHECK in order to confirm that the symbol MO10 disappears from sub-area C1 and re-appears again.

            // DMI still displays SB mode
            EVC102_MMIStatusReport.Check_MMI_M_MODE_READBACK = EVC102_MMIStatusReport.MMI_M_MODE_READBACK.StandBy;
            #endregion
            
            #region Test Step 4
            /*
            Action: Press the symbol MO10 in sub-area C1 for 2 second or upper.Then, release the pressed area
            */

            //While pressing DMI C1 area..
            EVC111_MMIDriverMessageAck.Check_MMI_Q_BUTTON = EVC111_MMIDriverMessageAck.MMI_Q_BUTTON.Pressed;

            //..then release it
            EVC111_MMIDriverMessageAck.Check_MMI_Q_BUTTON = EVC111_MMIDriverMessageAck.MMI_Q_BUTTON.Released;

            /*
            Expected Result: Verify the following information,While the MO10 is pressed, the opacity of the symbol is decreased to 50%
            The symbol ‘MO10’ is displayed as a Safe Delay-Type button
            DMI received the EVC-7 with [MMI_ETCS_MISC_OUT_SIGNALS.OBU_TR_M_MODE] = 2 in order to display the Staff Responsible symbol.
            The Staff Responsible symbol (MO9) is displayed in area B7
            Test Step Comment: (1) MMI_gen 12161;
                               (2) MMI_gen 9474;
                               (3) MMI_gen 11084 (partly: current ETCS mode);
                               (4) MMI_gen 110     (partly: MO09);
            */

            // VISUAL CHECK in order to confirm that the opacity of the symbol is decreased to 50%.

            // SR Mode is enable ie. DMI received the EVC-7 with [MMI_ETCS_MISC_OUT_SIGNALS.OBU_TR_M_MODE] = 2
            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_Mode = EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_MODE.StaffResponsible;

            // VISUAL CHECK - The Staff Responsible symbol (MO9) is displayed in area B7
            DmiExpectedResults.DMI_displays_in_SR_mode_Level_1();
            // OR
            EVC102_MMIStatusReport.Check_MMI_M_MODE_READBACK = EVC102_MMIStatusReport.MMI_M_MODE_READBACK.StaffResponsible;
            #endregion

            #region Test Step 5
            /*
            Action: Force the train into FS mode by moving the train forward passing BG1
            Expected Result: Verify the following information, 
            Use the log file to confirm that DMI received the EVC-7 with [MMI_ETCS_MISC_OUT_SIGNALS.OBU_TR_M_MODE] = 0 in order to display the Full Supervision symbol.
            */

            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_Mode = EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_MODE.FullSupervision;

            /*
            The Full Supervision symbol (MO11) is displayed in area B7
            Test Step Comment: (1) MMI_gen 11084 (partly: current ETCS mode);                                                 
                               (2) MMI_gen 110 (partly: MO11);
            */

            //VISUAL CHECK - The Full Supervision symbol (MO11) is displayed in area B7            
            EVC102_MMIStatusReport.Check_MMI_M_MODE_READBACK = EVC102_MMIStatusReport.MMI_M_MODE_READBACK.FullSupervision;
            #endregion

            #region Test Step 6
            /*
            Action: Force the train into TR mode by moving the train forward to position of EOA
            Expected Result: Verify the following information,
            Use the log file to confirm that DMI received the EVC-7 with [MMI_ETCS_MISC_OUT_SIGNALS.OBU_TR_M_MODE] = 7 in order to display the Trip symbol.
            The Trip symbol (MO04) is displayed in area B7
            Test Step Comment: (1) MMI_gen 11084 (partly: current ETCS mode);                            
                               (2) MMI_gen 110 (partly: MO04);
            */
            // Call generic Action Method
            DmiActions.Force_the_train_into_TR_mode_by_moving_the_train_forward_to_position_of_EOA();
            #endregion

            #region Test Step 7
            /*
            Action: Perform the following procedure,
            Wait until the train is stopped. Stop the train (set speed to 0 and set direction to nuetral)
            */

            EVC1_MMIDynamic.MMI_V_TRAIN = 0;

            /*
            Press at sub-area C9
            Expected Result: Verify the following information,
            Use the log file to confirm that DMI received the EVC-8 with [MMI_DRIVER_MESSAGE (EVC-8).MMI_Q_TEXT] = 266 in order to display the acknowledgement for Trip symbol.
            The acknowledgement for Trip symbol (MO05) is displayed in area C1
            Test Step Comment: (1) MMI_gen 11233;                             
                               (2) MMI_gen 1227 (partly: MO05);
            */
            EVC8_MMIDriverMessage.MMI_Q_TEXT = 266;
            EVC8_MMIDriverMessage.Send();

            // VISUAL CHECK in order to confirm that TR Mode acknowledgement symbol (MO05) is displayed on DMI area C1.

            // DMI still displays TR mode
            EVC102_MMIStatusReport.Check_MMI_M_MODE_READBACK = EVC102_MMIStatusReport.MMI_M_MODE_READBACK.Trip;

            #endregion

            #region Test Step 8
            /*
            Action: Press the symbol ‘MO05’ in sub-area C1
            */
            EVC111_MMIDriverMessageAck.Check_MMI_Q_BUTTON = EVC111_MMIDriverMessageAck.MMI_Q_BUTTON.Pressed;
            EVC111_MMIDriverMessageAck.Check_MMI_Q_BUTTON = EVC111_MMIDriverMessageAck.MMI_Q_BUTTON.Released;
            /*
            Expected Result: Verify the following information,
            Use the log file to confirm that DMI received the EVC-7 with [MMI_ETCS_MISC_OUT_SIGNALS.OBU_TR_M_MODE] = 8 in order to display the Post Trip symbol.
            The Post trip symbol (MO06) is displayed in area B7
            Test Step Comment: (1) MMI_gen 11084 (partly: current ETCS mode);
                               (2) MMI_gen 110 (partly: MO06);
            */
            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_Mode = EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_MODE.PostTrip;

            // VISUAL CHECK - The Post trip symbol (MO06) is displayed in area B7

            EVC102_MMIStatusReport.Check_MMI_M_MODE_READBACK = EVC102_MMIStatusReport.MMI_M_MODE_READBACK.PostTrip;
            #endregion

            #region Test Step 9
            /*
            Action: Force the train into SR mode by the steps below:
            Press ‘Main’ button.
            */
            // Main Window is displayed ie. EVC-30 [MMI_ENABLE_REQUEST.MMI_NID_WINDOW] = 1 ("Main Window") is sent to the DMI.
            EVC30_MMIRequestEnable.MMI_NID_WINDOW = 1;
            var standardflags = EVC30_MMIRequestEnable.EnabledRequests.EnableDoppler |
                                EVC30_MMIRequestEnable.EnabledRequests.EnableWheelDiameter |
                                EVC30_MMIRequestEnable.EnabledRequests.StartBrakeTest |
                                EVC30_MMIRequestEnable.EnabledRequests.SetLocalOffset |
                                EVC30_MMIRequestEnable.EnabledRequests.RemoveVBC |
                                EVC30_MMIRequestEnable.EnabledRequests.SetVBC |
                                EVC30_MMIRequestEnable.EnabledRequests.SystemVersion |
                                EVC30_MMIRequestEnable.EnabledRequests.Brightness |
                                EVC30_MMIRequestEnable.EnabledRequests.Volume |
                                EVC30_MMIRequestEnable.EnabledRequests.NonLeading |
                                EVC30_MMIRequestEnable.EnabledRequests.Shunting |
                                EVC30_MMIRequestEnable.EnabledRequests.TrainRunningNumber |
                                EVC30_MMIRequestEnable.EnabledRequests.Level |
                                EVC30_MMIRequestEnable.EnabledRequests.DriverID |
                                EVC30_MMIRequestEnable.EnabledRequests.Start;
            EVC30_MMIRequestEnable.MMI_Q_REQUEST_ENABLE_HIGH = standardflags;
            EVC30_MMIRequestEnable.Send();
            /* 
            Press ‘Start’ button ie. EVC-152 [MMI_DRIVER_ACTION.MMI_M_DRIVER_ACTION] = 19 ("Start selected") is received.
            */
            
            /*
            Acknowledge SR mode
            Expected Result: DMI displays in SR mode, Level 1
            */
            // Call generic Check Results Method
            DmiExpectedResults.DMI_displays_in_SR_mode_Level_1();
            #endregion

            /*
            Test Step 10
            Action: Force the train into SH mode by the steps below:Press ‘Main’ button.Press and hold ‘Shunting’ button for 2 second or upper.Release the pressed area
            Expected Result: Verify the following information,Use the log file to confirm that DMI received the EVC-7 with [MMI_ETCS_MISC_OUT_SIGNALS.OBU_TR_M_MODE] = 3 in order to display the Shunting symbol.The Shunting symbol (MO01) is displayed in area B7
            Test Step Comment: (1) MMI_gen 11084 (partly: current ETCS mode);                                    (2) MMI_gen 110 (partly: MO01);
            */


            /*
            Test Step 11
            Action: Force the train into NL mode by the steps below:Press ‘Main’ button. Press and hold ‘Exit Shunting’ button for 2 second or upper.Release the pressed area.Enter the Driver ID with no performing brake test when Driver ID window is displayed.If the Level window is display, select and confirm Level1. Then, enter the train data and Train running number.Force the simulation to ‘Non-leading’. Press and hold ‘Non-leading’ button for 2 second or upper.Release the pressed area
            Expected Result: Verify the following information,Use the log file to confirm that DMI received the EVC-7 with [MMI_ETCS_MISC_OUT_SIGNALS.OBU_TR_M_MODE] = 11 in order to display the Non-leading.The Non-leading symbol (MO12) is displayed in area B7
            Test Step Comment: (1) MMI_gen 11084 (partly: current ETCS mode);                                   (2) MMI_gen 110 (partly: MO12);
            */


            /*
            Test Step 12
            Action: Force the train into SF mode by the steps below:Unforce the simulation of ‘Non-leading’.De-activate cabin A.Activate cabin B.Activate cabin A
            Expected Result: Verify the following information,Use the log file to confirm that DMI received the EVC-7 with [MMI_ETCS_MISC_OUT_SIGNALS.OBU_TR_M_MODE] = 9 in order to display the System failure symbol.The System failure symbol (MO18) is displayed in area B7
            Test Step Comment: (1) MMI_gen 11084 (partly: current ETCS mode);                                (2) MMI_gen 110 (partly: MO18);
            */


            /*
            Test Step 13
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}