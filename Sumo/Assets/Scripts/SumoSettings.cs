using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo
{
    [CreateAssetMenu(fileName = "SumoSettings", menuName = "Sumo/SumoSettings")]
    public class SumoSettings : ScriptableObject
    {
        [SerializeField]
        private int m_iMaxHealth = 5;
        public int iMaxHealth => m_iMaxHealth;
        [SerializeField]
        private float m_fImmortalTimeAfterHit = 1f;
        public float fImmortalTimeAfterHit => m_fImmortalTimeAfterHit;
        [SerializeField]
        private float m_fAcceleration = 2f;
        public float fAcceleration => m_fAcceleration;
        [SerializeField]
        private float m_fMaxHorizontalSpeed = 2f;
        public float fMaxHorizontalSpeed => m_fMaxHorizontalSpeed;
        [SerializeField]
        private float m_fJumpForce = 200f;
        public float fJumpForce => m_fJumpForce;
        [SerializeField]
        private int m_iMaxAmmoCount = 3;
        public int iMaxAmmoCount => m_iMaxAmmoCount;
        [SerializeField]
        private float m_fCastedSlimeForce = 400f;
        public float fCastedSlimeForce => m_fCastedSlimeForce;
    }

}