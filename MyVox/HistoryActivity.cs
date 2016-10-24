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
using Android.Speech.Tts;

namespace MyVox
{
    [Activity(Label = "HistoryActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class HistoryActivity : Activity, TextToSpeech.IOnInitListener
    {
        String[] spokenHistoryListArray;
        private ListView spokenHistoryListView;
        private TextToSpeech textToSpeech;
        Java.Util.Locale lang;
        Context context;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            spokenHistoryListArray = Intent.GetStringArrayExtra("history_list");
            List<string> spokenHistoryList = spokenHistoryListArray.ToList();

            // Create your application here
            SetContentView(Resource.Layout.History);

            spokenHistoryListView = FindViewById<ListView>(Resource.Id.myListView);
            HistoryListViewAdapter adapter = new HistoryListViewAdapter(this, spokenHistoryList);
            spokenHistoryListView.Adapter = adapter;

            context = spokenHistoryListView.Context;
            textToSpeech = new TextToSpeech(this, this, "com.google.android.tts");

            lang = Java.Util.Locale.Default;
            textToSpeech.SetLanguage(lang);
            textToSpeech.SetPitch(.70f);
            textToSpeech.SetSpeechRate(.90f);


            spokenHistoryListView.ItemClick += SpokenHistoryListView_ItemClick;
                   
        }

        private void SpokenHistoryListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string text = spokenHistoryListArray[e.Position];
            {
                if (!string.IsNullOrEmpty(text))

                {
                    textToSpeech.Speak(text, QueueMode.Flush, null, null);
                    
                }
            }

        }



        void TextToSpeech.IOnInitListener.OnInit(OperationResult status)
        {
            // if we get an error, default to the default language
            if (status == OperationResult.Error)
                textToSpeech.SetLanguage(Java.Util.Locale.Default);
            // if the listener is ok, set the lang
            if (status == OperationResult.Success)
                textToSpeech.SetLanguage(lang);

        }
    }

}