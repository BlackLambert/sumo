using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class AmmoDisplay : MimiBehaviour
    {
        [SerializeField]
        private List<AmmoImage> m_liAmmoImages = new List<AmmoImage>();
		private Sumo m_sumo;

		[Inject]
		private void Construct(Sumo _sumo)
		{
			m_sumo = _sumo;
		}

        protected virtual void Start()
		{
			updateView();
			m_sumo.evOnAmmoCountChanged += updateView;
		}

		protected virtual void OnDestroy()
		{
			m_sumo.evOnAmmoCountChanged -= updateView;
		}


		private void updateView()
		{
			for(int i = 0; i< m_sumo.iMaxAmmoCount; i++)
			{
				if (i >= m_liAmmoImages.Count)
					return;
				m_liAmmoImages[i].setFilled(i < m_sumo.iAmmoCount);
			}
		}
	}
}