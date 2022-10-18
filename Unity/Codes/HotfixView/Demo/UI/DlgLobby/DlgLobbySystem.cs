using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgLobbySystem
	{

		public static void RegisterUIEvent(this DlgLobby self)
		{
		  self.View.E_EnterMapButton.AddListener(()=>
		  {
			  GlobalComponent.Instance.Unit.GetComponent<RopeManager>().Selectable = false;
			  self.ZoneScene().CurrentScene().GetComponent<GameComponent>().State = GameState.Start;
		  });

			self.View.E_ContinueButton.AddListener(() =>
			{
				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Login);
				self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Lobby);
			});

            self.View.E_MainButton.AddListener(() =>
            {
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Login);
                self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Lobby);
            });

            self.View.E_AgainButton.AddListener(() =>
            {
				SceneChangeHelper.SceneChangeTo(self.ZoneScene(), TimerComponent.Instance.level).Coroutine();
            });

        }

		public static void ShowWindow(this DlgLobby self, Entity contextData = null)
		{
			self.SetLength(0);
		}

        public static void HideWindow(this DlgLobby self)
        {
			self.ZoneScene().CurrentScene()?.Dispose();
        }

        public static void ReadyVisible(this DlgLobby self, bool isVisible)
		{
			EUIHelper.SetVisible(self.View.E_EnterMapButton,isVisible);
		}

        public static void SetLength(this DlgLobby self, float length)
        {
			self.View.ELabel_LengthText.text = (GlobalComponent.Instance.Unit.GetComponent<RopeManager>().AllLength - length) + "m";
			self.View.E_FillImage.fillAmount = (GlobalComponent.Instance.Unit.GetComponent<RopeManager>().AllLength - length) / 
				(float)GlobalComponent.Instance.Unit.GetComponent<RopeManager>().AllLength;

		}

        public static async ETTask Guide1(this DlgLobby self)
        {
			await TimerComponent.Instance.WaitAsync(200);
            EUIHelper.SetVisible(self.View.EGuide1RectTransform, true);
        }

        public static async ETTask Guide2(this DlgLobby self)
        {
            await TimerComponent.Instance.WaitAsync(200);
            EUIHelper.SetVisible(self.View.EGuide2RectTransform, true);
            await TimerComponent.Instance.WaitAsync(1000);
            EUIHelper.SetVisible(self.View.EGuide3RectTransform, true);
        }

        public static void SettleResult(this DlgLobby self, bool isWin)
        {
            EUIHelper.SetVisible(self.View.EG_SettlementRectTransform, true);
			if (isWin)
			{
				self.View.E_ResultText.text = "<color=#00ff00>Success</color>";
			}
			else
			{
				self.View.E_ResultText.text = "<color=#ff0000>Fail</color>";
			}

			self.View.E_LevelText.text = self.ZoneScene().CurrentScene().Name;

		}
    }
}
