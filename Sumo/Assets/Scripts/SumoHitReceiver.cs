using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoHitReceiver : MimiBehaviour, SlimeHitTarget, SlimeWallTarget
	{
        [SerializeField]
        private SumoAnimator m_sumoAnimator;
		[SerializeField]
		private AudioSource m_audioSourceHit;
        private Sumo m_sumoModel;
		private Game m_game;

        [Inject]
        public void Construct(Sumo _sumoModel, Game _game)
		{
            m_sumoModel = _sumoModel;
			m_game = _game;
		}

        public void hitBy(Slime _slime)
		{
			if (m_sumoModel.bIsImmortal || m_game.bPaused)
				return;
			applyHit();
			_slime.Destroy();
		}

		public void hit(SlimeWall _wall)
		{
			if (m_sumoModel.bIsImmortal || m_game.bPaused)
				return;
			applyHit();
		}

		private void applyHit()
		{
			m_sumoModel.iHealth--;
			m_sumoAnimator.hit();
			m_sumoModel.setImmortal();
			m_sumoAnimator.setMortality(true);
			m_audioSourceHit.Play();
		}

		protected virtual void Update()
		{
            if (m_sumoModel.fImmortalityTimer <= 0)
                return;
            m_sumoModel.fImmortalityTimer -= Time.deltaTime;
            if(m_sumoModel.fImmortalityTimer <= 0)
                m_sumoAnimator.setMortality(false);
        }
	}
}