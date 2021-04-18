using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    [CreateAssetMenu(fileName = "SumoControls", menuName = "Sumo/SumoControls")]
    public class SumoControls : ScriptableObject
    {
        [SerializeField]
        private KeyCode m_keyCodeLeft;
        public KeyCode keyCodeLeft => m_keyCodeLeft;

        [SerializeField]
        private KeyCode m_keyCodeRight;
        public KeyCode keyCodeRight => m_keyCodeRight;

        [SerializeField]
        private KeyCode m_keyCodeJump;
        public KeyCode keyCodeJump => m_keyCodeJump;

        [SerializeField]
        private KeyCode m_keyCodeAttack;
        public KeyCode keyCodeAttack => m_keyCodeAttack;
    }
}