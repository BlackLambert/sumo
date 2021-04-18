using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    public class DeathAnimation : MimiBehaviour
    {
        [SerializeField]
        private Animator m_animator;

        public void trigger()
		{
            m_animator.SetTrigger("Dead");
        }
    }
}