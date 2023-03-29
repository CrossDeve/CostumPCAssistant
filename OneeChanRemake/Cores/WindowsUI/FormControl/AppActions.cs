﻿using OneeChanRemake.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneeChanRemake.FormControl
{
    /// <summary>
    /// کلاس مربوط به دستورات پیش فرض یا مربوط به برنامه
    /// زمانی که دستورات پیش فرض مانند 
    /// Exit
    /// اجرا میشود در این کلاس تابع مورد نظر خوانده میشود
    /// </summary>
    internal class AppActions
    {
        public static void SetDefaultCommands()
        {

            //Applicational
            LibraryCommand.AddCommand("Commands", OpenCommandsPanel, Strucures.CommandTypes.Applicational);
            LibraryCommand.AddCommand("AddCommand", OpenAddPanel, Strucures.CommandTypes.Applicational);
            LibraryCommand.AddCommand("Exit", CloseApp, Strucures.CommandTypes.Applicational);
            LibraryCommand.AddCommand("Mute", Mute,Strucures.CommandTypes.Applicational);
            LibraryCommand.AddCommand("DeleteAllData", DeleteAllData, Strucures.CommandTypes.Applicational);
            LibraryCommand.AddCommand("Minimize", MinimizeWindow, Strucures.CommandTypes.Applicational);
            //Systematic
            LibraryCommand.AddCommand("ShutdownPC", ShutdownPC, Strucures.CommandTypes.Systematic);
            LibraryCommand.AddCommand("RestartPC", RestartPC, Strucures.CommandTypes.Systematic);
            LibraryCommand.AddCommand("LockPC", LockPC, Strucures.CommandTypes.Systematic);
            LibraryCommand.AddCommand("SleepPC", SleepPC, Strucures.CommandTypes.Systematic);
            LibraryCommand.AddCommand("ForceDVDrom", ForceDVDrom, Strucures.CommandTypes.Systematic);
        }

        static void OpenCommandsPanel()
        {

        }
        static void OpenAddPanel()
        {

        }
        public static void CloseApp()
        {
            System.Windows.Forms.Application.Exit();
        }
        public static void Mute()
        {

        }
        public static void DeleteAllData()
        {
            DialogResult res = MessageBox.Show("Are you sure want to delete all your data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                Informations.DeleteAllData();
        }
        public static void MinimizeWindow()
        {
            MainForm.mainform.WindowState = FormWindowState.Minimized;
        }

        public static void ShutdownPC()
        {
            DialogResult res = MessageBox.Show("Are you sure want to turn off your Computer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                Operation_System.OSactions.ShutDown();
        }
        public static void RestartPC()
        {
            DialogResult res = MessageBox.Show("Are you sure want to restart your Computer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                Operation_System.OSactions.Restart();
        }
        public static void LockPC()
        {
            Operation_System.OSactions.LockWindows();

        }
        public static void SleepPC()
        {
            Operation_System.OSactions.Sleep();

        }
        public static void ForceDVDrom()
        {
            Operation_System.OSactions.OpenOrCloseDVDRom();
        }

        public static List<Strucures.CommandData> SearchCommand(string commandname)
        {
            List < Strucures.CommandData > list = new List<Strucures.CommandData>();

            if (string.IsNullOrWhiteSpace(commandname))
            {
                Dictionary<string, Strucures.StabelCommand> collection1 = Application.LibraryCommand.Commandmanager.SystematicCommands;
                Dictionary<string, Strucures.UserCommand> collection2 = Application.LibraryCommand.Commandmanager.UserCommands;

                foreach (var item in collection1)
                {
                    list.Add(item.Value);
                }
                foreach (var item in collection2)
                {
                    list.Add(item.Value);
                }

                return list;
            }
            else
            {
                return Application.LibraryCommand.FindSimilars(commandname);
            }
        }
    }
}
