using System;
using System.Collections.Generic;
using App1.Models;
using App1.ViewModels;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace App1.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            //DisplayAlert("Test", "Test", "Ok");
            var customScanPage = new CustomScanPage();
            Navigation.PushAsync(customScanPage);
        }
    }
}
