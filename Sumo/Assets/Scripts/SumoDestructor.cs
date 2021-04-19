using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoDestructor : MimiBehaviour
    {
        [SerializeField]
        private DeathAnimation m_deathAnimaton;
        [SerializeField]
        private SumoBehaviour m_sumoBehaviour;
        [SerializeField]
        private float m_fDisableSumoOnDeathAfter = 1f;

        private Sumo m_sumo;
        private Game m_game;

        [Inject]
        public void Construct(Sumo _sumo, Game _game)
		{
            m_sumo = _sumo;
            m_game = _game;
        }

        protected virtual void Start()
		{
            m_sumo.evOnHealthChanged += checkForDeath;
        }

        protected virtual void OnDestroy()
		{
            m_sumo.evOnHealthChanged -= checkForDeath;
        }

		private void checkForDeath(int _iHealth)
		{
			if (_iHealth > 0)
				return;
			StartCoroutine(kill());
		}

		private IEnumerator kill()
		{
			m_game.bPaused = true;
            m_deathAnimaton.gameObject.SetActive(true);

            m_deathAnimaton.trigger();
            yield return new WaitForSeconds(m_fDisableSumoOnDeathAfter);
            m_sumoBehaviour.deactivate();

        }
	}
}