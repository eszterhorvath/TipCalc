using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Forms.Platforms.Uap.Views;
using System;
using TipCalc.Forms.UI;

namespace TipCalc.Forms.UWP
{
    public sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }
    public abstract class TipCalcApp : MvxWindowsApplication<MvxFormsWindowsSetup<Core.App, FormsApp>, Core.App, FormsApp, MvxFormsWindowsPage>
    {
    }
}
