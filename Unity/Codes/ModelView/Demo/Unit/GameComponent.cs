using Obi;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{

	public enum GameState
	{
		Init,
		Rope,
	}

	public class GameComponent : Entity, IAwake, IUpdate, IDestroy
	{
		public Transform CarPos;

		public GameState State = GameState.Init;

		public GameObject Car;

		public RopeCtrl CurRope;
	}
}