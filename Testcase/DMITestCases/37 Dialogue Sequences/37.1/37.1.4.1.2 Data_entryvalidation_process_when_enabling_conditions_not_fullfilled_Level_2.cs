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
    /// 37.1.4.1.2 Data entry/validation process when enabling conditions not fullfilled: Level 2
    /// TC-ID: 34.1.4.2
    /// 
    /// This test case verifies the dialogue sequences when the button-enabling conditions of the concerned windows are not fulfilled and the display of the ‘Close’ button on the ‘RBC data’ and ‘Radio network ID’ windows.
    /// 
    /// Tested Requirements:
    /// MMI_gen 8868 (partly: after the start-up dialogue sequesnce, RBC data entry, Radio network ID); MMI_gen 11283 (partly: RBC data entry, Radio network ID); MMI_gen 3374 (partly: NEGATIVE, close by ETCS OB);
    /// 
    /// Scenario:
    /// SoM is performed until level 2 (mode SB) and RBC data are confirmed. (Start-up Dialogue Sequence)A concerned window is opened and ,then, the driver drives the train forward without movement authorities.The concerned window is verified.Note: Please see more detail of enabling condition in chapter 8.2 of requirement specificaiton document. The following windows are concerned:RBC data windowRadio network ID window
    /// 
    /// Used files:
    /// 34_1_4.2.utt
    /// </summary>
    public class Data_entryvalidation_process_when_enabling_conditions_not_fullfilled_Level_2 : TestcaseBase
    {
        public override void PreExecution()
        {
            // Pre-conditions from TestSpec:
            // Test system is powered on Cabin A is activated.Enter Driver ID and perform brake test.Level is entered and confirmed.

            // Call the TestCaseBase PreExecution
            base.PreExecution();

            DmiActions.Complete_SoM_L1_SB(this);
        }

        public override void PostExecution()
        {
            // Post-conditions from TestSpec
            // DMI displays in SB mode, level 2
            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. DMI displays in SB mode, Level 2.");

            // Call the TestCaseBase PostExecution
            base.PostExecution();
        }

        public override bool TestcaseEntryPoint()
        {
            // Testcase entrypoint

            /*
            Test Step 1
            Action: Perform the following procedure,Press ‘Level’ button.Enter and confirm Level 2.Press ‘RBC data’ button
            Expected Result: DMI displays RBC data window
            Test Step Comment: (1) MMI_gen 8868 (partly: after the start-up dialogue sequence);
            */
            DmiActions.ShowInstruction(this, @"Press ‘Level’ button. Enter and confirm Level 2. Press ‘RBC data’ button");
            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. DMI displays RBC data window.");

            /*
            Test Step 2
            Action: Perform the following procedure,Drive the train forward until the brake is appliedStop driving the trainAcknowledge the ‘Brake intervention’ symbol by pressing area E1
            Expected Result: Verify the following information,DMI closes the RBC data window and displays RBC Contact window instead.Use the log file to confirm that DMI receives packet information [MMI_ENABLE_REQUEST (EVC-30)] with variable MMI_Q_REQUEST_ENABLE_64 (#21) = 0
            Test Step Comment: (1) MMI_gen 8868 (partly: RBC data entry);(2) MMI_gen 11283 (partly: RBC data entry); MMI_gen 3374 (partly: NEGATIVE, close by ETCS OB);
            */
            // ?? More required to get emergency symbol displayed
            EVC1_MMIDynamic.MMI_V_TRAIN_KMH = 5;
            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. DMI closes the RBC data window and displays the RBC contact window.");

            EVC1_MMIDynamic.MMI_V_TRAIN_KMH = 0;

            // spec says bit 21 = 0 => EnterRBCData
            // This should be done by int request = EVC30_MMIRequestEnable.MMI_Q_REQUEST_ENABLE_HIGH;
            //                        request &= ~(EVC30_MMIRequestEnable.EnabledRequests.EnterRBCData);
            //                        EVC30_MMIRequestEnable.MMI_Q_REQUEST_ENABLE_HIGH = request;
            DmiActions.ShowInstruction(this, @"Press area E1 to acknowledge the ‘Brake intervention’ symbol");

            /*
            Test Step 3
            Action: Perform the following procedure,Press and hold  ‘Radio network ID’ button at least 2 seconds.Release the pressed area
            Expected Result: DMI displays Radio network ID window
            */
            DmiActions.ShowInstruction(this, @"Press and hold ‘Radio network ID’ button for at least 2 seconds. Release the pressed area");
            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. DMI displays Radio network ID window.");


            /*
            Test Step 4
            Action: Perform the following procedure,Drive the train forward until the brake is appliedStop driving the trainAcknowledge the ‘Brake intervention’ symbol by pressing area E1
            Expected Result: Verify the following information,DMI closes the RBC data window and displays RBC Contact window instead.Use the log file to confirm that DMI receives packet information [MMI_ENABLE_REQUEST (EVC-30)] with variable MMI_Q_REQUEST_ENABLE_64 (#22) = 0
            Test Step Comment: (1) MMI_gen 8868 (partly: Radio network ID);(2) MMI_gen 11283 (partly: Radio network ID);
            */
            // ?? More required to get emergency symbol displayed
            EVC1_MMIDynamic.MMI_V_TRAIN_KMH = 5;
            WaitForVerification("Check the following:" + Environment.NewLine + Environment.NewLine +
                                "1. DMI closes the RBC data window and displays the RBC Contact window.");

            EVC1_MMIDynamic.MMI_V_TRAIN_KMH = 0;

            // spec says bit 22 = 0 => RadioNetworkID
            // This should be done by int request = EVC30_MMIRequestEnable.MMI_Q_REQUEST_ENABLE_HIGH;
            //                        request &= ~(EVC30_MMIRequestEnable.EnabledRequests.RadioNetworkID);
            //                        EVC30_MMIRequestEnable.MMI_Q_REQUEST_ENABLE_HIGH = request;
            DmiActions.ShowInstruction(this, @"Press area E1 to acknowledge the ‘Brake intervention’ symbol");

            /*
            Test Step 5
            Action: End of test
            Expected Result: 
            */


            return GlobalTestResult;
        }
    }
}