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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace App1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void nvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            //先判断是否选中了setting
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                //选中项的内容
                switch (args.InvokedItem)
                {
                    case "布局通用属性":
                        ContentFrame.Navigate(typeof(LayoutGeneralPage));
                        break;
                    case "网格布局":
                        ContentFrame.Navigate(typeof(GridLayoutPage));
                        break;
                    case "堆放布局":
                        ContentFrame.Navigate(typeof(StackLayoutPage));
                        break;
                    case "绝对布局":
                        ContentFrame.Navigate(typeof(AbsoluteLayoutPage));
                        break;
                    case "相对布局":
                        ContentFrame.Navigate(typeof(RelativeLayoutPage));
                        break;
                    case "适配布局":
                        ContentFrame.Navigate(typeof(FitLayoutPage));
                        break;
                    case "圆形布局":
                        ContentFrame.Navigate(typeof(CircleLayoutPage));
                        break;
                }
            }
        }
    }
}
