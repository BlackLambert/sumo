using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    public class DelayedAudioPlayer : MimiBehaviour
    {
        [SerializeField]
        private AudioSource m_audioSource;
        [SerializeField]
        private float m_fDelay = 4f;

        protected void Start()
		{
            m_audioSource.PlayDelayed(m_fDelay);
        }
    }
}