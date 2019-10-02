using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Droid.ViewHolders;

namespace ParqueaderoElDesfalco.Droid.Adapters
{
    public class CarAdapter : RecyclerView.Adapter
    {

        private List<Car> cars;
        public EventHandler<Car> OnItemClick;

        public CarAdapter(List<Car> cars)
        {
            this.cars = cars;
        }

        public override int ItemCount => cars.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CarViewHolder carViewHolder = holder as CarViewHolder;
            carViewHolder.BindData(cars.ElementAt(position));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.car_item, parent, false);
            CarViewHolder carViewHolder = new CarViewHolder(itemView, OnClick);
            return carViewHolder;
        }
            
        private void OnClick(int position)
        {
            Car car = cars.ElementAt(position);
            OnItemClick?.Invoke(this, car);
        }
    }
}
