using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1MVVM_DependencyProperty
{
    class Student:DependencyObject
    {
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name",typeof(string),typeof(Student));

        public static readonly DependencyProperty AgeProperty = DependencyProperty.Register("Age", typeof(int), typeof(Student), new PropertyMetadata()
        {
            DefaultValue = 0,
            CoerceValueCallback = new CoerceValueCallback(CoerceAge)
        }, new ValidateValueCallback(Student.IsRangeable));

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }


        public int MaxAge
        {
            get { return (int)GetValue(MaxAgeProperty); }
            set { SetValue(MaxAgeProperty, value); }
        }


        public static readonly DependencyProperty MaxAgeProperty =
            DependencyProperty.Register("MaxAge", typeof(int), typeof(Student), new PropertyMetadata(0)
            {
                CoerceValueCallback = new CoerceValueCallback(CoerceMaxAge),
                PropertyChangedCallback = new
                    PropertyChangedCallback((d, e) =>
                    {
                        Student stu = d as Student;
                        stu.CoerceValue(Student.AgeProperty);
                    })
            });

        public int MinAge
        {
            get { return (int)GetValue(MinAgeProperty); }
            set { SetValue(MinAgeProperty, value); }
        }

        public static readonly DependencyProperty MinAgeProperty =
            DependencyProperty.Register("MinAge", typeof(int), typeof(Student), new PropertyMetadata(new PropertyChangedCallback(
                (d, e) =>
                {
                    Student stu = d as Student;
                    //当最小年龄的值改变的时候强制回调最大年龄的年龄的值
                    stu.CoerceValue(Student.MaxAgeProperty);
                    stu.CoerceValue(Student.AgeProperty);
                })));

        PropertyMetadata metadata = new PropertyMetadata();
        //设置最大年龄时强制回调，因为最大年龄要大于最小年龄
        private static object CoerceMaxAge(DependencyObject d, object value)//这里包含两个参数一个是该数值将要应用到的对象和准备使用的值
        {
            Student stu = (Student)d;
            if ((int)value < stu.MinAge)
                return stu.MinAge;
            else
                return value;
        }
        //设置年龄的时候强制回调，因为他的值必须在最大年龄和最小年龄之间
        private static object CoerceAge(DependencyObject d, object value)
        {
            Student stu = d as Student;
            if ((int)value > stu.MaxAge)
                return stu.MaxAge;
            else if ((int)value < stu.MinAge)
                return stu.MinAge;
            else
                return value;
        }
        //验证回调，如果设置的值不满足要求 会抛出异常
        private static bool IsRangeable(object value)
        {
            int i = Convert.ToInt32(value);
            if (i >= 0 && i < 150)
                return true;
            else
                return false;
        }

        
    }

    class Dependency
    {
        
    }
}
