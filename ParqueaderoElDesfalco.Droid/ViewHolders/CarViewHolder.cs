using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Droid.ViewHolders
{
    public class CarViewHolder : RecyclerView.ViewHolder
    {

        TextView VehicleId;
        TextView DateOfEntry;

        public CarViewHolder(View itemView, Action<int> clickListener) : base(itemView)
        {
            VehicleId = itemView.FindViewById<TextView>(Resource.Id.car_id_textView);
            DateOfEntry = itemView.FindViewById<TextView>(Resource.Id.car_date_textView);

            itemView.Click += (sender, e) => clickListener(LayoutPosition);
        }

        public void BindData(Car car)
        {
            VehicleId.Text = car.VehicleId;
            DateOfEntry.Text = car.DateOfEntry.DateTime.ToString();
        }
    }
}