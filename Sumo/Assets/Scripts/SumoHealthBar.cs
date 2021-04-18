using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sumo
{
    public class SumoHealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image m_imageFilled;
        private Sumo m_sumoModel;

        [Inject]
        public void Construct(Sumo _sumoModel)
		{
            m_sumoModel = _sumoModel;

        }

        protected virtual void Start()
		{
            m_sumoModel.evOnHealthChanged += updateBar;

        }

        protected virtual void OnDestroy()
		{
            m_sumoModel.evOnHealthChanged -= updateBar;
        }

		private void updateBar()
		{
            m_imageFilled.fillAmount = Mathf.Clamp01( (float)m_sumoModel.iHealth / (float)m_sumoModel.iMaxHealth);

        }
	}
}