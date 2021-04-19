using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Sumo
{
    public class GameOnDeathRestarter : MimiBehaviour
    {
        [SerializeField]
        private string m_strSceneName = "Game";
        [SerializeField]
        private float m_fRestartDelay = 2;
        private Game m_game;

        [Inject]
        public void Construct(Game _game)
		{
            m_game = _game;
        }

        protected virtual void Start()
		{
            foreach (Sumo.Type eType in Enum.GetValues(typeof(Sumo.Type)))
                m_game.sumoGet(eType).evOnHealthChanged += checkForRestart;
        }

        protected virtual void OnDestroy()
        {
            foreach (Sumo.Type eType in Enum.GetValues(typeof(Sumo.Type)))
                m_game.sumoGet(eType).evOnHealthChanged -= checkForRestart;
        }

        private void checkForRestart(int _iHealth)
		{
            if (_iHealth > 0)
                return;

            foreach (Sumo.Type eType in Enum.GetValues(typeof(Sumo.Type)))
			{
                if (m_game.sumoGet(eType).iHealth > 0)
                    continue;
                StartCoroutine(restart());
                break;
			}
        }

		private IEnumerator restart()
		{
            yield return new WaitForSeconds(m_fRestartDelay);
            SceneManager.LoadScene(m_strSceneName, LoadSceneMode.Single);
		}
	}
}