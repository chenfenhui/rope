
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgLoginViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image ELoopScrollList_LevelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_LevelImage == null )
     			{
		    		this.m_ELoopScrollList_LevelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bg/ELoopScrollList_Level");
     			}
     			return this.m_ELoopScrollList_LevelImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_LevelLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_LevelLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_LevelLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Bg/ELoopScrollList_Level");
     			}
     			return this.m_ELoopScrollList_LevelLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELoopScrollList_LevelImage = null;
			this.m_ELoopScrollList_LevelLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_ELoopScrollList_LevelImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_LevelLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
