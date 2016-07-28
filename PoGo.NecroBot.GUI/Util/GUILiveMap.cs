using GMap.NET;
using PoGo.NecroBot.Logic;
using PokemonGo.RocketAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.NecroBot.GUI.Util
{ 
    public delegate void GUILiveMapDirtyDelegate();

    class GUILiveMap
    {
        public PointLatLng _currentPosition = new PointLatLng();
        public PointLatLng _lastPosition = new PointLatLng();
        public bool _positionUpdated = false;

        public void Dirty(Client client)
        {
            DirtyEvent?.Invoke();
        }

        public void SetPosition(PointLatLng position)
        {
            if(position != _currentPosition)
            {
                _positionUpdated = true;
                _lastPosition = _currentPosition;
                _currentPosition = position;
            }
        }

        public event GUILiveMapDirtyDelegate DirtyEvent;
    }
}
