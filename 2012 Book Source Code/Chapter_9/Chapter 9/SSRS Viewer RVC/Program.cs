using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSRS_Viewer_RVC
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
			Application.Run(new ViewerRVC());
		}
	}
}