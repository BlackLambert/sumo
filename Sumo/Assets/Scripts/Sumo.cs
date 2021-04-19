using System;
using UnityEngine;

namespace Sumo
{
    public class Sumo
    {
		public Type eType 
        { 
            get; 
        }

        public int iMaxHealth
		{
            get;
		}

        public float fAcceleration
		{
            get;
		}

        public float fMaxHorizontalSpeed
		{
            get;
        }

        public float fJumpForce
        {
            get;
        }

        public int iMaxAmmoCount
        { 
            get;
        }

        public float fCastSlimeForce
        {
            get;
        }

        public event Action evOnAmmoCountChanged;
        private int m_iAmmoCount = 0;
        public int iAmmoCount
        {
            get { return m_iAmmoCount; }
            private set
            {
                m_iAmmoCount = value;
                evOnAmmoCountChanged?.Invoke();
            }
        }

        public event Action<int> evOnHealthChanged;
        private int m_iHealth;
        public int iHealth
		{
			get { return m_iHealth; }
			set
			{
                m_iHealth = value;
                evOnHealthChanged?.Invoke(m_iHealth);
            }
        }

        public bool bIsImmortal => fImmortalityTimer > 0;

        public float fImmortalityTimer
        {
            get;
            set;
        } = 0;

        public float fImmortalTimeAfterHit
        {
            get;
        }

        public event Action evOnScoreChanged;
        private int m_iScore;
        public int iScore
        {
            get { return m_iScore; }
            private set
            {
                m_iScore = value;
                evOnScoreChanged?.Invoke();
            }
        }

        public Sumo(Type _eType, 
            int _iCurrentScore,
            SumoSettings _settings)
		{
            eType = _eType;
            this.iScore = _iCurrentScore;
            this.iMaxHealth = _settings.iMaxHealth;
            this.iHealth = _settings.iMaxHealth;
            this.fImmortalTimeAfterHit = _settings.fImmortalTimeAfterHit;
            this.fAcceleration = _settings.fAcceleration;
            this.fMaxHorizontalSpeed = _settings.fMaxHorizontalSpeed;
            this.fJumpForce = _settings.fJumpForce;
            this.iMaxAmmoCount = _settings.iMaxAmmoCount;
            this.fCastSlimeForce = _settings.fCastedSlimeForce;
        }

        public void setImmortal()
		{
            this.fImmortalityTimer = fImmortalTimeAfterHit;
		}

        public void increaseAmmo()
		{
            this.iAmmoCount++;
		}

        public void decreaseAmmo()
        {
            this.iAmmoCount--;
        }

        public void increaseScore()
		{
            this.iScore++;
            PlayerPrefs.SetInt(((int)eType).ToString(), this.iScore);
        }

        public enum Type
        {
            Blue = 0,
            Red = 1
        }
    }
}