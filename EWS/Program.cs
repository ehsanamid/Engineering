using DCS.DCSTables;
using System;
using System.Timers;
using System.Windows.Forms;

namespace DocToolkit
{
	public static class DCSProgram
	{

        //private static System.Timers.Timer aTimer;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
        /// 
		[STAThread]
        
		public static void Main()
		{
            //aTimer = new System.Timers.Timer(500);
            //// Hook up the Elapsed event for the timer. 
            //aTimer.Elapsed += OnTimedEvent;
            //aTimer.Enabled = true;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new DCS.Forms.MainForm());
            Application.Run(DCS.Forms.MainForm.Instance());
		}

        //private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{

        //    Common.Blinking = !Common.Blinking;
        // }
	}
}