using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoMover : MimiBehaviour
    {
        [SerializeField]
        private Rigidbody2D m_rigidTarget;
        [SerializeField]
        private SumoBehaviour m_sumoBehaviour;

        private SumoAnimator m_animator;
        private SumoControls m_controls;
        private Sumo m_sumoModel;
        private Game m_game;

        public Vector2 v2HorizontalVelocity => new Vector2(m_rigidTarget.velocity.x, 0);
        public bool bIsAtMaxHorizontalSpeed => v2HorizontalVelocity.magnitude >= m_sumoModel.fMaxHorizontalSpeed; 

        [Inject]
        public void Construct(SumoAnimator _animator,
            SumoControls _controls,
            Sumo _sumoModel,
            Game _game)
		{
            m_animator = _animator;
            m_controls = _controls;
            m_sumoModel = _sumoModel;
            m_game = _game;
        }

        protected virtual void Update()
		{
			if (m_game.bPaused)
				return;

			checkForLeftMovement();
			checkForRightMovement();
			checkForJump();
		}

		private void checkForLeftMovement()
		{
			if (Input.GetKey(m_controls.keyCodeLeft) && !this.bIsAtMaxHorizontalSpeed)
			{
				Vector2 v2Force = v2CalculateVerticalForce(Vector2.left);
				m_rigidTarget.AddForce(v2Force, ForceMode2D.Impulse);
				m_animator.turnLeft();
			}
		}

		private void checkForRightMovement()
		{
			if (Input.GetKey(m_controls.keyCodeRight) && !this.bIsAtMaxHorizontalSpeed)
			{
				Vector2 v2Force = v2CalculateVerticalForce(Vector2.right);
				m_rigidTarget.AddForce(v2Force, ForceMode2D.Impulse);
				m_animator.turnRight();
			}
		}

		private void checkForJump()
		{
			if (Input.GetKeyDown(m_controls.keyCodeJump) && m_sumoBehaviour.bIsGrounded)
			{
				Vector2 v2Force = v2CalculateJumpForce();
				m_rigidTarget.AddForce(v2Force, ForceMode2D.Force);
			}
		}

		private Vector2 v2CalculateVerticalForce(Vector2 _v2Direction)
		{
			return _v2Direction.normalized * m_sumoModel.fAcceleration * Time.deltaTime;
		}

        private Vector2 v2CalculateJumpForce()
		{
            return Vector2.up * m_sumoModel.fJumpForce;
		}
	}
}