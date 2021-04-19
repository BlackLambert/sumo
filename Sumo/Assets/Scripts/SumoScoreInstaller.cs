using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoScoreInstaller : MonoInstaller
    {
        [SerializeField]
        private Sumo.Type m_eSumoType;
        [Inject]
        private Game m_game;

        public override void InstallBindings()
        {
            Container.Bind<Sumo>().FromInstance(m_game.sumoGet(m_eSumoType)).AsSingle();
        }
    }
}