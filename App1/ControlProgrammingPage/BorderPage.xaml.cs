using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App1.ControlProgrammingPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BorderPage : Page
    {
        public BorderPage()
        {
            this.InitializeComponent();
            //动态填充brdTest里面的子元素
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 1000;
            rectangle.Height = 1000;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Blue);
            rectangle.Fill = solidColorBrush;
            this.brdTest.Child = rectangle;
        }

        /// <summary>
        /// 点击事件 通过修改Opacity来实现，当用户点击文本时，出现y一个文本的边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            //0表示完全透明 1表示完全显示出来
            TextBorder.BorderBrush.Opacity = 0.5;
        }
    }
}
