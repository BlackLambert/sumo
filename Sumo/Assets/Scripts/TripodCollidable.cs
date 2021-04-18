using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    public interface TripodCollidable
    {
        void CollidedWith(Tripod _tripod);
    }
}