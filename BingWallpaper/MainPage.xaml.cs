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

namespace BingWallpaper
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string TodayPictureUri = "http://appserver.m.bing.net/BackgroundImageService/TodayImageService.svc/GetTodayImage?dateOffset=-0" +
                "&urlEncodeHeaders=true&osName=windowsPhone&osVersion=8.10&orientation=480x800&deviceName=WP8Device&mkt=zh-CN";
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
        }

        /// <summary>
        /// 进入当前的页面
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            background.UriSource = new Uri(TodayPictureUri);
        }

        /// <summary>
        /// 查看今天的壁纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void today_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DayPicturesPage), 0);
        }

        /// <summary>
        /// 查看昨天的壁纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yesterday_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DayPicturesPage), 1);
        }

        /// <summary>
        /// 查看两天前的壁纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twodayago_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DayPicturesPage), 2);

        }

        /// <summary>
        /// 查看三天前的壁纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void threedayage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DayPicturesPage), 3);

        }

        /// <summary>
        /// 查看更早的壁纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void other_Click(object sender, RoutedEventArgs e)
        {
            showMorePicture.Begin();
        }

        /// <summary>
        /// 查看更早的壁纸 减少天数的图标按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minus_bar_Click(object sender, RoutedEventArgs e)
        {
            int day = Int32.Parse(dayNumber.Text);
            if (day > 0)
            {
                day--;
                dayNumber.Text = day.ToString();
            }
        }

        /// <summary>
        /// 查看更早的壁纸，增加天数的图标按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plus_bar_Click(object sender, RoutedEventArgs e)
        {
            int day = Int32.Parse(dayNumber.Text);
            day++;
            dayNumber.Text = day.ToString();
        }

        /// <summary>
        /// 前往查看自定义天数的壁纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void go_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DayPicturesPage), Int32.Parse(dayNumber.Text));
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (e.Size.Width <= 500)
            {
                background.UriSource = new Uri(TodayPictureUri);
            }
            else
            {
                //background.UriSource = new Uri(TodayPictureUri_Big);
            }
        }
    }
}
