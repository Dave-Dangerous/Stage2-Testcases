﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL345;

namespace Testcase.Telegrams.EVCtoDMI
{
    static class Variables
    {
        /// <summary>
        /// This populates the Data Elements of EVC-6, 11, and 22
        /// 
        /// Note: EVC-22 captions must be limited to 10 chars compared to the 16 allowed in the VSIS.
        /// </summary>
        /// <param name="baseString">The base RTSIM signal name to use</param>
        /// <param name="totalSizeCounter">Reference counter for total size of telegram</param>
        /// <param name="_pool">The SignalPool</param>
        /// <returns></returns>
        public static ushort PopulateDataElements(string baseString, ushort totalSizeCounter,
            List<DataElement> dataElements, SignalPool _pool)
        {
            // Populate the data elements array
            for (var tdeIndex = 0; tdeIndex < dataElements.Count; tdeIndex++)
            {
                var trainDataElement = dataElements[tdeIndex];

                var varNamestring = baseString + tdeIndex + "_";
                var charArray = trainDataElement.EchoText.ToCharArray();
                if (charArray.Length > 10)
                    throw new ArgumentOutOfRangeException("Too many chars in the caption string!");

                // Set identifier
                _pool.SITR.Client.Write(varNamestring + "MmiNidData", trainDataElement.Identifier);

                // Set data check result
                _pool.SITR.Client.Write(varNamestring + "MmiQDataCheck", trainDataElement.QDataCheck);

                // Set number of chars
                _pool.SITR.Client.Write(varNamestring + "MmiNText", charArray.Length);

                totalSizeCounter += 32;

                // Populate the array
                for (var charIndex = 0; charIndex < charArray.Length; charIndex++)
                {
                    var character = charArray[charIndex];

                    if (charIndex < 10)
                    {
                        _pool.SITR.Client.Write(varNamestring + baseString.Substring( baseString.LastIndexOf('_') + 1 ) + $"10{charIndex}_MmiXText", character);
                    }
                    else
                    {
                        _pool.SITR.Client.Write(varNamestring + baseString.Substring( baseString.LastIndexOf('_') + 1 ) + $"1{charIndex}_MmiXText", character);
                    }

                    totalSizeCounter += 8;
                }
            }
            return totalSizeCounter;
        }

        /// <summary>
        /// Data to be checked and verified by the EVC.
        /// </summary>
        public class DataElement
        {
            public ushort Identifier { get; set; }      // Identifier of a data set
            public ushort QDataCheck { get; set; }      // Result of data check
            public string EchoText { get; set; }        // Echo text of data
        }

        /// <summary>
        /// Identifier of MMI Buttons.
        /// 
        /// Values:
        /// 0 = "BTN_MAIN"
        /// 1 = "BTN_OVERRIDE"
        /// 2 = "BTN_DATA_VIEW"
        /// 3 = "BTN_SPECIAL"
        /// 4 = "BTN_SETTINGS"
        /// 5 = "BTN_START"
        /// 6 = "BTN_DRIVER_ID"
        /// 7 = "BTN_TRAIN_DATA"
        /// 8 = "BTN_LEVEL"
        /// 9 = "BTN_TRAIN_RUNNING_NUMBER"
        /// 10 = "BTN_SHUNTING"
        /// 11 = "BTN_EXIT_SHUNTING"
        /// 12 = "BTN_NON_LEADING"
        /// 13 = "BTN_MAINTAIN_SHUNTING"
        /// 14 = "BTN_OVERRIDE_EOA"
        /// 15 = "BTN_ADHESION"
        /// 16 = "BTN_SR_SPEED_DISTANCE"
        /// 17 = "BTN_TRAIN_INTEGRITY"
        /// 18 = "BTN_SYSTEM_VERSION"
        /// 19 = "BTN_SET_VBC"
        /// 20 = "BTN_REMOVE_VBC"
        /// 21 = "BTN_CONTACT_LAST_RBC"
        /// 22 = "BTN_USE_SHORT_NUMBER"
        /// 23 = "BTN_ENTER_RBC_DATA"
        /// 24 = "BTN_RADIO_NETWORK_ID"
        /// 25 = "BTN_DRIVERID_TRAIN_RUNNING_NUMBER "
        /// 26 = "BTN_DRIVERID_SETTINGS"
        /// 27 = "BTN_SWITCH_FIXED_TRAIN_DATA_ENTRY"
        /// 28 = "BTN_SWITCH_FLEXIBLE_TRAIN_DATA_ENTRY"
        /// 29 = "BTN_TOGGLE_TUNNELSTOP_AREA"
        /// 30 = "BTN_TOGGLE_SPEED_DISTANCE_INFO"
        /// 31 = "BTN_YES_TRACK_AHEAD_FREE"
        /// 32 = "BTN_TOGGLE_GEOPOS"
        /// 33 = "BTN_CLOSE"
        /// 34 = "BTN_SCROLL_UP"
        /// 35 = "BTN_SCROLL_DOWN"
        /// 36 = "BTN_YES_DATA_ENTRY_COMPLETE"
        /// 37 = "BTN_YES_DATA_ENTRY_COMPLETE_DELAY_TYPE"
        /// 38 = "BTN_STM_DATA_ENTRY_SELECTION_POS1"
        /// 39 = "BTN_STM_DATA_ENTRY_SELECTION_POS2"
        /// 40 = "BTN_STM_DATA_ENTRY_SELECTION_POS3"
        /// 41 = "BTN_STM_DATA_ENTRY_SELECTION_POS4"
        /// 42 = "BTN_STM_DATA_ENTRY_SELECTION_POS5"
        /// 43 = "BTN_STM_DATA_ENTRY_SELECTION_POS6"
        /// 44 = "BTN_STM_DATA_ENTRY_SELECTION_POS7"
        /// 45 = "BTN_STM_DATA_ENTRY_SELECTION_POS8"
        /// 46 = "BTN_STM_END_OF_DATA_ENTRY"
        /// 47..252 = "Spare"
        /// 253 = "BTN_ENTER_DELAY_TYPE"
        /// 254 = "BTN_ENTER"
        /// 255 = "no button"
        /// </summary>
        public enum MMI_M_BUTTONS : ushort
        {
            BTN_MAIN = 0,
            BTN_OVERRIDE = 1,
            BTN_DATA_VIEW = 2,
            BTN_SPECIAL = 3,
            BTN_SETTINGS = 4,
            BTN_START = 5,
            BTN_DRIVER_ID = 6,
            BTN_TRAIN_DATA = 7,
            BTN_LEVEL = 8,
            BTN_TRAIN_RUNNING_NUMBER = 9,
            BTN_SHUNTING = 10,
            BTN_EXIT_SHUNTING = 11,
            BTN_NON_LEADING = 12,
            BTN_MAINTAIN_SHUNTING = 13,
            BTN_OVERRIDE_EOA = 14,
            BTN_ADHESION = 15,
            BTN_SR_SPEED_DISTANCE = 16,
            BTN_TRAIN_INTEGRITY = 17,
            BTN_SYSTEM_VERSION = 18,
            BTN_SET_VBC = 19,
            BTN_REMOVE_VBC = 20,
            BTN_CONTACT_LAST_RBC = 21,
            BTN_USE_SHORT_NUMBER = 22,
            BTN_ENTER_RBC_DATA = 23,
            BTN_RADIO_NETWORK_ID = 24,
            BTN_DRIVERID_TRAIN_RUNNING_NUMBER = 25,
            BTN_DRIVERID_SETTINGS = 26,
            BTN_SWITCH_FIXED_TRAIN_DATA_ENTRY = 27,
            BTN_SWITCH_FLEXIBLE_TRAIN_DATA_ENTRY = 28,
            BTN_TOGGLE_TUNNELSTOP_AREA = 29,
            BTN_TOGGLE_SPEED_DISTANCE_INFO = 30,
            BTN_YES_TRACK_AHEAD_FREE = 31,
            BTN_TOGGLE_GEOPOS = 32,
            BTN_CLOSE = 33,
            BTN_SCROLL_UP = 34,
            BTN_SCROLL_DOWN = 35,
            BTN_YES_DATA_ENTRY_COMPLETE = 36,
            BTN_YES_DATA_ENTRY_COMPLETE_DELAY_TYPE = 37,
            BTN_STM_DATA_ENTRY_SELECTION_POS1 = 38,
            BTN_STM_DATA_ENTRY_SELECTION_POS2 = 39,
            BTN_STM_DATA_ENTRY_SELECTION_POS3 = 40,
            BTN_STM_DATA_ENTRY_SELECTION_POS4 = 41,
            BTN_STM_DATA_ENTRY_SELECTION_POS5 = 42,
            BTN_STM_DATA_ENTRY_SELECTION_POS6 = 43,
            BTN_STM_DATA_ENTRY_SELECTION_POS7 = 44,
            BTN_STM_DATA_ENTRY_SELECTION_POS8 = 45,
            BTN_STM_END_OF_DATA_ENTRY = 46,
            BTN_ENTER_DELAY_TYPE = 253,
            BTN_ENTER = 254,
            No_Button = 255
        }

        /// <summary>
        /// MMI_NID_RBC value specifying to contact last known RBC
        /// </summary>
        public const uint ContactLastRBC = 16383;

        /// <summary>
        /// NID_C as allocated by ERA for Crossrail Central Section
        /// </summary>
        public const uint NidC = 3;

        /// <summary>
        /// Conversion factor for cm/s to km/h
        /// </summary>
        public const double CmSToKmH = 0.036;

        /// <summary>
        /// Conversion factor for cm/s to mph
        /// </summary>
        public const double CmSToMph = 0.02237;

        /// <summary>
        /// Driver Request enum
        /// 
        /// Values:
        /// 0 = "Spare"
        /// 1 = "Start Shunting"
        /// 2 = "Exit Shunting"
        /// 3 = "Start Train Data Entry"
        /// 4 = "Exit Train Data Entry"
        /// 5 = "Start Non-Leading"
        /// 6 = "Exit Non-Leading"
        /// 7 = "Start Override EOA (Pass stop)"
        /// 8 = "Geographical position request"
        /// 9 = "Start"
        /// 10 = "Restore adhesion coefficient to 'non-slippery rail'"
        /// 11 = "Set adhesion coefficient to 'slippery rail'"
        /// 12 = "Exit Change SR rules"
        /// 13 = "Change SR rules"
        /// 14 = "Continue shunting on desk closure"
        /// 15 = "Spare"
        /// 16 = "Spare"
        /// 17 = "Spare"
        /// 18 = "Spare"
        /// 19 = "Spare"
        /// 20 = "Change Driver identity"
        /// 21 = "Start Train Data View"
        /// 22 = "Start Brake Test"
        /// 23 = "Start Set VBC"
        /// 24 = "Start Remove VBC"
        /// 25 = "Exit Set VBC"
        /// 26 = "Exit Remove VBC"
        /// 27 = "Change Level (or inhibit status)"
        /// 28 = "Start RBC Data Entry"
        /// 29 = "System Info request"
        /// 30 = "Change Train Running Number"
        /// 31 = "Exit Change Train Running Number"
        /// 32 = "Exit Change Level (or inhibit status)"
        /// 33 = "Exit RBC Data Entry"
        /// 34 = "Exit Driver Data Entry"
        /// 35 = "Spare"
        /// 36 = "Spare"
        /// 37 = "Spare"
        /// 38 = "Start procedure 'Train Integrity'"
        /// 39 = "Exit RBC contact"
        /// 40 = "Level entered"
        /// 41 = "start NTC 1 data entry"
        /// 42 = "start NTC 2 data entry"
        /// 43 = "start NTC 3 data entry"
        /// 44 = "start NTC 4 data entry"
        /// 45 = "start NTC 5 data entry"
        /// 46 = "start NTC 6 data entry"
        /// 47 = "start NTC 7 data entry"
        /// 48 = "start NTC 8 data entry"
        /// 49 = "Exit NTC data entry"
        /// 50 = "Exit NTC data entry selection"
        /// 51 = "Change Brake Percentage"
        /// 52 = "Change Doppler"
        /// 53 = "Change Wheel Diameter"
        /// 54 = "Exit maintenance"
        /// 55 = "System Version request"
        /// 56 = "Start Network ID"
        /// 57 = "Contact last RBC"
        /// 58 = "Settings"
        /// 59 = "Switch"
        /// 60 = "Exit brake percentage"
        /// 61 = "Exit RBC Network ID"
        /// 62..255 = "Spare"
        /// 
        /// Note 1: Values 3 and 4 also apply to customised Train Data Entry (packets EVC-60, EVC-61, EVC-160, EVC-161).
        /// Note 2: The number of the NTC x in 'start NTC x data entry' will match the sequence number of the related NTC in the list provided with EVC-31.
        /// </summary>
        public enum MMI_M_REQUEST : byte
        {
            StartShunting = 1,
            ExitShunting = 2,
            StartTrainDataEntry = 3,
            ExitTrainDataEntry = 4,
            StartNonLeading = 5,
            ExitNonLeading = 6,
            StartOverrideEOA = 7,
            GeographicalPositionRequest = 8,
            Start = 9,
            RestoreAdhesionCoefficientToNonSlipperyRail = 10,
            SetAdhesionCoefficientToSlipperyRail = 11,
            ExitChangeSRrules = 12,
            ChangeSRrules = 13,
            ContinueShuntingOnDeskClosure = 14,
            ChangeDriverIdentity = 20,
            StartTrainDataView = 21,
            StartBrakeTest = 22,
            StartSetVBC = 23,
            StartRemoveVBC = 24,
            ExitSetVBC = 25,
            ExitRemoveVBC = 26,
            ChangeLevel = 27,
            StartRBCdataEntry = 28,
            SystemInfoRequest = 29,
            ChangeTrainRunningNumber = 30,
            ExitChangeTrainRunningNumber = 31,
            ExitChangeLevel = 32,
            ExitRBCdataEntry = 33,
            ExitDriverDataEntry = 34,
            StartProcedureTrainIntegrity = 38,
            ExitRBCcontact = 39,
            LevelEntered = 40,
            startNTC1DataEntry = 41,
            startNTC2DataEntry = 42,
            startNTC3DataEntry = 43,
            startNTC4DataEntry = 44,
            startNTC5DataEntry = 45,
            startNTC6DataEntry = 46,
            startNTC7DataEntry = 47,
            startNTC8DataEntry = 48,
            ExitNTCDataEntry = 49,
            ExitNTCDataEntrySelection = 50,
            ChangeBrakePercentage = 51,
            ChangeDoppler = 52,
            ChangeWheelDiameter = 53,
            ExitMaintenance = 54,
            SystemVersionRequest = 55,
            StartNetworkID = 56,
            ContactLastRBC = 57,
            Settings = 58,
            Switch = 59,
            ExitBrakePercentage = 60,
            ExitRBCNetworkID = 61
        }

        /// <summary>
        /// Button Event enum
        /// 
        /// Values:
        /// 0 = "released"
        /// 1 = "pressed"
        /// </summary>
        public enum MMI_Q_BUTTON : byte
        {
            Released = 0,
            Pressed = 1
        }
    }
}