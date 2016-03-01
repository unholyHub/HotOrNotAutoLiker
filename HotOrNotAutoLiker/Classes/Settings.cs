//-----------------------------------------------------------------------
// <copyright file="Settings.cs" company="Zhivko Kabaivanov">
//     Copyright (c) Zhivko Kabaivanov. All rights reserved.
// </copyright>
// <author>Zhivko Kabaivanov</author>
//-----------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;

namespace HotOrNotAutoLiker
{
    /// <summary>
    /// Class containing the application settings and utilities.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// The sync root to ensure that only one instance is running.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Instance of the <see cref="Settings"/> class.
        /// </summary>
        private static Settings instance;

        /// <summary>
        /// Field for storing the application current version.
        /// </summary>
        private string applicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// Field storing the PayPayUrl.
        /// </summary>
        private Uri payPalUrl = new Uri(@"https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=9J6LZALC9X8RE");
        
        /// <summary>
        /// Prevents a default instance of the <see cref="Settings"/> class from being created.
        /// </summary>
        private Settings()
        {
            this.InitSettings();
        }

        /// <summary>
        /// Gets the instance of the <see cref="Settings"/> class.
        /// </summary>
        public static Settings Instance
        {
            get
            {
                lock (SyncRoot)
                {
                    return instance ?? (instance = new Settings());
                }
            }
        }

        /// <summary>
        /// Gets the PayPal URL for donate button.
        /// </summary>
        public Uri PayPalUrl
        {
            get { return this.payPalUrl; }
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return this.applicationVersion;
            }
        }

        /// <summary>
        /// Gets the path for application data directory.
        /// </summary>
        public string ProgramAppDataDirectory { get; private set; }

        /// <summary>
        /// Initializes the<see cref= "Settings" /> properties.
        /// </ summary >
        private void InitSettings()
        {
            this.ProgramAppDataDirectory = Path.Combine(
                                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                        "HotOrNotAutoLiker");
            this.CheckForAppDir();
        }

        /// <summary>
        /// Performing a check if the application data directory exists, if no
        /// it s created, else nothing happens.
        /// </summary>
        private void CheckForAppDir()
        {
            if (!Directory.Exists(this.ProgramAppDataDirectory))
            {
                Directory.CreateDirectory(this.ProgramAppDataDirectory);
            }
        }
    }
}
