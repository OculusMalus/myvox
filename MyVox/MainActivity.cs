﻿using System;
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
    
    [Activity(Label = "MyVox", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar" , Icon = "@drawable/icon")]
    public class MainActivity : Activity, TextToSpeech.IOnInitListener
    {
        TextToSpeech textToSpeech;
        Context context;
        Java.Util.Locale lang;
        private List<string> spokenHistoryList = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

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
            var run = FindViewById<Button>(Resource.Id.runAway);
            var love = FindViewById<Button>(Resource.Id.iLoveYou);
            var play = FindViewById<Button>(Resource.Id.wantToPlay);

            context = speak.Context;
            textToSpeech = new TextToSpeech(this, this, "com.google.android.tts");

            lang = Java.Util.Locale.Default;
            textToSpeech.SetLanguage(lang);
            textToSpeech.SetPitch(.80f);
            textToSpeech.SetSpeechRate(1f);

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
                String[] phraseHistoryArray = spokenHistoryList.ToArray();
                Intent intent = new Intent(this, typeof(HistoryActivity));
                intent.PutExtra("history_list", phraseHistoryArray);
                this.StartActivity(intent);
            };


            Button words = FindViewById<Button>(Resource.Id.words);
            words.Click += delegate
            {
                String[] phraseHistoryArray = spokenHistoryList.ToArray();
                Intent intent = new Intent(this, typeof(Words));
                intent.PutExtra("history_list", phraseHistoryArray);
                this.StartActivity(intent);

            };

            Button custom = FindViewById<Button>(Resource.Id.custom);
            custom.Click += delegate
            {
                String[] phraseHistoryArray = spokenHistoryList.ToArray();
                Intent intent = new Intent(this, typeof(CameraActivity));
                intent.PutExtra("history_list", phraseHistoryArray);
                this.StartActivity(intent);
            };

            love.Click += delegate
            {
                if (!TextUtils.IsEmpty(love.Text))
                {
                    editText.Append(love.Text);
                }
            };

            play.Click += delegate
            {
                if (!TextUtils.IsEmpty(play.Text))
                {
                    editText.Append(play.Text);
                }
            };

            run.Click += delegate
            {
                if (!TextUtils.IsEmpty(run.Text))
                {
                    editText.Append(run.Text);
                }
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
