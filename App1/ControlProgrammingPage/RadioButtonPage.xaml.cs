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
    public sealed partial class RadioButtonPage : Page
    {
        public RadioButtonPage()
        {
            this.InitializeComponent();
        }

        private void a_Click(object sender, RoutedEventArgs e)
        {
            if (aa.IsChecked == true)
            {
                answer.Text = aa.Content.ToString();
            }
            else if (bb.IsChecked == true)
            {
                answer.Text = bb.Content.ToString();
            }
            else if (cc.IsChecked == true)
            {
                answer.Text = cc.Content.ToString();
            }
            else if (dd.IsChecked == true)
            {
                answer.Text = dd.Content.ToString();
            }
            else if (ee.IsChecked == true)
            {
                answer.Text = ee.Content.ToString();
            }
            else
            {
                answer.Text = ff.Content.ToString();
            }
        }
    }
}
