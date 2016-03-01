//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Zhivko Kabaivanov">
//     Copyright (c) Zhivko Kabaivanov. All rights reserved.
// </copyright>
// <author>Zhivko Kabaivanov</author>
//-----------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using HotOrNotAutoLiker.Classes;
using HotOrNotAutoLiker.Properties;
using Timer = System.Windows.Forms.Timer;

namespace HotOrNotAutoLiker
{
    /// <summary>
    /// Partial class for showing the <see cref="AboutBox"/>.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The blocking <see cref="System.Windows.Forms.Timer"/> for closing the TeamViewer windows.
        /// </summary>
        private static Timer blockingTimer;

        /// <summary>
        /// The update <see cref="System.Timers.Timer"/> for notifying the user for new version.
        /// </summary>
        private static System.Timers.Timer updateTimer;
        
        /// <summary>
        /// Allowing the <see cref="MainForm"/> to be closed.
        /// </summary>
        private static bool allowClose;

        /// <summary>
        /// Allowing to the <see cref="MainForm"/> to be visible or not.
        /// </summary>
        private bool allowVisible = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            this.InitControls();
            this.StartBlocking();
            UpdateNotifier.Instance.NotifyForUpdate();
        }

        /// <summary>
        /// Gets or sets the <see cref="AboutBox"/>.
        /// </summary>
        private static AboutBox AboutBox { get; set; }
        
        /// <summary>
        /// Occurs before the form is closed.
        /// </summary>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> e.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            blockingTimer.Stop();
            
            if (!allowClose)
            {
                this.Hide();

                if (e != null)
                {
                    e.Cancel = true;
                }
            }

            base.OnFormClosing(e);
        }

        /// <summary>
        /// Sets the control to the specified visible state.
        /// </summary>
        /// <param name="value"><see>
        ///         <cref>true</cref>
        ///     </see>
        ///     to make the control visible; otherwise, <see>
        ///         <cref>false</cref>
        ///     </see>
        /// .</param>
        protected override void SetVisibleCore(bool value)
        {
            if(!allowVisible)
            {
                value = false;

                if (!this.IsHandleCreated) try
                {
                    CreateHandle();
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    //LogSystem.Instance.AddToLog(invalidOperationException, false);
                }
            }

            base.SetVisibleCore(value);
        }

        /// <summary>
        /// Initialization for the blocking <see cref="System.Timers.Timer"/>.
        /// </summary>
        private static void InitUpdateTimer()
        {
            updateTimer = new System.Timers.Timer();
            updateTimer.Interval = 24 * 60 * 60 * 1000; // 24 hours
            updateTimer.Elapsed += new ElapsedEventHandler(UpdateNotifyTimerElapsed);
            updateTimer.Start();
        }

        /// <summary>
        /// Initialization for the blocking <see cref="Timer"/>.
        /// </summary>
        private static void InitLikingTimer()
        {
            blockingTimer = new Timer();
            blockingTimer.Interval = 10;
            blockingTimer.Tick += new EventHandler(LikingTimerTick);
        }
        
        /// <summary>
        /// Notifying the user for a new update if available. 
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private static void UpdateNotifyTimerElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateNotifier.Instance.NotifyForUpdate();
        }

        /// <summary>
        /// The blocking timer tick event.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private static void LikingTimerTick(object sender, EventArgs e)
        {
            string activeWindowTitle = GetActiveWindowTitle();

            if (activeWindowTitle.IndexOf("Hot or Not", StringComparison.Ordinal) != -1)
            //if (activeWindowTitle.Contains("Notepad"))
            {
                SendKeys.SendWait("1");
            }
        }


        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder buffer = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            return GetWindowText(handle, buffer, nChars) > 0 ? buffer.ToString() : string.Empty;
        }

        /// <summary>
        /// Initializes the necessary controls for the <see cref="MainForm"/>.
        /// </summary>
        private void InitControls()
        {
            //AddWindowNameForm = new AddWindowNameForm();
            AboutBox = new AboutBox();

            InitLikingTimer();
            InitUpdateTimer();

            //this.ShowBallonTextToolTip(string.Format(CultureInfo.InvariantCulture, "Make {0} better!", Resources.Program_Name));
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for starting the blocking.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void StartBlockingMenuItemClick(object sender, EventArgs e)
        {
            this.StartBlocking();
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for stopping the blocking.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void StopBlockingMenuItemClick(object sender, EventArgs e)
        {
            this.StopBlocking();
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for displaying the <see cref="AddWindowNameForm"/> form.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void AddWindowNameMenuItemClick(object sender, EventArgs e)
        {
            //if (AddWindowNameForm.Visible)
            //{
            //    AddWindowNameForm.Focus();
            //    return;
            //}

            this.StopBlocking();
            
            try
            {
                //AddWindowNameForm = new AddWindowNameForm();
                //AddWindowNameForm.ShowDialog(this);
            }
            catch (ArgumentNullException argumentNullException)
            {
                //LogSystem.Instance.AddToLog(argumentNullException, false);
            }
            
            this.StartBlocking();
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for executing the <see cref="UpdateNotifier"/>.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void UpdateCheckMenuItemClick(object sender, EventArgs e)
        {
            //UpdateNotifier.Instance.NotifyForUpdate();
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for displaying the <see cref="AboutBox"/> form.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void AboutBoxMenuItemClick(object sender, EventArgs e)
        {
            this.OpenAboutBox();
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for exiting the application.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            allowClose = true;

            this.Dispose();

            Application.Exit();
        }

        /// <summary>
        /// Start the blocking.
        /// </summary>
        private void StartBlocking()
        {
            try
            {
                blockingTimer.Start();

                if (this.miStartLiking.Enabled)
                {
                    this.miStopLiking.Enabled = this.miStartLiking.Enabled;
                    this.miStartLiking.Enabled = !this.miStartLiking.Enabled;
                }

                //this.niTray.Icon = Resources.app_icon_default;

                //ProgramStatus.Instance.AddStatus(new Status(StatusType.Start_Blocking, 5000, 4000));
                this.ShowBallonTextToolTip("has started liking.");
            }
            catch (ArgumentNullException ex)
            {
                this.ShowBallonExceptionToolTip();
                //LogSystem.Instance.AddToLog(ex, false);
            }
        }

        /// <summary>
        /// Stop the blocking.
        /// </summary>
        private void StopBlocking()
        {
            try
            {
                blockingTimer.Stop();

                if (this.miStopLiking.Enabled)
                {
                    this.miStartLiking.Enabled = this.miStopLiking.Enabled;
                    this.miStopLiking.Enabled = !this.miStopLiking.Enabled;
                }

                //this.niTray.Icon = Resources.app_icon_turned_off;
                this.ShowBallonTextToolTip("has stopped liking.");
            }
            catch (NullReferenceException ex)
            {
                this.ShowBallonExceptionToolTip();
                //LogSystem.Instance.AddToLog(ex, false);
            }
        }

        /// <summary>
        /// Opening the <see cref="AboutBox"/>.
        /// </summary>
        private void OpenAboutBox()
        {
            if (AboutBox.Visible)
            {
                AboutBox.Focus();
                return;
            }

            using (AboutBox = new AboutBox())
            {
                AboutBox.ShowDialog(this);
            }
        }

        /// <summary>
        /// Displays a balloon tip with the specified title, text, and icon in the taskbar for the specified time period.
        /// </summary>
        /// <param name="tipText">The text to display on the balloon tip.</param>
        /// <param name="timeout">The time period, in milliseconds, the balloon tip should display.</param>
        /// <param name="tipIcon">One of the <see cref="ToolTipIcon"/> values.</param>
        public void ShowBallonTextToolTip(string tipText, int timeout = 3000, ToolTipIcon tipIcon = ToolTipIcon.Info)
        {
            this.niTray.ShowBalloonTip(timeout, Resources.Settings_ProgramName, tipText, tipIcon);
        }

        /// <summary>
        /// Show exception balloon tooltip.
        /// </summary>
        /// <param name="timeout">The time period, in milliseconds, the balloon tip should display.</param>
        private void ShowBallonExceptionToolTip(int timeout = 3000)
        {
            this.niTray.ShowBalloonTip(timeout, Resources.Settings_ProgramName, "has thrown an exception", ToolTipIcon.Error);
        }

        /// <summary>
        /// Double mouse click event for showing the <see cref="AboutBox"/>.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> e.</param>
        private void TrayNotifyIconMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.OpenAboutBox();
            }
        }
    }
}