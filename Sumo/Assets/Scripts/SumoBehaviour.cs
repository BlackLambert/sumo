
using System;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoBehaviour : MimiBehaviour, Groundable
    {
        [SerializeField]
        private Transform m_transSprite;

        private bool m_bIsGrounded = false;
        public event Action evOnGroundedChanged;
        public bool bIsGrounded
        {
            get => m_bIsGrounded;
            set
			{
                m_bIsGrounded = value;
                evOnGroundedChanged?.Invoke();
            }
        }

        public Vector2 v2LookDirection => m_transSprite.localScale.x > 0 ? Vector2.right : Vector2.left;

        public void deactivate()
        {
            m_transSprite.gameObject.SetActive(false);
        }

        public class Factory: PlaceholderFactory<Sumo, SumoBehaviour> { }

		
	}
}