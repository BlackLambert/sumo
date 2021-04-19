using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    public class TripodAnimator : MimiBehaviour
    {
		private const string c_strFallingBoolName = "Falling";
		private const string c_strKilledTriggerName = "Killed";

		[SerializeField]
        private Animator _animator;

        public void setFalling(bool _bFalling)
		{
            _animator.SetBool(c_strFallingBoolName, _bFalling);
		}

        public void kill()
		{
            _animator.SetTrigger(c_strKilledTriggerName);
        }
    }
}