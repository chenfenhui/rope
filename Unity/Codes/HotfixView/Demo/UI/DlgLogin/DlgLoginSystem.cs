using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET
{



	public static  class DlgLoginSystem
	{

		public static void RegisterUIEvent(this DlgLogin self)
		{
			
		}

		public static void ShowWindow(this DlgLogin self, Entity contextData = null)
		{
			self.AddUIScrollItems<DlgLogin, Scroll_Item_Level>(ref self.levelDic, 48);
			self.View.ELoopScrollList_LevelLoopVerticalScrollRect.AddItemRefreshListener(self.ShowItem);
			self.View.ELoopScrollList_LevelLoopVerticalScrollRect.SetVisible(true, 48);
		}

		
		public static void HideWindow(this DlgLogin self)
		{
			self.RemoveUIScrollItems<DlgLogin, Scroll_Item_Level>(ref self.levelDic);
		}

		public static void ShowItem(this DlgLogin self,Transform trans,int index)
		{
			Scroll_Item_Level item = self.AddChild<Scroll_Item_Level>().BindTrans(trans);
			item.ELabel_LevelText.text = (index + 1).ToString();
			item.EButton_SelectButton.AddListener(() => 
			{ 
				SceneChangeHelper.SceneChangeTo(self.ZoneScene(), $"Level{index + 1}").Coroutine();
				TimerComponent.Instance.level = $"Level{index + 1}";

			});
			
		}


	}
}
