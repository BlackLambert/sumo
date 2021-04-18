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
            foreach (Sumo.Type type in Enum.GetValues(typeof(Sumo.Type)))
                m_game.sumoGet(type).evOnHealthChanged += checkForRestart;
        }

        protected virtual void OnDestroy()
        {
            foreach (Sumo.Type type in Enum.GetValues(typeof(Sumo.Type)))
                m_game.sumoGet(type).evOnHealthChanged -= checkForRestart;
        }

        private void checkForRestart()
		{
            foreach (Sumo.Type type in Enum.GetValues(typeof(Sumo.Type)))
			{
                if (m_game.sumoGet(type).iHealth > 0)
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