﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL345;

namespace Testcase.Telegrams.EVCtoDMI
{
    static class EVC34_MMISystemVersion
    {
        private static SignalPool _pool;
        private static byte _x = 0;
        private static byte _y = 0;

        /// <summary>
        /// Initialises an instance of EVC-34 telegram.
        /// </summary>
        /// <param name="pool"></param>
        public static void Initialise(SignalPool pool)
        {
            _pool = pool;

            // Set default values
            _pool.SITR.ETCS1.SystemVersion.MmiMPacket.Value = 34;           // Packet ID
            _pool.SITR.ETCS1.SystemVersion.MmiLPacket.Value = 48;           // Packet length
        }

        private static void SetOperatedSystemVersion()
        {
            _pool.SITR.ETCS1.SystemVersion.MmiMOperatedSystemVersion.Value = (ushort)(_x << 8 | _y);
        }

        /// <summary>
        /// Operated system version according to SS026 (X.Y - first byte is X).
        /// Bits:
        /// 0..7 = "X : UNSIGNED8"
        /// Note: Version "X.Y"
        /// </summary>
        public static byte SYSTEM_VERSION_X
        {
            set
            {
                _x = value;
                SetOperatedSystemVersion();
            }
        }

        /// <summary>
        /// Operated system version according to SS026 (X.Y - first byte is X).
        /// Bits:
        /// 8..15 = "Y : UNSIGNED8"
        /// Note: Version "X.Y"
        /// </summary>
        public static byte SYSTEM_VERSION_Y
        {
            set
            {
                _y = value;
                SetOperatedSystemVersion();
            }
        }

        public static void Send()
        {
            _pool.SITR.SMDCtrl.ETCS1.SystemVersion.Value = 1;
        }      
    }
}
