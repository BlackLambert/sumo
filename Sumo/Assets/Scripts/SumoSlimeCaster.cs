using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoSlimeCaster : MimiBehaviour
    {
        [SerializeField]
        private float m_fCastRadius;
        [SerializeField]
        private Rigidbody2D m_rigidbodySumo;
        [SerializeField]
        private SumoBehaviour m_sumoBehaviour;
        [SerializeField]
        private Transform m_transCenter;

        private SumoControls m_controls;
        private Slime.Factory m_slimeFactory;
        private Sumo m_sumoModel;
        private Game m_game;

        [Inject]
        public void Construct(SumoControls _controls,
            Slime.Factory _slimeFactory,
            Sumo _sumoModel,
            Game _game)
		{
            m_controls = _controls;
            m_slimeFactory = _slimeFactory;
            m_sumoModel = _sumoModel;
            m_game = _game;
        }

        protected virtual void Update()
		{
            if (m_game.bPaused)
                return;
            if (Input.GetKeyDown(m_controls.keyCodeAttack) && m_sumoModel.iAmmoCount > 0)
                castSlime();
		}

		private void castSlime()
		{
            m_sumoModel.decreaseAmmo();
            Vector2 v2Force = m_sumoBehaviour.v2LookDirection * m_sumoModel.fCastSlimeForce;
            Slime slime = m_slimeFactory.Create();
            slime.trans.position = (Vector3) m_sumoBehaviour.v2LookDirection * m_fCastRadius + m_transCenter.position;
            slime.rigid.AddForce(v2Force, ForceMode2D.Force);
        }
	}
}

