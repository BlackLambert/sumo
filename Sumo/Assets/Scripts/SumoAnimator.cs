using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    public class SumoAnimator : MimiBehaviour
    {
		private const string c_strHitTriggerName = "Hit";
		private const string c_strImmortalBoolName = "Immortal";
		private const string c_strDashBoolName = "Dashing";
		[SerializeField]
        private Animator m_animator;
        [SerializeField]
        private Transform m_transSprite;

        public void hit()
		{
            m_animator.SetTrigger(c_strHitTriggerName);
        }

        public void setMortality(bool _bImmortal)
		{
            m_animator.SetBool(c_strImmortalBoolName, _bImmortal);
		}

        public void setDashing(bool _bDashing)
		{
            m_animator.SetBool(c_strDashBoolName, _bDashing);
		}

        public void turnRight()
		{
            m_transSprite.localScale = new Vector3(1, 1, 1);
        }

        public void turnLeft()
		{
            m_transSprite.localScale = new Vector3(-1, 1, 1);
        }
    }
}