using Obi;
using System;
using UnityEngine;

namespace ET
{
	[ObjectSystem]
	public class GameComponentAwakeSystem : AwakeSystem<GameComponent>
	{
		public override void Awake(GameComponent self)
		{
			self.InitLevel();
		}
	}

	[ObjectSystem]
	public class GameComponentUpdateSystem : UpdateSystem<GameComponent>
	{
		public override void Update(GameComponent self)
		{
			self.Update();
		}
	}
	
	[ObjectSystem]
	public class GameComponentDestroySystem : DestroySystem<GameComponent>
	{
		public override void Destroy(GameComponent self)
		{
			GameObject.Destroy(self.Car?.gameObject);
		}
	}

	public static class GameComponentSystem
	{
		public static void InitLevel(this GameComponent self)
		{
			Transform carFirstPos = GameObject.Find("/CarFirstPos").transform;
			self.CarPos = GameObject.Find("/CarPos").transform;
			GameObject car = ResourcesComponent.Instance.GetAsset("unit.unity3d", "JiRouChe") as GameObject;
			self.Car = GameObject.Instantiate(car, GlobalComponent.Instance.Unit);
			self.Car.transform.position = carFirstPos.position;
			GlobalComponent.Instance.CM1.Follow = self.Car.transform;
			GlobalComponent.Instance.CM1.LookAt = self.Car.transform;
            GlobalComponent.Instance.CM1.Priority = 10;
            GlobalComponent.Instance.CM2.Priority = 0;
        }

		public static void Update(this GameComponent self)
		{
			if (self.State == GameState.Init)
			{
				self.Car.transform.position = Vector3.Lerp(self.Car.transform.position, self.CarPos.position, Time.deltaTime);

				if (Vector3.Distance(self.Car.transform.position, self.CarPos.position) <= 1f)
				{
					self.State = GameState.Rope;
					GlobalComponent.Instance.CM1.Priority = 0;
					GlobalComponent.Instance.CM2.Priority = 10;
				}
			}
			else if (self.State == GameState.Rope)
			{
				if (Input.GetMouseButtonDown(0))
				{
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
					if (Physics.Raycast(ray, out hit))
					{
						if (hit.collider.tag == "Rod")
						{
							GameObject ropePrefab = ResourcesComponent.Instance.GetAsset("unit.unity3d", "Rope") as GameObject;
							GameObject rope = GameObject.Instantiate(ropePrefab, GlobalComponent.Instance.Unit);
							self.CurRope = rope.GetComponent<RopeCtrl>();
							self.CurRope.AddAttachment(hit.collider.transform, RopeDot.start);
							self.CurRope.AddAttachment(hit.collider.transform, RopeDot.start2);
							self.CurRope.SetLength(1000f);
						}
					}

                }
			}
		}

	}
}