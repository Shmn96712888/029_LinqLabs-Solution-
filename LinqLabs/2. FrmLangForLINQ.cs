using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//組件 System.Core.dll,
//namespace {}  System.Linq
//public static class Enumerable
//


//public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

//1. 泛型 (泛用方法)                                          (ex.  void SwapAnyType<T>(ref T a, ref T b)
//2. 委派參數 Lambda Expression (匿名方法簡潔版)               (ex.  MyWhere(nums, n => n %2==0);
//3. Iterator                                                (ex.  MyIterator)
//4. 擴充方法       

namespace Starter
{


    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n1, n2;
            n1 = 100;
            n2 = 200;

            MessageBox.Show(n1 + "," + n2);

            Swap(ref n1, ref n2);

            MessageBox.Show(n1 + "," + n2);
            //=======================
            string s1, s2;
            s1 = "aaaa";
            s2 = "bbbb";
            MessageBox.Show(s1 + "," + s2);
            Swap(ref s1, ref s2);
            MessageBox.Show(s1 + "," + s2);

        }

        void SwapObject(ref object n1, ref object n2)
        {
          
            object temp = n2;
            n2 = n1;
            n1 = temp;
        }


        static  void SwapAnyType<T>(ref T n1, ref T n2)
        {
            T temp = n2;
            n2 = n1;
            n1 = temp;
        }

        void Swap(ref string n1, ref string n2)
        {
            string temp = n2;
            n2 = n1;
            n1 = temp;
        }
        void Swap(ref int n1, ref int n2)
        {
            int temp = n2;
            n2 = n1;
            n1 = temp;
        }
        void Swap(ref Point n1, ref Point n2)
        {
            Point temp = n2;
            n2 = n1;
            n1 = temp;
        }
        void Swap(int n1, int n2, out int n3, out int n4)
        {
            n3 = n2;
            n4 = n1;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n1, n2;
            n1 = 100;
            n2 = 200;
            MessageBox.Show(n1 + "," + n2);
            //SwapAnyType<int>(ref n1, ref n2);
          
            SwapAnyType(ref n1, ref n2); // 推斷型別

            MessageBox.Show(n1 + "," + n2);

            //==============================
            string s1, s2;
            s1 = "aaa";
            s2 = "bbb";
            MessageBox.Show(s1 + "," + s2);
          
            SwapAnyType(ref s1, ref s2);

            MessageBox.Show(s1 + "," + s2);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //            嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
            //錯誤  CS0123  'ButtonX_Click' 沒有任何多載符合委派 'EventHandler'   LinqLabs C:\shared\LINQ\LinqLabs(Solution)\LinqLabs\2.FrmLangForLINQ.cs    108 作用中

            //            this.buttonX.Click += ButtonX_Click;

            //C# 1.0 具名方法
            this.buttonX.Click += new EventHandler(aaa);
            this.buttonX.Click += bbb;   

            //===============================
            //C# 2.0 匿名方法
            this.buttonX.Click += delegate (object sender1, EventArgs e1)
                                      {
                                          MessageBox.Show("C# 2.0 匿名方法");
                                      };

            //C# 3.0 匿名方法  lambda 運算式 => goes to
            this.buttonX.Click += (object sender1, EventArgs e1) => 
                                 // { 
                                      MessageBox.Show("C# 2.0 匿名方法 lambda ");
                                  //};


        }

        private void ButtonX_Click()
        {
            MessageBox.Show("buttonX click");
        }

        private void aaa(object sender, EventArgs e)
        {
            MessageBox.Show("aaa");
        }
        private void bbb(object sender, EventArgs e)
        {
            MessageBox.Show("bbb");
        }

        bool Test(int n)
        {
            //if (n > 5)
            //    return true;
            //else
            //    return false;

            return n > 5;
        }

        bool Test1(int n) //, int x)
        {
            return n % 2 == 0;
        }

        //Step 1: create delegate 型別
        //Step 2: create delegate Object (new ...)
        //Step 3: invoke / call method

        delegate bool MyDelegate(int n);

        private void button9_Click(object sender, EventArgs e)
        {
            bool result = Test(4);
            MessageBox.Show("result = " + result);
            //==========================

            MyDelegate delegateObj = new MyDelegate(Test);
            result = delegateObj.Invoke(7); //call method (_)
            MessageBox.Show("result = " + result);

            //=============================
            delegateObj = Test1;  //syntax sugar
            result= delegateObj(3);
            MessageBox.Show("result = " + result);

        }
    }
}
