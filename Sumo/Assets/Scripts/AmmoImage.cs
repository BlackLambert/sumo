using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    public class AmmoImage : MimiBehaviour
    {
        [SerializeField]
        private Animator m_animator;

        public void setFilled(bool _bFilled)
		{
            m_animator.SetBool("Filled", _bFilled);
        }
    }
}