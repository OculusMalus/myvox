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
    class HistoryListViewAdapter : BaseAdapter<string>
    {
        private List<string> items;
        private Context context;

        public HistoryListViewAdapter(Context context, List<string> items)
        {
            this.items = items;
            this.context = context;

        }
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position]
        {
            get { return items[position]; }
            
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.History, null, false);
            }

            TextView spokenHistoryText = row.FindViewById<TextView>(Resource.Id.spokenHistoryList);
            spokenHistoryText.Text = items[position];

            return row;
        }




    }
}