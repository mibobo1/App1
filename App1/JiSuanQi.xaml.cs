using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class JiSuanQi : Page
    {
        //前一次按下的运算符
        private string Operation = "";
        //结果
        private int num1 = 0;
        public JiSuanQi()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// 数字按键的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitBtn_Click(object sender, RoutedEventArgs e)
        {
            //清除之前等号的操作
            if (Operation=="=")
            {
                OperationResult.Text = "";
                InputInformation.Text = "";
                Operation = "";
                num1 = 0;
            }
            string s = ((Button)sender).Content.ToString();
            OperationResult.Text = OperationResult.Text + s;
            InputInformation.Text = InputInformation.Text + s;
        }

        /// <summary>
        /// 删除之前的所有输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            OperationResult.Text = "";
            InputInformation.Text = "";
            Operation = "";
            num1 = 0;
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            OperationNum("=");
            InputInformation.Text = InputInformation.Text + "=";
            //显示结果
            OperationResult.Text = num1.ToString();

        }

        /// <summary>
        /// 加减乘除按键的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Operation == "=")
            {
                InputInformation.Text = OperationResult.Text;
                Operation = "";
            }

            String s = ((Button)sender).Content.ToString();
            //公式显示
            InputInformation.Text = InputInformation.Text + s;
            //运算
            OperationNum(s);
            //清空之前输入的数字
            OperationResult.Text = "";

        }

        /// <summary>
        /// 通过运算进行计算
        /// </summary>
        /// <param name="s"></param>
        private void OperationNum(string s)
        {
            if (OperationResult.Text != "=")
            {
                switch (Operation)
                {
                    case "":
                        num1 = Int32.Parse(OperationResult.Text);
                        Operation = s;
                        break;
                    case "+":
                        num1 = num1 + Int32.Parse(OperationResult.Text);
                        Operation = s;
                        break;
                    case "-":
                        num1 = num1 - Int32.Parse(OperationResult.Text);
                        Operation = s;
                        break;
                    case "*":
                        num1 = num1 * Int32.Parse(OperationResult.Text);
                        Operation = s;
                        break;
                    case "/":
                        num1 = num1 / Int32.Parse(OperationResult.Text);
                        Operation = s;
                        break;
                    default: break;
                }
            }
            else
            {
                Operation = s;
            }
        }

        /// <summary>
        /// 后退按钮处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                //返回上一个页面
                this.Frame.GoBack();
            }
        }
    }
}
