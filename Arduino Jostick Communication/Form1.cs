using System.DirectoryServices;
using System.IO.Ports;

namespace Arduino_Jostick_Communication
{
    public partial class Form1 : Form
    {
        private SerialPort? serial_Port; // ������� ����
        private String? serial_data;
        private int num;
        private String? str_directionX;
        private String? str_directionY;
        String? str_offsetX;
        String? str_offsetY;
        // �ΰ��� ��
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
            // �Էµ� Ű�� ���ڰ� �ƴϰų� �齺���̽�, �Ǵ� Delete Ű�� ��� ���
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 127)
            {
                // �̺�Ʈ�� ó������ ����(�Է� ����)
                e.Handled = true;
            }
            else
            {
                if (int.TryParse(textBox_Aim_Sensitivity.Text + e.KeyChar, out num))
                {
                    // ���ڰ� 1���� �۰ų� 100���� ū ��� ������� ����
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
                this.textBox_PortNumber.Text = "�̹� ��Ʈ�� �����ֽ��ϴ�.";
                Console.WriteLine("�̹� ��Ʈ�� �����ֽ��ϴ�.");
            }
            else
            {
                String temporary = this.textBox_PortNumber.Text;
                if (temporary.Equals(String.Empty))
                {
                    this.textBox_PortNumber.Text = "��Ʈ�ѹ��� �Է��� �ȵǾ����ϴ�.";
                    Console.WriteLine("��Ʈ�ѹ��� �Է��� �ȵǾ����ϴ�.");
                    return;
                }
                else
                {
                    // �Ƶ��̳� �ø��� ����� ���� �⺻ ����
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
                // W,A,S,D ��
                str_directionX = parsingData[0];
                str_directionY = parsingData[1];
                // X, Y ��
                str_offsetX = parsingData[2];
                str_offsetY = parsingData[3];
                // �ΰ��� ��
                str_sensitivity = parsingData[4];

                this.label_Input_Data.Invoke(new Action(() =>
                {
                    label_Input_Data.Text = $"���� X�� : {str_directionX}\n���� Y�� : {str_directionY}\n���� X�� : {str_offsetX}\n���� Y�� : {str_offsetY}";
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