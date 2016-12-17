using System;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int count = 0, alpan = 0;
        public bool buttonStart = false, judge = true;
        public string select;
        //创建字符串数组防止重复抽取
        public string[] already = new string[18];
        public int nums = 0;
        public string output;
        /// <summary>
        /// 随机数程序，产生字母随机数和座位号随机数
        /// </summary>
        private void randomNumberProgram()
        {

            try
            {
                Random r = new Random();
                //为字母随机数新建线程
                Thread th1 = new Thread(randomAlpanResult);
                //后台放置于后台
                th1.IsBackground = true;
                //线程开始
                th1.Start();
                int resultTextbox2Number = 0, resulTextbox4Number = 0;
                while (buttonStart == true)
                {
                    resultTextbox2Number = r.Next(1, 13);
                    textBox2.Text = resultTextbox2Number.ToString("D2");
                    //tostring后面加Dx（x为数字）则可以输出多少位数
                    if (resultTextbox2Number > 6)
                    {
                        textBox4.Text = "2";
                        randomAlpanResult();
                    }
                    else
                    {
                        resulTextbox4Number = r.Next(1, 3);
                        //判断大组号
                        switch (resulTextbox4Number)
                        {
                            case 1:
                                textBox4.Text = "1";
                                break;
                            case 2:
                                textBox4.Text = "3";
                                break;
                        }
                        randomAlpanResult();
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 抽奖事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //触发事件，开始抽奖
                if (button1.Text == "开始")
                {
                    //如果抽奖次数不等于0
                    if (count != 0)
                    {
                        buttonStart = true;
                        button1.Text = "停止";
                        //为随机数程序创建线程
                        Thread th = new Thread(randomNumberProgram);
                        //线程处于后台
                        th.IsBackground = true;
                        //线程开始
                        th.Start();
                    }
                    //如果抽奖次数等于0且没有选择项目
                    else if (count == 0 && select == null)
                    {
                        MessageBox.Show("你还没有选择抽奖项目哦~");
                    }
                    //其他情况均为抽奖次数用尽
                    else
                    {
                        MessageBox.Show("当前抽奖次数用尽了哦~");
                    }
                }
                else if (button1.Text == "停止")
                {
                    buttonStart = false;
                    //抽奖次数减一
                    count--;
                    button1.Text = "开始";
                    //输出剩余信息
                    textbox3Output();
                }
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //去掉线程检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 每个奖品抽奖次数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                select = comboBox1.SelectedItem.ToString();
                if (select == "守望先锋盒子抱枕~" && count == 0)
                {
                    count = 1;
                    textBox3.Text = select;
                }
                else if ((select == "纪念版卡片U盘~" || select == "表情包抱枕~") && count == 0)
                {
                    count = 3;
                    textBox3.Text = select;
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 出现意外时候增加抽奖次数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //次数大于三或者奖项只有一个的守望先锋抱枕或者不选择抽奖项的时候不增加
                if (count == 3 || select == "守望先锋盒子抱枕~" && count == 1 || (select == null && count == 0))
                { }
                else
                {
                    //增加抽奖次数
                    count += 1;
                    textBox3.Clear();
                    textBox3.Text = (select + "抽奖机会还有" + count.ToString() + "次");
                }
            }
            catch { }
        }

        /// <summary>
        /// 随机字母函数
        /// </summary>
        private void randomAlpanResult()
        {
            try
            {
                Random rd = new Random();
                int resultAlpanNumber = 0;
                resultAlpanNumber = rd.Next(1, 16);
                switch (resultAlpanNumber)
                {
                    case 1:
                        textBox1.Text = "A";
                        break;
                    case 2:
                        textBox1.Text = "B";
                        break;
                    case 3:
                        textBox1.Text = "C";
                        break;
                    case 4:
                        textBox1.Text = "D";
                        break;
                    case 5:
                        textBox1.Text = "E";
                        break;
                    case 6:
                        textBox1.Text = "F";
                        break;
                    case 7:
                        textBox1.Text = "G";
                        break;
                    case 8:
                        textBox1.Text = "H";
                        break;
                    case 9:
                        textBox1.Text = "I";
                        break;
                    case 10:
                        textBox1.Text = "J";
                        break;
                    case 11:
                        textBox1.Text = "K";
                        break;
                    case 12:
                        textBox1.Text = "L";
                        break;
                    case 13:
                        textBox1.Text = "M";
                        break;
                    case 14:
                        textBox1.Text = "N";
                        break;
                    case 15:
                        textBox1.Text = "O";
                        break;
                }
            }
            catch { }
        }
        /// <summary>
        /// 信息文本框输出程序
        /// </summary>
        private void textbox3Output()
        {
            try
            {
                output = textBox1.Text + textBox4.Text + textBox2.Text;
                for (int i = 0; i < nums; i++)
                {
                    if (output == already[i])
                    {
                        judge = false;
                    }
                }
                if (judge == true)
                {
                    textBox3.Clear();
                    already[nums] = output;
                    nums += 1;
                    if (count != 0)
                    {
                        textBox3.Text = (select + "抽奖机会还有" + count.ToString() + "次");
                    }
                    else if (count == 0)
                    {
                        textBox3.AppendText("当前没有抽奖机会了~");
                    }
                }
                else if (judge == false)
                {
                    MessageBox.Show("该号码中过奖，请重新抽取");
                    count += 1;
                }
            }
            catch { }
        }
    }

}
