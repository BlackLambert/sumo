using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    [RequireComponent(typeof(Collider2D))]
    public class AudioOnCollisionPlayer : MimiBehaviour
    {
        [SerializeField]
        private AudioSource m_audioSource;
        [SerializeField]
        private string m_strTargetTag = "Tag";

		private void OnCollisionEnter2D(Collision2D _collision)
		{
            if (_collision.collider.tag == m_strTargetTag)
                m_audioSource.Play();
        }
	}
}