# DriveStatus
Overall the program creates a simple Windows Form application that monitors the status of drive D and displays the status in a label on the form. It uses the Timer control to periodically check the status of the D drive and update the form accordingly, and also uses the Timer control to minimize the form if the D drive is connected after a certain period of time.
To change the specified letter of the Drive Change the following lines in the code
this.Text = "Drive D Status";
 isConnected = Directory.Exists("D:\\");
  driveStatusLabel.Text = "D: drive is connected";
  driveStatusLabel.Text = "D: drive is disconnected Check Network Attached Storage.";
