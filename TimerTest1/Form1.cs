using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimerTest1
{
    public partial class Form1 : Form
    {   
        // 倒计时时间
        int countSet = 0;
        int countIndex = 0;

        bool countStart = false;

        //选择时间
        int selectCount = 0;

        // 文本输入
        int textCount = 0;
        bool textChange = false;

        public Form1()
        {
            InitializeComponent();
            
            //添加倒计时时间从1秒 ~ 50秒 
            int i = 0;
            for (i = 1; i <= 50; i++)
            {
                comboBox1.Items.Add(Convert.ToString(i, 10) + " 秒");
            }

           
            //默认选择第一个索引
            comboBox1.SelectedIndex = 0;    
         }

        private  void stop()
        {
            label3.Text = "0";
            countStart = false;
            textChange = false;
            button1.Text = "开始计时";
            System.Media.SystemSounds.Hand.Play();
            MessageBox.Show("倒计时间到");
        }


        private void button1_Click(object sender, EventArgs e)
        {   
            if (!countStart)
            {
                //获取定时时间
                string secCountStr = comboBox1.SelectedItem.ToString();
                string secCount = secCountStr.Substring(0, 2);

                //设置定时时间到全局变量countSet,并启动定时器
                selectCount = Convert.ToUInt16(secCount);
                if (textChange)
                {
                    textCount = Convert.ToUInt16(textBox1.Text);
                    countSet = textCount;
                } 
                else
                {
                    selectCount = Convert.ToUInt16(secCount);
                    countSet = selectCount;
                }
                
                countIndex = 0;
                progressBar1.Maximum = countSet;
                label3.Text = countSet.ToString();
                timer1.Start();
                countStart = true;
                button1.Text = "停止计时";
            }
            else
            {
                //倒计时时间倒，并关闭定时器
                timer1.Stop();

                //倒计时时间显示最大
                progressBar1.Value = 0;

                //剩余倒计时时间为0
                label3.Text = "0";
                countStart = false;
                textChange = false;
                button1.Text = "开始计时";
                MessageBox.Show("倒计时取消！！");

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (++countIndex == countSet)
            {
                //倒计时时间倒，并关闭定时器
                timer1.Stop();

                //倒计时时间显示最大
                progressBar1.Value = countIndex;

                //剩余倒计时时间为0
                stop();
            }
            else
            {  
                //将倒计时时间显示到进度条中
                progressBar1.Value = countIndex;
                int count = countSet - countIndex;

                //将倒计时剩余时间显示倒倒计时窗口中
                label3.Text = count.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textChange = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
