using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Droid.ViewHolders
{
    public class MotorcycleViewHolder : RecyclerView.ViewHolder
    {

        TextView MotorcycleId;
        TextView DateOfEntry;
        TextView Cilindraje;

        public MotorcycleViewHolder(View itemView, Action<int> clickListener) : base(itemView)
        {
            MotorcycleId = itemView.FindViewById<TextView>(Resource.Id.motorcycle_id_textView);
            DateOfEntry = itemView.FindViewById<TextView>(Resource.Id.motorcycle_date_textView);
            Cilindraje = itemView.FindViewById<TextView>(Resource.Id.motorcycle_cilindraje_textView);

            itemView.Click += (sender, e) => clickListener(LayoutPosition);
        }

        public void BindData(Motorcycle motorcycle)
        {
            MotorcycleId.Text = motorcycle.VehicleId;
            DateOfEntry.Text = motorcycle.DateOfEntry.DateTime.ToString();
            Cilindraje.Text = motorcycle.Cilindraje.ToString();
        }
    }
}
