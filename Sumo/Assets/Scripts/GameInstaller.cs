using System;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private SumoSettings m_sumoSettings;

        [Header("Prefabs")]
        [SerializeField]
        private SumoInstaller m_sumoBehaviourBlue;
        [SerializeField]
        private SumoInstaller m_sumoBehaviourRed;
        [SerializeField]
        private Slime m_slime;
        [SerializeField]
        private Tripod m_tripod;


        public override void InstallBindings()
		{
			bindGame();
			bindSumoFactory();
            Container.BindFactory<Tripod, Tripod.Factory>().FromComponentInNewPrefab(m_tripod);
        }

        private void bindGame()
        {
            Sumo blueSumo = new Sumo(Sumo.Type.Blue, m_sumoSettings);
            Sumo redSumo = new Sumo(Sumo.Type.Red, m_sumoSettings);
            Game game = new Game(new Sumo[] { blueSumo, redSumo });
            Container.Bind<Game>().FromInstance(game).AsSingle();
        }

        private void bindSumoFactory()
		{
			SumoFactory.Prefabs prefabs = new SumoFactory.Prefabs(m_sumoBehaviourBlue, m_sumoBehaviourRed);
			Container.Bind<SumoFactory.Prefabs>().FromInstance(prefabs).AsSingle();
			Container.BindFactory<Sumo, SumoBehaviour, SumoBehaviour.Factory>().FromFactory<SumoFactory>();
            Container.BindFactory<Slime, Slime.Factory>().FromComponentInNewPrefab(m_slime);
		}
	}
}