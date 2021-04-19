using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sumo
{
    public class ToGameContinuer : MimiBehaviour
    {
        [SerializeField]
        private string m_strSceneName = "Game";

        protected virtual void Update()
		{
            if (Input.anyKeyDown)
                SceneManager.LoadScene(m_strSceneName, LoadSceneMode.Single);
		}
    }
}