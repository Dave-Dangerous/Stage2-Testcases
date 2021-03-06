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
using Testcase.Telegrams.EVCtoDMI;


namespace Testcase.DMITestCases
{
    /// <summary>
    /// 18.1.7.3 Distance to Target: Appearance of Distance to Target in SB, SR and SH mode
    /// TC-ID: 13.1.7.3
    /// 
    /// This test case verifies the display information of the distance to target bar and digital in SB, SR and SH mode. The display of distance to target is comply with the received packet EVC-1 and EVC-7. 
    /// 
    /// Tested Requirements:
    /// MMI_gen 2567 (partly: SB mode, SR mode, SH mode); MMI_gen 107 (partly: Table 37, SB mode, SR mode, SH mode); MMI_gen 6658; MMI_gen 6774;
    /// 
    /// Scenario:
    /// 1.Enter SB mode, Then, verify the display of distance to target.
    /// 2.Enter SR mode and set the SR speed and SR distance with specify value and press the toggle of basic speed hook to become visible. Then, verify the display of distance to target bar and digital.
    /// 3.Drive the train forward. Then, verify the display of distance to target bar and digital when the supervision status is changed.  
    /// 4.Enter SH mode and verify the display of distance to target bar and digital.Note: The consistency of information for the position in each test step and the location when the value of MMI_M_WARNING changed is able to verify in log file, EVC-7 variable OBU_TR_O_TRAIN.
    /// 
    /// Used files:
    /// N/A
    /// </summary>
    public class Distance_to_Target_Appearance_of_Distance_to_Target_in_SB_SR_and_SH_mode : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:

            // Call the TestCaseBase PreExecution
            base.PreExecution();
            // System is powered on.Cabin is activated.
            EVC0_MMIStartATP.Evc0Type = EVC0_MMIStartATP.EVC0Type.GoToIdle;
            EVC0_MMIStartATP.Send();

            // Set train running number, cab 1 active, and other defaults
            DmiActions.Activate_Cabin_1(this);
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in SH mode, Level 1
            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. DMI displays in SH mode, Level 1.");

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint

            /*
            Test Step 1
            Action: Perform the following procedure,Enter Driver ID and skip break testSelect and confirm ‘Level 1’
            Expected Result: DMI displays in SB mode, level 1.Verify the following information(1)    Use the log file to confirm that DMI receives the following packets information with a specific value,  EVC-7: OBU_TR_M_MODE = 6 (SB mode) (2)   The distance to target bar is not display in sub-area A3. (3)   The distance to target digital is not display in sub-area A2.(4)   Use the log file to confirm that DMI receives the packet EVC-1 with variable MMI_O_BRAKETARGET = -1 (Default)
            Test Step Comment: (1) MMI_gen 107 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SB mode); MMI_gen 2567 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SB mode);(2) MMI_gen 6658 (partly: not be shown); MMI_gen 107 (partly: Table 37, SB mode);(3) MMI_gen 2567 (partly: Table 38, SB mode); MMI_gen 6774 (partly: not be shown);(4) MMI_gen 6658 (partly: MMI_O_BRAKETARGET is less than zero); MMI_gen 6774 (partly: MMI_O_BRAKETARGET is less than zero);
            */
            DmiActions.ShowInstruction(this, "Enter Driver ID. Skip brake test. Select and confirm ‘Level 1’");

            EVC1_MMIDynamic.MMI_O_BRAKETARGET = -1;
            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_Mode = EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_MODE.StandBy;

            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. DMI displays in SB mode, level 1." + Environment.NewLine +
                                "2. The distance to target bar is not displayed in sub-area A3." + Environment.NewLine +
                                "3. The digital distance to target is not displayed in sub-area A2.");

            /*
            Test Step 2
            Action: Perform the following procedure,Perform SoM in SR mode, level1.Press ‘Special’ button.Press ‘SR speed/distance’ button.Enter the value of SR speed = 40 km/h and SR distance = 500mPress ‘Yes’ button.Press on sub-area B to toggle the basic speed hook become visible
            Expected Result: DMI displays in SR mode, level 1Verify the following information(1)    Use the log file to confirm that DMI receives the following packets information with a specific value,  EVC-1: MMI_M_WARNING = 0 (Status = NoS, Supervision = CSM) EVC-7: OBU_TR_M_MODE = 2 (SR mode) (2)   The distance to target bar is not display in sub-area A3. (3)   The distance to target digital is not display in sub-area A2.(4)   Use the log file to confirm that DMI receives the packet EVC-1 with variable MMI_O_BRAKETARGET = -1 (Default)
            Test Step Comment: (1) MMI_gen 107 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SR mode CSM); MMI_gen 2567 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SR mode CSM);(2) MMI_gen 6658 (partly: not be shown); MMI_gen 107 (partly: Table 37, SR mode);(3) MMI_gen 2567 (partly: Table 38, SR mode CSM); MMI_gen 6774 (partly: not be shown);(4) MMI_gen 6658 (partly: MMI_O_BRAKETARGET is less than zero); MMI_gen 6774 (partly: MMI_O_BRAKETARGET is less than zero);
            */
            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_O_TRAIN = 0;       // 0m

            DmiActions.ShowInstruction(this, "Perform SoM in SR mode, level 1. Press ‘Special’ button. Press ‘SR speed / distance’ button. Enter the value of SR speed = 40 km/h " + Environment.NewLine +
                                             "and SR distance = 500m. Press ‘Yes’ button. Press on sub-area B to toggle the basic speed hook so that is is displayed");

            EVC1_MMIDynamic.MMI_M_WARNING = MMI_M_WARNING.Normal_Status_Ceiling_Speed_Monitoring;
            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_Mode = EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_MODE.StaffResponsible;

            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. DMI displays in SR mode, level 1." + Environment.NewLine +
                                "2. The distance to target bar is not displayed in sub-area A3." + Environment.NewLine +
                                "3. The digital distance to target is not displayed in sub-area A2.");

            /*
            Test Step 3
            Action: Continue to drive the train forward.Then, stop the train
            Expected Result: Verify the following information,(1)    Use the log file to confirm that DMI receives the packet information EVC-1 with following variables,MMI_M_WARNING = 2 (Status = NoS, Supervision = PIM)(2)    The distance to target bar is not display in sub-area A3.(3)   The distance to target digital is display in sub-area A2
            Test Step Comment: (1) MMI_gen 107 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SR mode); MMI_gen 2567 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SR mode PIM);(2) MMI_gen 107 (partly: Table 37, SR mode);(3) MMI_gen 2567 (partly: Table 38, SR mode PIM);
            */
            EVC1_MMIDynamic.MMI_V_TARGET_KMH = 10;                      // drive on
            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_O_TRAIN = 2500;       // 25m
            EVC1_MMIDynamic.MMI_V_TARGET_KMH = 0;                       // stop
            EVC1_MMIDynamic.MMI_M_WARNING = MMI_M_WARNING.Normal_Status_PreIndication_Monitoring;

            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. The distance to target bar is not displayed in sub-area A3." + Environment.NewLine +
                                "2. The digital distance to target is not displayed in sub-area A2.");

            /*
            Test Step 4
            Action: Continue to drive the train forward.Then, stop the train
            Expected Result: Verify the following information,(1)    Use the log file to confirm that DMI receives the packet information EVC-1 with following variables,MMI_M_WARNING = 11 (Status = NoS, Supervision = TSM)(2)    The distance to target bar is not display in sub-area A3.(3)    The distance to target digital is display in sub-area A2
            Test Step Comment: (1) MMI_gen 107 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SR mode); MMI_gen 2567 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SR mode TSM);(2) MMI_gen 107 (partly: Table 37, SR mode);(3) MMI_gen 2567 (partly: Table 38, SR mode TSM);
            */
            EVC1_MMIDynamic.MMI_V_TARGET_KMH = 10;                      // drive on
            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_O_TRAIN = 10500;       // 105m
            EVC1_MMIDynamic.MMI_V_TARGET_KMH = 0;                       // stop
            EVC1_MMIDynamic.MMI_M_WARNING = MMI_M_WARNING.Normal_Status_Target_Speed_Monitoring;

            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. The distance to target bar is not displayed in sub-area A3." + Environment.NewLine +
                                "2. The digital distance to target is not displayed in sub-area A2.");

            /*
            Test Step 5
            Action: Perform the following procedure,Press ‘Main’ button.Press and hold ‘Shunting’ button at least 2 second.Release the pressed button
            Expected Result: DMI displays in SH mode, level 1.Verify the following information,(1)    Use the log file to confirm that DMI receives the following packets information with a specific value, EVC-7: OBU_TR_M_MODE = 3 (SH mode) (2)    The distance to target bar is not display in sub-area A3.(3)    The distance to target digital is not display in sub-area A2.(4)   Use the log file to confirm that DMI receives the packet EVC-1 with variable MMI_O_BRAKETARGET = -1 (Default)
            Test Step Comment: (1) MMI_gen 107 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SH mode); MMI_gen 2567 (partly: MMI_M_WARNING, OBU_TR_M_MODE, SH mode);(2) MMI_gen 6658 (partly: not be shown); MMI_gen 107 (partly: Table 37, SH mode);(3) MMI_gen 2567 (partly: Table 38, SH mode); MMI_gen 6774 (partly: not be shown);(4) MMI_gen 6658 (partly: MMI_O_BRAKETARGET is less than zero); MMI_gen 6774 (partly: MMI_O_BRAKETARGET is less than zero);
            */
            DmiActions.ShowInstruction(this, "Press ‘Main’ button.	Press and hold ‘Shunting’ button for at least 2s. Release the ‘Main’ button.");

            EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_Mode = EVC7_MMIEtcsMiscOutSignals.MMI_OBU_TR_M_MODE.Shunting;

            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine + 
                                "1. Does the DMI delete the SR mode symbol (MO09) and replace it with the SH mode symbol (MO01) in area B7" + Environment.NewLine +
                                "2. The distance to target bar is not displayed in sub-area A3." + Environment.NewLine +
                                "3. The digital distance to target is not displayed in sub-area A2.");

            /*
            Test Step 6
            Action: End of test
            Expected Result: 
            */

            return GlobalTestResult;
        }
    }
}