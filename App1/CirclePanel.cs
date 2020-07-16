using System;
using Windows.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

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

            //最大的宽度的变量
            double maxElementWidth = 0;
            //遍历所有的子对象
            foreach(UIElement child in Children)
            {
                //测量子对象
                child.Measure(availableSize);
                maxElementWidth = Math.Max(child.DesiredSize.Width, maxElementWidth);
            }

            //获取两个半径的大小和最大的宽度的两倍作为面板的宽度
            double panelWith = 2 * this.Radius + 2 * maxElementWidth;
            //获取面板所分配的高度、宽度和计算出来的宽度的最小值作为面板的实际大小
            double width = Math.Min(panelWith, availableSize.Width);
            double heigh = Math.Min(panelWith, availableSize.Height);
            //return base.MeasureOverride(availableSize);
            return new Size(width, heigh);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {

            //当前的角度从0开始排列
            double degree = 0;
            //计算每个子对象所占用的角度大小
            double degreeStep = (double)360 / this.Children.Count;
            //计算
            double mX = this.DesiredSize.Width / 2;
            double mY = this.DesiredSize.Height / 2;
            //遍历所有子对象进行排列
            foreach(UIElement child in Children)
            {
                //把角度转换成弧度单位
                double angle = Math.PI * degree / 180.0;
                //根据弧度计算出圆弧上的x y的坐标值
                double x = Math.Cos(angle) * this._radius;
                double y = Math.Sin(angle) * this._radius;
                //使用变换效果让控件旋转角度 degree
                RotateTransform rotateTransform = new RotateTransform();
                rotateTransform.Angle = degree;
                rotateTransform.CenterX = 0;
                rotateTransform.CenterY = 0;
                child.RenderTransform = rotateTransform;
                //排列子对象
                child.Arrange(new Rect(mX + x, mY + y, child.DesiredSize.Width, child.DesiredSize.Height));

                //角度递增
                degree += degreeStep;
            }
            return finalSize;
        }

    }
}
