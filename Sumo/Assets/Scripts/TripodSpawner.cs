using UnityEngine;
using Zenject;

namespace Sumo
{
    public class TripodSpawner : MimiBehaviour
    {
        [SerializeField]
        private BoxCollider2D m_collider;
        [SerializeField]
        private float m_fSpawnRate = 2f;

        private Game m_game;
        private Tripod.Factory m_tripodFactory;
        private float m_fTimeTillNextSpawn = 0;

        [Inject]
        public void Construct(Game _game,
            Tripod.Factory _tripodFactory)
		{
            m_game = _game;
            m_tripodFactory = _tripodFactory;
        }

        protected virtual void Update()
		{
            if (m_game.bPaused)
                return;

            if(m_fTimeTillNextSpawn <= 0)
                spawn();

            m_fTimeTillNextSpawn -= Time.deltaTime;
        }

		private void spawn()
		{
            float fXRelative = UnityEngine.Random.value;
            float fYRelative = UnityEngine.Random.value;
            float fX = (m_collider.bounds.max.x - m_collider.bounds.min.x) * fXRelative + m_collider.bounds.min.x;
            float fY = (m_collider.bounds.max.y - m_collider.bounds.min.y) * fYRelative + m_collider.bounds.min.y;
            Tripod tripod = m_tripodFactory.Create();
            tripod.trans.position = new Vector3(fX, fY);
            m_fTimeTillNextSpawn = m_fSpawnRate;
        }
	}
}