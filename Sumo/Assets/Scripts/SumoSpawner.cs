using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoSpawner : MimiBehaviour
    {
        [SerializeField]
        private Transform m_transSpawnPoint;
        [SerializeField]
        private Sumo.Type m_sumoType;
        private SumoBehaviour.Factory m_factory;
        private Game m_game;

        [Inject]
        public void Construct(SumoBehaviour.Factory _factory, Game _game)
		{
            m_factory = _factory;
            m_game = _game;
        }

        protected virtual void Start()
		{
            SumoBehaviour result = m_factory.Create(m_game.sumoGet(m_sumoType));
            result.trans.position = m_transSpawnPoint.position;
        }
    }
}