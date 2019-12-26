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
    public sealed partial class TextBoxPage : Page
    {

        //文本信息
        string text = "";
        //选择的文本信息
        string selectedText = "";
        //是否发生粘贴
        string pasteTest = "";

        public TextBoxPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 文本变化的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            text = TextBox1.Text;
            ShowInformation();
        }

        /// <summary>
        /// 文本选择的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            selectedText = TextBox1.SelectedText;
            ShowInformation();
        }

        /// <summary>
        /// 粘贴事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_Paste(object sender, TextControlPasteEventArgs e)
        {
            text = TextBox1.Text;
            selectedText = TextBox1.SelectedText;
            pasteTest = "发生了粘贴操作";
            ShowInformation();
        }

        /// <summary>
        /// 操作信息展示
        /// </summary>
        private void ShowInformation()
        {
            textBlock1.Text = "文本信息：" + text + "选择的信息：" + selectedText + "粘贴的信息：" + pasteTest;
        }
    }
}
