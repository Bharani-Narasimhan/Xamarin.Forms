﻿using System;

namespace Xamarin.Forms.Controls
{
	public partial class VisualGallery : ContentPage
	{
		bool isVisible = false;
		double percentage = 0.0;

		public VisualGallery()
		{
			InitializeComponent();

			BindingContext = this;
		}

		public double PercentageCounter
		{
			get { return percentage; }
			set
			{
				percentage = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(Counter));
			}
		}

		public double Counter => percentage * 10;

		protected override void OnAppearing()
		{
			isVisible = true;

			base.OnAppearing();

			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				var progress = PercentageCounter + 0.1;
				if (progress > 1)
					progress = 0;

				PercentageCounter = progress;

				return isVisible;
			});
		}

		protected override void OnDisappearing()
		{
			isVisible = false;

			base.OnDisappearing();
		}

		async void OnShowAlertClicked(object sender, EventArgs e)
		{
			var result = await DisplayAlert("Material Design", "This should be a material alert.", "YAY!", "NAH");
			await DisplayAlert("Material Design", $"You selected: {result}.", "OK");
		}

		async void OnShowActionsClicked(object sender, EventArgs e)
		{
			var result = await DisplayActionSheet("Material Design", "Cancel", "NUKE!", "One", "Two", "Three");
			await DisplayAlert("Material Design", $"You selected: {result}.", "OK");
		}
	}
}
