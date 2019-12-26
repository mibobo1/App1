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

        }

        private void end_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
