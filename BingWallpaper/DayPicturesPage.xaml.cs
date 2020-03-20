using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel;
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

namespace BingWallpaper
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class DayPicturesPage : Page
    {
        public DayPicturesPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 进入页面即开始加载网络的壁纸图片和信息
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter is int)
            {
                //订阅进度事件的处理程序
                WallpapersService.Current.GetOneDayWallpapersProgressEvent += OnOneDayWallpaperProgressEvent;
                //调用壁纸请求服务类来获取壁纸信息
                WallpapersService.Current.GetOneDayWallpapers((int)e.Parameter);
            }
        }

        /// <summary>
        /// 离开当前的页面则移除订阅的进度事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            WallpapersService.Current.GetOneDayWallpapersProgressEvent -= OnOneDayWallpaperProgressEvent;
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// 进度事件的处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  async void OnOneDayWallpaperProgressEvent(object sender, ProgressEventArgs e)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
             {
                 if (e.IsException)
                 {
                     //如果发生异常则显示异常信息
                     info.Text = "获取图片异常：" + e.ExceptionInfo;
                 }
                 else
                 {
                     //正常返回设置进度条的值
                     progress.Value = e.ProgressValue;
                     //进度完整
                     if (e.Complete)
                     {
                         //把显示进度的面板隐藏
                         tips.Visibility = Visibility.Collapsed;
                         //把壁纸信息绑定到列表中
                         pictureList.ItemsSource = e.Pictures;
                         Debug.WriteLine("e.Pictures.Count:" + e.Pictures.Count);
                     }
                 }
             });
        }

        /// <summary>
        /// 查看按钮的事件处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_Click(object sender, RoutedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
