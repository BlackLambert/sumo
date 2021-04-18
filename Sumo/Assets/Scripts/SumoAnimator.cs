using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    public class SumoAnimator : MimiBehaviour
    {
        [SerializeField]
        private Animator m_animator;
        [SerializeField]
        private Transform m_transSprite;

        public void hit()
		{
            m_animator.SetTrigger("Hit");
        }

        public void setMortality(bool _bImmortal)
		{
            m_animator.SetBool("Immortal", _bImmortal);
		}

        public void setDashing(bool _bDashing)
		{
            m_animator.SetBool("Dashing", _bDashing);
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