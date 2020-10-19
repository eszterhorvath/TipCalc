using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;
using TipCalc.Core.ViewModels;

namespace TipCalc.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            // it tells the IoC Container that whenever any code requests an ICalculationService reference,
            // an object of type CalculationService should be created and returned
            Mvx.IoCProvider.RegisterType<ICalculationService, CalculationService>();

            RegisterAppStart<TipViewModel>();
        }
    }
}
