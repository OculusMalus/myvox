using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Speech.Tts;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyVox
{

    [Activity(Label = "Words", Theme = "@android:style/Theme.NoTitleBar")]
    public class Words : Activity, TextToSpeech.IOnInitListener

    {
        private ListView spokenHistoryListView;
        private Context context;
        TextToSpeech textToSpeech;
        Java.Util.Locale lang;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            String[] spokenHistoryListArray = Intent.GetStringArrayExtra("history_list");
            List<string> spokenHistoryList = spokenHistoryListArray.ToList();

            SetContentView(Resource.Layout.words);

            var editText = FindViewById<EditText>(Resource.Id.editText);
            var I = FindViewById<Button>(Resource.Id.I);
            var you = FindViewById<Button>(Resource.Id.you);
            var they = FindViewById<Button>(Resource.Id.they);
            var feel = FindViewById<Button>(Resource.Id.feel);
            var happy = FindViewById<Button>(Resource.Id.happy);
            var angry = FindViewById<Button>(Resource.Id.angry);
            var come = FindViewById<Button>(Resource.Id.come);
            var give = FindViewById<Button>(Resource.Id.give);
            var go = FindViewById<Button>(Resource.Id.go);
            var speak = FindViewById<Button>(Resource.Id.speak);
            var please = FindViewById<Button>(Resource.Id.please);
            var help = FindViewById<Button>(Resource.Id.help);
            var home = FindViewById<Button>(Resource.Id.home);


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
                String[] phraseHistoryArray = spokenHistoryList.ToArray();
                Intent intent = new Intent(this, typeof(HistoryActivity));
                intent.PutExtra("history_list", phraseHistoryArray);
                this.StartActivity(intent);
            };


            Button phrases = FindViewById<Button>(Resource.Id.phrases);
            phrases.Click += delegate
            {
                String[] phraseHistoryArray = spokenHistoryList.ToArray();
                Intent intent = new Intent(this, typeof(MainActivity));
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

            please.Click += delegate
            {
                if (!string.IsNullOrEmpty(please.Text))
                {
                    editText.Append(please.Text);
                }
            };

            help.Click += delegate
            {
                if (!string.IsNullOrEmpty(help.Text))
                {
                    editText.Append(help.Text);
                }
            };

            home.Click += delegate
            {
                if (!string.IsNullOrEmpty(home.Text))
                {
                    editText.Append(home.Text);
                }
            };

            I.Click += delegate
            {
                if (!string.IsNullOrEmpty(I.Text))
                {
                    editText.Append(I.Text);
                }
            };


            you.Click += delegate
            {
                if (!string.IsNullOrEmpty(you.Text))
                {
                    editText.Append(you.Text);
                }
            };

            they.Click += delegate
            {
                if (!string.IsNullOrEmpty(they.Text))
                {
                    editText.Append(they.Text);
                }
            };

            feel.Click += delegate
            {
                if (!string.IsNullOrEmpty(feel.Text))
                {
                    editText.Append(feel.Text);
                }
            };

            happy.Click += delegate
            {
                if (!string.IsNullOrEmpty(happy.Text))
                {
                    editText.Append(happy.Text);
                }
            };

            angry.Click += delegate
            {
                if (!string.IsNullOrEmpty(angry.Text))
                {
                    editText.Append(angry.Text);
                }
            };

            come.Click += delegate
            {
                if (!string.IsNullOrEmpty(come.Text))
                {
                    editText.Append(come.Text);
                }
            };


            give.Click += delegate
            {
                if (!string.IsNullOrEmpty(give.Text))
                {
                    editText.Append(give.Text);
                }
            };

            go.Click += delegate
            {
                if (!string.IsNullOrEmpty(go.Text))
                {
                    editText.Append(go.Text);
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