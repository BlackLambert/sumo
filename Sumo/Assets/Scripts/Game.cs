using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    public class Game
    {
        private Dictionary<Sumo.Type, Sumo> m_dicSumos = new Dictionary<Sumo.Type, Sumo>();

		private bool m_bPaused = true;
		public event Action evOnPausedChanged;
		public bool bPaused
		{
			get => m_bPaused;
			set
			{
				m_bPaused = value;
				evOnPausedChanged?.Invoke();
			}
		}

		public Game(Sumo[] _arSumos)
		{
			initSumoDictionary(_arSumos);
		}

		private void initSumoDictionary(Sumo[] _arSumos)
		{
			foreach (Sumo sumo in _arSumos)
				m_dicSumos.Add(sumo.eType, sumo);
		}

		public Sumo sumoGet(Sumo.Type _type)
		{
			return m_dicSumos[_type];
		}
	}
}