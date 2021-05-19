using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileTestApp1.ViewModels
{
    class TestViewModel : INotifyPropertyChanged
    {
        private string myText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string MyText
        {
            get => this.myText;

            set
            {
                this.myText = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.MyText)));
            }
        }

        public ICommand MyCommand => new Command(() => { this.MyText = "WhatEverTheTextYouWant"; });
    }
}
