using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App1.ControlProgrammingPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ProgressBarPage : Page
    {
        public ProgressBarPage()
        {
            this.InitializeComponent();
            //第一次进入页面，设置进度条为不可见
            progressBar1.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 启动进度条，把进度条显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void begin_Click(object sender, RoutedEventArgs e)
        {
            //设置进度条为可见
            progressBar1.Visibility = Visibility.Visible;
            if (radioButton1.IsChecked == true)
            {
                //设置进度条为不可重复模式
                progressBar1.IsIndeterminate = false;
                //使用一个定时器 每一秒触发一下进度的改变
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else
            {
                //设置进度条的值为0
                progressBar1.Value = 0;
                //设置进度条为重复模式
                progressBar1.IsIndeterminate = true;
            }
        }

        /// <summary>
        /// 取消进度条，把进度条隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void end_Click(object sender, RoutedEventArgs e)
        {
            //隐藏进度条
            progressBar1.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 定时器的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void timer_Tick(object sender, object e)
        {

            //如果进度没有达100则在原来的进度基础上再增加10
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 10;
            }
            else
            {
                //进度完成 移除定时器的定时事件
                (sender as DispatcherTimer).Tick -= timer_Tick;
                //停止定时器的运行
                (sender as DispatcherTimer).Stop();
                await new MessageDialog("进度完成").ShowAsync();
            }
        }
    }
}
