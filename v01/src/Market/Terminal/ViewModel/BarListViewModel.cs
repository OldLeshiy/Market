using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows;
using Model;
using Prism.Commands;
using Prism.Mvvm;
using WcfServicesProxy.QuoteServiceProxy;

namespace Terminal.ViewModel
{
    [Export]
    public class BarListViewModel : BindableBase
    {
        private ObservableCollection<Bar> _barListSource;
        private DateTime _dateFrom;
        private DateTime _dateTo;

        [ImportingConstructor]
        public BarListViewModel()
        {
            DateFrom = new DateTime(2016, 11, 1, 8, 0, 0, DateTimeKind.Utc);
            DateTo = new DateTime(2016, 11, 3, 12, 0, 0, DateTimeKind.Utc);
            LoadDataCommand = new DelegateCommand(LoadData);
        }

        public ObservableCollection<Bar> BarListSource
        {
            get { return _barListSource; }
            set { SetProperty(ref _barListSource, value); }
        }

        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set { SetProperty(ref _dateFrom, value); }
        }

        public DateTime DateTo
        {
            get { return _dateTo; }
            set
            {
                _dateTo = value;
                OnPropertyChanged(() => DateTo);
            }
        }

        public Symbol Pair { get; set; }

        public DelegateCommand LoadDataCommand { get; set; }

        private async void LoadData()
        {
            try
            {
                List<Bar> data;
                using (var qsp = new QuoteServiceClient())
                {
                    data = await qsp.GetQuotesAsync("test", DateFrom, DateTo, Interval.Hour);
                }

                BarListSource = new ObservableCollection<Bar>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}