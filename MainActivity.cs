using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace FadeImageView
{
    [Activity(Label = "FadeImageView", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private FadeImageSample.FadeImageView image;
        private Button button;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            image = FindViewById<FadeImageSample.FadeImageView>(Resource.Id.imageView1);
            button = FindViewById<Button>(Resource.Id.btnChange);

            button.Click += BtnChange_Click;
        }

        private void BtnChange_Click(object sender, System.EventArgs e)
        {

            var catIDs =new int[] { Resource.Drawable.cat1, Resource.Drawable.cat2, Resource.Drawable.cat3 };

            Random rnd = new Random();
            int currentCat = rnd.Next(0, catIDs.Length);

            image.SetImageResource(catIDs[currentCat],true);
        }
    }
}

