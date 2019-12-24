using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App1
{
    public class CirclePanel : Panel
    {
        //自定义半径变量
        private double _radius = 0;
        public CirclePanel()
        {

        }

        //注册半径依赖属性
        public static readonly DependencyProperty RadiusProperty = DependencyProperty.RegisterAttached(
            "Radius",
            typeof(double),
            typeof(CirclePanel),
            new PropertyMetadata(0.0, OnRadiusPropertyChanged)
            );

        //自定义半径属性
        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        /// <summary>
        /// 实现半径属性改变事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
       private static void OnRadiusPropertyChanged(DependencyObject obj,DependencyPropertyChangedEventArgs e)
        {
            CirclePanel target = (CirclePanel)obj;
            target._radius = (double)e.NewValue;
            target.InvalidateArrange();
        }

        /// <summary>
        /// 重载MeasureOverride方法
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return base.ArrangeOverride(finalSize);
        }

    }
}
