using UnityEngine;
using Zenject;

namespace Sumo
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundedChecker : MimiBehaviour
    {
        private Groundable m_groundable;
		private int m_iObjectsCount = 0;

		private bool bIsGrounded => m_iObjectsCount > 0;

		[Inject]
        public void Construct(Groundable _groundable)
		{
            m_groundable = _groundable;
        }

		private void OnTriggerEnter2D(Collider2D collision)
		{
			m_iObjectsCount++;
			m_groundable.bIsGrounded = this.bIsGrounded;
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			m_iObjectsCount--;
			m_groundable.bIsGrounded = this.bIsGrounded;
		}
	}
}