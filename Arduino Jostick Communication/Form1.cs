using System.DirectoryServices;
using System.IO.Ports;

namespace Arduino_Jostick_Communication
{
    public partial class Form1 : Form
    {
        private SerialPort? serial_Port; // 멤버변수 선언
        private String? serial_data;
        private int num;
        private String? str_directionX;
        private String? str_directionY;
        String? str_offsetX;
        String? str_offsetY;
        // 민감도 값
        String? str_sensitivity;
        MovingForm? movingForm;

        public Form1()
        {
            InitializeComponent();
            String[] portNames = SerialPort.GetPortNames();
            textBox_Aim_Sensitivity.KeyPress += textBox_Number_KeyPress;
            foreach (String portName in portNames)
            {
                this.textBox_PortNumber.Text = portName;
            }
            this.serial_Port = new SerialPort();
            movingForm = new MovingForm(10, "W", "A", "S", "D");
        }

        private void textBox_Number_KeyPress(object? sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            // 입력된 키가 숫자가 아니거나 백스페이스, 또는 Delete 키인 경우 허용
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 127)
            {
                // 이벤트를 처리하지 않음(입력 제한)
                e.Handled = true;
            }
            else
            {
                if (int.TryParse(textBox_Aim_Sensitivity.Text + e.KeyChar, out num))
                {
                    // 숫자가 1보다 작거나 100보다 큰 경우 허용하지 않음
                    if (num < 1 || num > 100)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            if (this.serial_Port != null && this.serial_Port.IsOpen)
            {
                this.textBox_PortNumber.Text = "이미 포트가 열려있습니다.";
                Console.WriteLine("이미 포트가 열려있습니다.");
            }
            else
            {
                String temporary = this.textBox_PortNumber.Text;
                if (temporary.Equals(String.Empty))
                {
                    this.textBox_PortNumber.Text = "포트넘버가 입력이 안되었습니다.";
                    Console.WriteLine("포트넘버가 입력이 안되었습니다.");
                    return;
                }
                else
                {
                    // 아두이노 시리얼 통신을 위한 기본 설정
                    if (this.serial_Port != null)
                    {
                        this.serial_Port.PortName = this.textBox_PortNumber.Text;
                        this.serial_Port.BaudRate = 115200;
                        this.serial_Port.DataBits = 8;
                        this.serial_Port.StopBits = StopBits.One;
                        this.serial_Port.Parity = Parity.None;
                        this.serial_Port.DataReceived += serialport_DataReceived;
                        this.serial_Port.Open();
                    }
                }
            }
        }

        private void serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            if (serial_Port != null)
                this.serial_data = this.serial_Port.ReadLine();
            if (serial_data == null) return;
            String[] parsingData = this.serial_data.Split(',');

            if (parsingData.Length >= 5)
            {
                // W,A,S,D 값
                str_directionX = parsingData[0];
                str_directionY = parsingData[1];
                // X, Y 값
                str_offsetX = parsingData[2];
                str_offsetY = parsingData[3];
                // 민감도 값
                str_sensitivity = parsingData[4];

                this.label_Input_Data.Invoke(new Action(() =>
                {
                    label_Input_Data.Text = $"방향 X축 : {str_directionX}\n방향 Y축 : {str_directionY}\n에임 X축 : {str_offsetX}\n에임 Y축 : {str_offsetY}";
                }));

                this.label_Aim_Sensitivity.Invoke(new Action(() =>
                {
                    label_Aim_Sensitivity.Text = str_sensitivity;
                }));

                if (this.movingForm != null)
                {
                    movingForm.UpdateValues(num, str_directionX, str_directionY, str_offsetX, str_offsetY);
                    Console.WriteLine("form1 serialport_DataReceived : " + num+ str_directionX+ str_directionY+ str_offsetX+ str_offsetY);
                    movingForm.MoveForm();

                    
                }
                    
            }
            else
            {
                return;
            }
        }

        private void button_Aim_Sensitivity_Click(object sender, EventArgs e)
        {
            string strNum = num.ToString();
            if (serial_Port != null) this.serial_Port.Write(strNum);
            else return;
        }

        private void button_Moving_Test_Click(object sender, EventArgs e)
        {
            if(movingForm != null)
            movingForm.Show();
        }
    }
}