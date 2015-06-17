using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XboxMusicQueryPCL;


namespace AndroidMusicServiceApp
{
    [Activity(Label = "AndroidMusicServiceApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        XBoxMusicServicePCLClient client;
        private const string CLIENT_ID = "TestMe123";
        private const string CLIENT_SECRET = "7b9gmRqo8rdV2vl0hf91rlGn7eJPE3LhxBwFMiYGk/o=";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            client = new XBoxMusicServicePCLClient(CLIENT_ID, CLIENT_SECRET);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our search view from the layout resource and attach an event to it
            SearchView searchView = FindViewById<SearchView>(Resource.Id.searchView);

            searchView.QueryTextSubmit += async delegate 
            {
                try
                {
                    bool success = client.Connect();
                    string result = await client.FindAlbums(searchView.Query);
                    string s = result;
                }
                catch (Exception e)
                {
                    string s = e.Message;

                }
            };
        }
    }
}

