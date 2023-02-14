using System;
using System.IO;
using System.Windows.Forms;

public class DriveMonitor : Form
{
    private Label driveStatusLabel;
    private System.Windows.Forms.Timer timer;
    private bool isConnected;
    private System.Windows.Forms.Timer minimizeTimer;

    public DriveMonitor()
    {
        // Set the window size and label
        this.Size = new System.Drawing.Size(300, 100);
        this.Text = "Drive D Status";

        // Initialize GUI elements
        driveStatusLabel = new Label();
        driveStatusLabel.Text = "Checking drive status...";
        driveStatusLabel.Dock = DockStyle.Fill;
        driveStatusLabel.Font = new Font("Arial", 12);

        // Initialize timer
        timer = new System.Windows.Forms.Timer();
        timer.Interval = 1000; // update status every 1 second
        timer.Tick += Timer_Tick;
        timer.Start();

        // Initialize minimize timer
        minimizeTimer = new System.Windows.Forms.Timer();
        minimizeTimer.Interval = 5000; // minimize after 5 seconds
        minimizeTimer.Tick += MinimizeTimer_Tick;

        // Add GUI elements to form
        Controls.Add(driveStatusLabel);

        // Make the form always visible
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MinimizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.ShowInTaskbar = true;
        this.Show();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        // Check if D: drive is connected
        isConnected = Directory.Exists("D:\\");

        // Update GUI based on drive status
        if (isConnected)
        {
            driveStatusLabel.Text = "D: drive is connected";
            driveStatusLabel.BackColor = System.Drawing.Color.Green;
            if (this.WindowState == FormWindowState.Normal)
            {
                minimizeTimer.Start();
            }
        }
        else
        {
            driveStatusLabel.Text = "D: drive is disconnected Check Network Attached Storage.";
            driveStatusLabel.BackColor = System.Drawing.Color.Red;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                minimizeTimer.Stop();
            }
        }
    }  
    private void MinimizeTimer_Tick(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
        minimizeTimer.Stop();
    }

[STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new DriveMonitor());
    }
} 