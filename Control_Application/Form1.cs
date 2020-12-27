using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace Control_Application
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
            init();

        }

        private void init()
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM3";
            serialPort.BaudRate = 9600;
            
            try
            {
                serialPort.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            ResetServos();

        }
        
        private void trackBarServo_0_Scroll(object sender, EventArgs e)
        {
            int servoPos = trackBarServo_0.Value;


            if (serialPort.IsOpen)
            {
                labelServoPos_0.Text = "Position: " + servoPos.ToString();
                SendServoInfo(0, servoPos);


            }


        }

        private void trackBarServo_1_Scroll(object sender, EventArgs e)
        {
            int servoPos = trackBarServo_1.Value;

            if (serialPort.IsOpen)
            {
                labelServoPos_1.Text = "Position: " + servoPos.ToString();
                SendServoInfo(1, servoPos);

            }

            if (serialPort.IsOpen)
            {
                labelServoPos_1.Text = "Position: " + servoPos.ToString();
                SendServoInfo(2, servoPos);

            }

        }

        private void trackBarServo_2_Scroll(object sender, EventArgs e)
        {
            int servoPos = trackBarServo_2.Value;

            if (serialPort.IsOpen)
            {
                labelServoPos_2.Text = "Position: " + servoPos.ToString();
                SendServoInfo(3, servoPos);

            }

        }

        private void trackBarServo_3_Scroll(object sender, EventArgs e)
        {
            int servoPos = trackBarServo_3.Value;

            if (serialPort.IsOpen)
            {
                labelServoPos_3.Text = "Position: " + servoPos.ToString();
                SendServoInfo(4, servoPos);

            }

        }

        private void trackBarServo_4_Scroll(object sender, EventArgs e)
        {
            int servoPos = trackBarServo_4.Value;

            if (serialPort.IsOpen)
            {
                labelServoPos_4.Text = "Position: " + servoPos.ToString();
                SendServoInfo(5, servoPos);

            }

        }

        private void trackBarServo_5_Scroll(object sender, EventArgs e)
        {
            int servoPos = trackBarServo_5.Value;

            if (serialPort.IsOpen)
            {
                labelServoPos_5.Text = "Position: " + servoPos.ToString();
                SendServoInfo(6, servoPos);

            }

        }






        private void SendServoInfo(int channel, int pos)
        {
            string message = channel.ToString() + ':' + pos.ToString() + '*';

            try
            {
                serialPort.Write(message);

            }
            catch
            {

            }

        }

        private void ResetServos()
        {
            int centrePosition = 90;
            trackBarServo_0.Value = centrePosition;
            trackBarServo_1.Value = centrePosition;
            trackBarServo_2.Value = centrePosition;
            trackBarServo_3.Value = centrePosition;
            trackBarServo_4.Value = centrePosition;
            trackBarServo_5.Value = centrePosition;

            labelServoPos_0.Text = "Position: " + centrePosition.ToString();
            labelServoPos_1.Text = "Position: " + centrePosition.ToString();
            labelServoPos_2.Text = "Position: " + centrePosition.ToString();
            labelServoPos_3.Text = "Position: " + centrePosition.ToString();
            labelServoPos_4.Text = "Position: " + centrePosition.ToString();
            labelServoPos_5.Text = "Position: " + centrePosition.ToString();

            for (int channel = 0; channel < 7; channel++)
            {
                SendServoInfo(channel, centrePosition);

            }

        }

        private void buttonResetServos_Click(object sender, EventArgs e)
        {
            ResetServos();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetServos();

        }

        
    }

}
