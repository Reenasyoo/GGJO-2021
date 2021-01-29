using UnityEngine;
using System.Collections.Generic;

namespace Systems
{
    public interface IGameEventListener
    {
        void OnEventRaised(object item = default);
    }
}