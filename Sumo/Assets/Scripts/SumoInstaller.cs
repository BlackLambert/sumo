using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
    public class SumoInstaller : MonoInstaller<SumoInstaller>
    {
		[SerializeField]
		private SumoControls m_sumoControls;
		[SerializeField]
		private SumoBehaviour m_sumoBehaviour;
		[SerializeField]
		private SumoAnimator m_sumoAnimator;
		public SumoBehaviour sumoBehaviour => m_sumoBehaviour;
		[Inject]
		private Sumo m_sumoModel;

		public override void InstallBindings()
		{
			Container.Bind<SumoControls>().FromInstance(m_sumoControls).AsSingle();
			Container.Bind<Sumo>().FromInstance(m_sumoModel).AsSingle();
			Container.Bind<SumoAnimator>().FromInstance(m_sumoAnimator).AsSingle();
			Container.Bind(typeof(Groundable), typeof(SumoBehaviour)).To<SumoBehaviour>().FromInstance(m_sumoBehaviour).AsSingle();
		}
	}
}