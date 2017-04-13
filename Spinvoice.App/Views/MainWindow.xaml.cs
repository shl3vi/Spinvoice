﻿using Spinvoice.App.Services;
using Spinvoice.App.ViewModels;
using Spinvoice.Domain.Company;
using Spinvoice.Domain.Exchange;
using Spinvoice.Infrastructure.DataAccess;

namespace Spinvoice.App.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var documentStoreRepository = new DocumentStoreRepository();
            var companyDataAccess = new CompanyDataAccess(documentStoreRepository);
            var companyRepository = new CompanyRepository(companyDataAccess);
            var exchangeRateDataAccess = new ExchangeRateDataAccess(documentStoreRepository);
            var exchangeRatesLoader = new ExchangeRatesLoader(exchangeRateDataAccess);
            var exchangeRatesRepository = new ExchangeRatesRepository(exchangeRateDataAccess);

            DataContext = new AppViewModel(companyRepository, exchangeRatesRepository, exchangeRatesLoader);
        }
    }
}
