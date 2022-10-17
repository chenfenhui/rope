using System;
using UnityEngine;

namespace ET
{
	[ObjectSystem]
	public class GameComponentAwakeSystem : AwakeSystem<GameComponent, string>
	{
		public override void Awake(GameComponent self, string level)
		{
			self.InitLevel(level).Coroutine();
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
			GameObject.Destroy(self.Level?.gameObject);
		}
	}

	public static class GameComponentSystem
	{
		public static async ETTask InitLevel(this GameComponent self,string level)
		{
			
			GameObject levelPre = ResourcesComponent.Instance.GetAsset("unit.unity3d", level) as GameObject;
			self.Level = GameObject.Instantiate(levelPre);
			Transform pos1 = self.Level.transform.Find("Static/Pos1").transform;
            self.CarPos = self.Level.transform.Find("Static/Pos2").transform;
			self.Car = self.Level.transform.Find("Static/Car").gameObject;
			self.Car.transform.position = pos1.position;
			GlobalComponent.Instance.CM1.Follow = self.Car.transform;
			GlobalComponent.Instance.CM1.LookAt = self.Car.transform;
            GlobalComponent.Instance.CM1.Priority = 10;
            GlobalComponent.Instance.CM2.Priority = 0;

			await TimerComponent.Instance.WaitAsync(200);
			GlobalComponent.Instance.Unit.GetComponent<RopeManager>().ResetLevel();
			self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Lobby);
            self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Login);
			self.State = GameState.Init;
        }

		public static void RigidCtrlActive(this GameComponent self)
		{
			var ctrls = self.Level.GetComponentsInChildren<RigidCtrl>();
			for (int i = 0; i < ctrls.Length; i++)
			{
				ctrls[i].enabled = true;
			}
		}

		public static async void Update(this GameComponent self)
		{

			if (self.State == GameState.Init)
			{
				self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLobby>().ReadyVisible(false);
				self.Car.transform.position = Vector3.Lerp(self.Car.transform.position, self.CarPos.position, Time.deltaTime);
				GlobalComponent.Instance.Unit.GetComponent<RopeManager>().Selectable = false;
				if (Vector3.Distance(self.Car.transform.position, self.CarPos.position) <= 5f)
				{
					self.State = GameState.Rope;
					GlobalComponent.Instance.Unit.GetComponent<RopeManager>().Selectable = true;
					GlobalComponent.Instance.CM1.Priority = 0;
					GlobalComponent.Instance.CM2.Priority = 10;
					
				}
				
			}
            else if (self.State == GameState.Rope)
            {
				if (TimerComponent.Instance.level == "Level1")
				{
					self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLobby>().Guide1().Coroutine();
				}
				else if (TimerComponent.Instance.level == "Level2")
				{
					self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLobby>().Guide2().Coroutine();
				}
				if(GlobalComponent.Instance.Unit.GetComponent<RopeManager>().IsAllDragOver())
					self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLobby>().ReadyVisible(true);
				else
					self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLobby>().ReadyVisible(false);
				self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLobby>().SetLength(GlobalComponent.Instance.Unit.GetComponent<RopeManager>().CurLength);
			}
            else if (self.State == GameState.Start)
            {
                self.RigidCtrlActive();
				self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLobby>().ReadyVisible(false);
				self.State = GameState.End;
				self.IsEnd = false;
				await TimerComponent.Instance.WaitAsync(500);
				self.IsEnd = true;
			}
            else if (self.State == GameState.End)
            {
				if (self.IsEnd && self.Car.GetComponent<Rigidbody>()?.velocity.magnitude <= 0.1f)
				{
					if (GlobalComponent.Instance.Unit.GetComponent<RopeManager>().DeteIfAllRopeIsBroken())
					{
						Log.Debug("fail=================");
						self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLobby>().SettleResult(false);
					}
					else
					{
						Log.Debug("success=================");
						self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLobby>().SettleResult(true);
					}
					self.IsEnd = false;
				}
            }

        }

	}
}