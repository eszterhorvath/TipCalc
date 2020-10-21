using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Logging;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;
        private readonly IMvxLog _logger;

        // dependency injection
        public TipViewModel(ICalculationService calculationService, IMvxLog logger)
        {
            _calculationService = calculationService;
            _logger = logger;
        }

        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _logger.Info("SubTotal changed from " + _generosity + " to " + value);
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);

                Recalculate();
            }
        }

        private int _generosity;
        public int Generosity
        {
            get => _generosity;
            set
            {
                _logger.Info("Generosity changed from " + _generosity + " to " + value);
                _generosity = value;
                RaisePropertyChanged(() => Generosity);

                Recalculate();
            }
        }

        private double _tip;
        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _subTotal = 100;
            _generosity = 10;

            Recalculate();
        }

        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
            _logger.Info("Calculated tip amount: " + Tip);
        }
    }
}
