﻿using MobileTestApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test2 : ContentPage
    {
      
       public Test2()
        {
            InitializeComponent();
            BindingContext = new Test2ViewModel();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}