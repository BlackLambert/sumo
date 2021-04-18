using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
    [RequireComponent(typeof(Collider2D))]
    public class Slime : MimiBehaviour
    {
        [SerializeField]
        private Rigidbody2D m_rigidbody;
        public Rigidbody2D rigid => m_rigidbody;

        public void Destroy()
		{
            Destroy(gameObject);
		}

		private void OnTriggerEnter2D(Collider2D _collision)
		{
            SlimeHitTarget slimeHitTarget = _collision.GetComponent<SlimeHitTarget>();
            if (slimeHitTarget != null)
                slimeHitTarget.hitBy(this);
        }

		public class Factory : PlaceholderFactory<Slime> { }
    }
}