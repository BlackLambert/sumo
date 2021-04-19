
using UnityEngine;

namespace Sumo
{
    [RequireComponent(typeof(Collider2D))]
    public class SlimeWall : MimiBehaviour, SlimeHitTarget
    {
        [SerializeField]
        private GameObject m_goSprite;
        private bool m_bActive = false;

		protected virtual void Start()
		{
			m_goSprite.SetActive(false);
		}

		public void hitBy(Slime _slime)
		{
			if (m_bActive)
				return;
			m_goSprite.SetActive(true);
			m_bActive = true;
			_slime.Destroy();
		}

		private void OnTriggerStay2D(Collider2D _collision)
		{
			if (m_bActive)
				tryHitTarget(_collision);
		}

		private void tryHitTarget(Collider2D _collision)
		{
			SlimeWallTarget slimeWallTarget = _collision.GetComponent<SlimeWallTarget>();
			if (slimeWallTarget != null)
				slimeWallTarget.hit(this);
		}
	}
}