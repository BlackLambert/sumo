using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoScoreDisplay : MimiBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_text;
        private Sumo m_sumo;

        [Inject]
        public void Construct(Sumo _sumo)
		{
            m_sumo = _sumo;
        }

        protected virtual void Start()
		{
            m_sumo.evOnScoreChanged += updateText;
            updateText();
        }

        protected virtual void OnDestroy()
		{
            m_sumo.evOnScoreChanged -= updateText;
        }

		private void updateText()
		{
            m_text.text = m_sumo.iScore.ToString();
        }
	}
}