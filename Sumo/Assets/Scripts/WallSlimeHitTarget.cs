using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
	public class WallSlimeHitTarget : MonoBehaviour, SlimeHitTarget
	{
		public void hitBy(Slime _slime)
		{
			_slime.Destroy();
		}
	}
}