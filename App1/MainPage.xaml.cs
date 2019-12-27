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

        private List<string> ReminderStrList;

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
                    case "按钮":
                        ContentFrame.Navigate(typeof(ControlProgrammingPage.ButtonPage));
                        break;
                    case "文本块":
                        ContentFrame.Navigate(typeof(ControlProgrammingPage.TextBlockPage));
                        break;
                    case "文本框":
                        ContentFrame.Navigate(typeof(ControlProgrammingPage.TextBoxPage));
                        break;
                    case "边框":
                        ContentFrame.Navigate(typeof(ControlProgrammingPage.BorderPage));
                        break;
                    case "超链接":
                        ContentFrame.Navigate(typeof(ControlProgrammingPage.HyperlinksButtonPage));
                        break;
                    case "单选按钮":
                        ContentFrame.Navigate(typeof(ControlProgrammingPage.RadioButtonPage));
                        break;
                    case "复选框":
                        ContentFrame.Navigate(typeof(ControlProgrammingPage.CheckBoxPage));
                        break;
                    case "进度条":
                        ContentFrame.Navigate(typeof(ControlProgrammingPage.ProgressBarPage));
                        break;



                    case "遍历可视化树":
                        ContentFrame.Navigate(typeof(PageTol.TraversingTreePage));
                        break;
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

        private void ASB_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            try
            {
                if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    sender.ItemsSource = ReminderStrList.Where(i => i.Contains(sender.Text));
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

        }

        private void ASB_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string txt = args.QueryText;  //输入的文本
            if (args.ChosenSuggestion != null)
            {
                //从提示框中选择某一项时触发
            }
            else
            {
                //用户在输入时敲回车或者点击右边按钮确认输入时触发
            }
        }

        private void ASB_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = args.SelectedItem.ToString();
        }
    }
}
