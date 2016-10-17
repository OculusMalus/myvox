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

        TextToSpeech textToSpeech;
        Context context;
        Java.Util.Locale lang;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var editText = FindViewById<EditText>(Resource.Id.editText);
            var helloMyNameIs = FindViewById<Button>(Resource.Id.helloMyNameIs);
            var ralph = FindViewById<Button>(Resource.Id.ralph);
            var speak = FindViewById<Button>(Resource.Id.speak);
            var tired = FindViewById<Button>(Resource.Id.tired);
            var later = FindViewById<Button>(Resource.Id.later);


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
                    textToSpeech.Speak(editText.Text, QueueMode.Flush, null, "KEY_FEATURE_NETWORK_SYNTHESIS");
                editText.Text = "";
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

            later.Click += delegate
            {
                if (!TextUtils.IsEmpty(later.Text))
                {
                    editText.Append(later.Text);
                }
            };

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
