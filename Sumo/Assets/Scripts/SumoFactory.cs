using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sumo
{
	public class SumoFactory : IFactory<Sumo, SumoBehaviour>
	{
		private SumoInstaller m_sumoBluePrefab;
		private SumoInstaller m_sumoRedPrefab;

		private DiContainer m_diContainer;

		[Inject]
		private void Construct(
			Prefabs _prefabs,
			DiContainer _diContainer)
		{
			m_diContainer = _diContainer;
			m_sumoBluePrefab = _prefabs.sumoBluePrefab;
			m_sumoRedPrefab = _prefabs.sumoRedPrefab;
		}

		public SumoBehaviour Create(Sumo _sumoModel)
		{
			switch(_sumoModel.eType)
			{
				case Sumo.Type.Blue:
					return createSumo(m_sumoBluePrefab, _sumoModel);
				case Sumo.Type.Red:
					return createSumo(m_sumoRedPrefab, _sumoModel);
				default:
					throw new NotImplementedException();
			}
		}

		private SumoBehaviour createSumo(SumoInstaller _sumoPrefab, Sumo _sumoModel)
		{
			DiContainer subcontainer = new DiContainer(m_diContainer);
			subcontainer.BindInstance(_sumoModel).AsSingle();
			return subcontainer.InstantiatePrefabForComponent<SumoInstaller>(_sumoPrefab).sumoBehaviour;
		}

		public class Prefabs
		{
			public SumoInstaller sumoBluePrefab 
			{ 
				get; 
			}
			public SumoInstaller sumoRedPrefab 
			{ 
				get; 
			}

			public Prefabs(
				SumoInstaller _sumoBluePrefab,
				SumoInstaller _sumoRedPrefab)
			{
				sumoBluePrefab = _sumoBluePrefab;
				sumoRedPrefab = _sumoRedPrefab;
			}
		}
    }
}