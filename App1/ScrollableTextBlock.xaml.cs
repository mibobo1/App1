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

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace App1
{
    public sealed partial class ScrollableTextBlock : UserControl
    {

        private string text = "";
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                //解析文本信息进行排列显示
                ParseText(text);

            }
        }
        public ScrollableTextBlock()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 解析控件的Text属性的赋值
        /// </summary>
        /// <param name="value"></param>
        private void ParseText(string value)
        {
            string[] textBlockTexts = value.Split(' ');
            //清除之前的stackPanel面板的子元素
            this.stackPanel.Children.Clear();
            //重新添加stackPanel的子元素
            for (int i = 0; i < textBlockTexts.Length; i++)
            {
                TextBlock textBlock = this.GetTextBlock();
                textBlock.Text = textBlockTexts[i].ToString();
                this.stackPanel.Children.Add(textBlock);
            }
        }

        /// <summary>
        /// 创建一个自行折行的TextBlock
        /// </summary>
        /// <returns></returns>
        private TextBlock GetTextBlock()
        {
            TextBlock textBlock = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                FontSize = this.FontSize,
                FontFamily = this.FontFamily,
                FontWeight = this.FontWeight,
                Foreground = this.Foreground,
                Margin = new Thickness(0, 10, 0, 0)
            };
            return textBlock;
        }
    }
}
