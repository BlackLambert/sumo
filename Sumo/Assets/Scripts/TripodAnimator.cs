using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    public class TripodAnimator : MimiBehaviour
    {
        [SerializeField]
        private Animator _animator;

        public void setFalling(bool _bFalling)
		{
            _animator.SetBool("Falling", _bFalling);
		}

        public void kill()
		{
            _animator.SetTrigger("Killed");
        }
    }
}