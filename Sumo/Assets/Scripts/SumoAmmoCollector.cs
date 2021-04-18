using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
	public class SumoAmmoCollector : MimiBehaviour, TripodCollidable
	{
		private Sumo m_sumo;

		[Inject]
		private void Construct(Sumo _sumo)
		{
			m_sumo = _sumo;
		}

		public void CollidedWith(Tripod _tripod)
		{
			m_sumo.increaseAmmo();
			_tripod.Destroy();
		}
	}
}