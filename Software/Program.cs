﻿using System;
using System.Windows.Forms;
using ApProg.Icsp;
using ApProg.UI;

namespace ApProg
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += OnErrorOccured;
            Application.Run(new Form1(new IcspService()));
        }

        /// <summary>
        /// Global exception handler
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="args">The detailed information about event</param>
        static void OnErrorOccured(object sender, UnhandledExceptionEventArgs args)
        {
            MessageBox.Show(((Exception)args.ExceptionObject).Message);
            Application.Exit();
        }
    }
}