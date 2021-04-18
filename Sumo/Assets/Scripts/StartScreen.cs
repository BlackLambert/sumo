using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class StartScreen : MimiBehaviour
    {
        [SerializeField]
        private float m_fUnpauseDelay = 4;
        private Game m_game;

        [Inject]
        public void Construct(Game _game)
		{
            m_game = _game;
        }

        protected IEnumerator Start()
		{
            yield return new WaitForSeconds(m_fUnpauseDelay);
            m_game.bPaused = false;
            Destroy(gameObject);
        }
    }
}