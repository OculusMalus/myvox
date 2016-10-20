using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Speech.Tts;
using System.Collections.Generic;
using System.Linq;
using Android.Text;



namespace MyVox
{
    
    [Activity(Label = "MyVox", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, TextToSpeech.IOnInitListener
    {
        private List<string> spokenHistoryList = new List<string>();
        private ListView spokenHistoryListView;
        TextToSpeech textToSpeech;
        Context context;
        Java.Util.Locale lang;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var words = FindViewById<Button>(Resource.Id.words);
            var editText = FindViewById<EditText>(Resource.Id.editText);
            var helloMyNameIs = FindViewById<Button>(Resource.Id.helloMyNameIs);
            var ralph = FindViewById<Button>(Resource.Id.ralph);
            var speak = FindViewById<Button>(Resource.Id.speak);
            var tired = FindViewById<Button>(Resource.Id.tired);
            var goodbye = FindViewById<Button>(Resource.Id.goodbye);
            var Hello = FindViewById<Button>(Resource.Id.niceToMeetYou);
            var thankyou = FindViewById<Button>(Resource.Id.thankYou);
            var thirsty = FindViewById<Button>(Resource.Id.thirsty);
            var hungry = FindViewById<Button>(Resource.Id.hungry);
            var potty = FindViewById<Button>(Resource.Id.potty);
            

            context = speak.Context;
            textToSpeech = new TextToSpeech(this, this, "com.google.android.tts");

            lang = Java.Util.Locale.Default;
            textToSpeech.SetLanguage(lang);
            textToSpeech.SetPitch(.70f);
            textToSpeech.SetSpeechRate(.90f);

            speak.Click += delegate
            {
                // if there is nothing to say, don't say it
                if (!string.IsNullOrEmpty(editText.Text))


                    textToSpeech.Speak(editText.Text, QueueMode.Flush, null, null);
                    //add phrase to list of spoken phrases
                    spokenHistoryList.Add(editText.Text);
                    //empty editText string
                    editText.Text = "";
            };

            Button history = FindViewById<Button>(Resource.Id.history);
            history.Click += delegate
            {
                SetContentView(Resource.Layout.History);
                spokenHistoryListView = FindViewById<ListView>(Resource.Id.myListView);

                HistoryListViewAdapter adapter = new HistoryListViewAdapter(this, spokenHistoryList);
                spokenHistoryListView.Adapter = adapter;
                Button back = FindViewById<Button>(Resource.Id.back);
                back.Click += delegate { SetContentView(Resource.Layout.Main); };

            };


            


            helloMyNameIs.Click += delegate
            {
                if (!TextUtils.IsEmpty(helloMyNameIs.Text))
                {
                    editText.Append(helloMyNameIs.Text);
                }
            };

            
            ralph.Click += delegate
            {
                if (!TextUtils.IsEmpty(ralph.Text))
                {
                    editText.Append(ralph.Text);
                }
            };

            tired.Click += delegate
            {
                if (!TextUtils.IsEmpty(tired.Text))
                {
                    editText.Append(tired.Text);
                }
            };

            goodbye.Click += delegate
            {
                if (!TextUtils.IsEmpty(goodbye.Text))
                {
                    editText.Append(goodbye.Text);
                }
            };

            Hello.Click += delegate
            {
                if (!TextUtils.IsEmpty(Hello.Text))
                {
                    editText.Append(Hello.Text);
                }
            };

            thankyou.Click += delegate
            {
                if (!TextUtils.IsEmpty(thankyou.Text))
                {
                    editText.Append(thankyou.Text);
                }
            };

            thirsty.Click += delegate
            {
                if (!TextUtils.IsEmpty(thirsty.Text))
                {
                    editText.Append(thirsty.Text);
                }
            };

            
            potty.Click += delegate
            {
                if (!TextUtils.IsEmpty(potty.Text))
                {
                    editText.Append(potty.Text);
                }
            };

            hungry.Click += delegate
            {
                if (!TextUtils.IsEmpty(hungry.Text))
                {
                    editText.Append(hungry.Text);
                }
            };
        }

        private EventHandler back_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Main);
            return null;
                
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
