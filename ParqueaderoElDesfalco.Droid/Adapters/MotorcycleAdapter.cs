using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Droid.ViewHolders;

namespace ParqueaderoElDesfalco.Droid.Adapters
{
    public class MotorcycleAdapter : RecyclerView.Adapter
    {

        private List<Motorcycle> motorcycles;
        public EventHandler<Motorcycle> OnItemClick;

        public MotorcycleAdapter(List<Motorcycle> motorcycles) 
        {
            this.motorcycles = motorcycles;
        }

        public override int ItemCount => motorcycles.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MotorcycleViewHolder motorcycleViewHolder = holder as MotorcycleViewHolder;
            motorcycleViewHolder.BindData(motorcycles.ElementAt(position));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.motorcycle_item,parent,false);
            MotorcycleViewHolder motorcycleViewHolder = new MotorcycleViewHolder(itemView,OnClick);
            return motorcycleViewHolder;
        }

        private void OnClick(int position)
        {
            Motorcycle motorcycle = motorcycles.ElementAt(position);
            OnItemClick?.Invoke(this, motorcycle);
        }
    }
}
