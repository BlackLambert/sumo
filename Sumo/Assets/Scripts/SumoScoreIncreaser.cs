using System;
using Zenject;

namespace Sumo
{
    public class SumoScoreIncreaser : MimiBehaviour
    {
        private Game m_game;

        [Inject]
        public void Construct(Game _game)
        {
            m_game = _game;
        }

        protected virtual void Start()
        {
            foreach (Sumo.Type type in Enum.GetValues(typeof(Sumo.Type)))
                m_game.sumoGet(type).evOnHealthChanged += checkForScoreIcrease;
        }

        protected virtual void OnDestroy()
        {
            foreach (Sumo.Type type in Enum.GetValues(typeof(Sumo.Type)))
                m_game.sumoGet(type).evOnHealthChanged -= checkForScoreIcrease;
        }

        private void checkForScoreIcrease(int _iHealth)
        {
            if (_iHealth > 0)
                return;

            foreach (Sumo.Type type in Enum.GetValues(typeof(Sumo.Type)))
            {
                Sumo sumo = m_game.sumoGet(type);
                if (sumo.iHealth > 0)
                    sumo.increaseScore();
            }
        }
    }
}