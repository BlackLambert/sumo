using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoDashAnimator : MimiBehaviour
    {
        private SumoBehaviour m_sumoBehaviour;
        private SumoAnimator m_sumoAnimator;

        [Inject]
        public void Construct(SumoBehaviour _sumoBehaviour,
            SumoAnimator _sumoAnimator)
		{
            m_sumoBehaviour = _sumoBehaviour;
            m_sumoAnimator = _sumoAnimator;
        }

        protected virtual void Start()
		{
            m_sumoBehaviour.evOnGroundedChanged += updateDash;
            updateDash();
        }

        protected virtual void OnDestroy()
		{
            m_sumoBehaviour.evOnGroundedChanged -= updateDash;
        }

		private void updateDash()
		{
            m_sumoAnimator.setDashing(!m_sumoBehaviour.bIsGrounded);

        }
	}
}