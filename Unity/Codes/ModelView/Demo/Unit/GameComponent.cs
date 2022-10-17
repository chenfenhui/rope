using System.Collections.Generic;
using UnityEngine;

namespace ET
{

	public enum GameState
	{
		None,
		Init,
		Rope,
		Start,
		End
	}

	public class GameComponent : Entity, IAwake<string>, IUpdate, IDestroy
	{
		public Transform CarPos;

		public GameState State = GameState.None;

		public GameObject Car;

		public GameObject Level;

		public bool IsEnd;

		public bool IsPlay1;
	}
}