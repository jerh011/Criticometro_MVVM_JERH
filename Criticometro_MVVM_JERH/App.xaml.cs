﻿using Criticometro_MVVM_JERH.Vista;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Criticometro_MVVM_JERH
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Page1());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
