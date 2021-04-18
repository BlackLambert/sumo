using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
    [RequireComponent(typeof(Collider2D))]
    public class Tripod : MimiBehaviour
    {
		private string c_strGroundTag = "Ground";

        [SerializeField]
        private TripodAnimator m_animator;
		[SerializeField]
		private float m_fDestructionDelay = 0.33f;
		[SerializeField]
		private Collider2D m_collider;
		[SerializeField]
		private Rigidbody2D m_rigidbody;

		public void Destroy()
		{
			StartCoroutine(startDestruction());
		}

		private IEnumerator startDestruction()
		{
			m_collider.enabled = false;
			m_animator.kill();
			m_rigidbody.isKinematic = true;
			m_rigidbody.velocity = Vector2.zero;
			yield return new WaitForSeconds(m_fDestructionDelay);
			Destroy(gameObject);
		}

		private void OnCollisionEnter2D(Collision2D _collision)
		{
			if (_collision.collider.tag == c_strGroundTag)
				m_animator.setFalling(false);
			TripodCollidable collidable = _collision.collider.GetComponent<TripodCollidable>();
			if (collidable != null)
				collidable.CollidedWith(this);
		}

		public class Factory : PlaceholderFactory<Tripod> { }
	}
}