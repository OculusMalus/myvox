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

namespace MyVox
{
    [Activity(Label = "HistoryActivity")]
    public class HistoryActivity : Activity
    {
        //String[] spokenHistoryListArray;
        private ListView spokenHistoryListView;
        Context context;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            String [] spokenHistoryListArray = Intent.GetStringArrayExtra("history_list");
            List<string> spokenHistoryList = spokenHistoryListArray.ToList();

            // Create your application here
            SetContentView(Resource.Layout.History);

            spokenHistoryListView = FindViewById<ListView>(Resource.Id.myListView);

            HistoryListViewAdapter adapter = new HistoryListViewAdapter(this, spokenHistoryList);
            spokenHistoryListView.Adapter = adapter;
            //Button back = FindViewById<Button>(Resource.Id.back);
            //back.Click += delegate { SetContentView(Resource.Layout.Main); };
        }
    }
}