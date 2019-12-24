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

namespace App1.PageTol
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class TraversingTreePage : Page
    {
        string visulTreeStr = "";
        public TraversingTreePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 单击事件 弹出XAML 页面里面StackPanel控件的可视化树的所有对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            visulTreeStr = "";
            GetChildType(stackPanel);
            MessageDialog messageDialog = new MessageDialog(visulTreeStr);
            
            async messageDialog.ShowAsync();
        }

        public void GetChildType(DependencyObject reference)
        {
            //获取子对象的个数
            int count = VisualTreeHelper.GetChildrenCount(reference);
            //如果子对象的个数不为0将继续递归调用
            if (count > 0)
            {
                for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(reference) - 1; i++)
                {
                    //获当前节点的子对象
                    var child = VisualTreeHelper.GetChild(reference, i);
                    //获取子对象的类型
                    visulTreeStr += child.GetType().ToString() + count + " ";
                    //递归调用
                    GetChildType(child);
                }

            }
        }
    }
}
