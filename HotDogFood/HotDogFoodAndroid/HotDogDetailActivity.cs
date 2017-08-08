using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HotDogFood.Core.Model;
using HotDogFood.Core.Service;

namespace HotDogFoodAndroid
{
    [Activity(Label = "Hot Dog Detail", MainLauncher = true)]
    public class HotDogDetailActivity : Activity
    {
        private ImageView hotDogImageView;
        private TextView hotDogNameTextView;
        private TextView shortDescriptionTextView;
        private TextView descriptionTextView;
        private TextView priceTextView;
        private EditText amountEditText;
        private Button cancelButton;
        private Button orderButton;

        private HotDog selectedHotDog;
        private HotDogDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //set view
            SetContentView(Resource.Layout.HotDogDetailView);

            //instantiate data
            dataService = new HotDogDataService();
            selectedHotDog = dataService.GetHotDogById(1);

            //get all the controls
            FindControls();
            BindData();
            HandleEvents();
        }

        private void FindControls()
        {
            //get all the controls
            hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogImageView);
            hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogNameTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
            
        }

        private void BindData()
        {
            hotDogNameTextView.Text = selectedHotDog.Name;
            shortDescriptionTextView.Text = selectedHotDog.ShortDescription;
            descriptionTextView.Text = selectedHotDog.Description;
            priceTextView.Text = "Price: " + selectedHotDog.Price;

            //set image later
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("You pressed cancel button");
            dialog.SetMessage("Alo alo alo");
            dialog.Show();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {

            int amount = 0;
            int.TryParse(amountEditText.Text, out amount);

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Confirmation");
            dialog.SetMessage("Your hotdog has been added to your cart!");
            dialog.Show(); 
        }
    }
}