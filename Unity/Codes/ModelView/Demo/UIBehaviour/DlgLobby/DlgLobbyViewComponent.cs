
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgLobbyViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_EnterMapButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapButton == null )
     			{
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterMapImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapImage == null )
     			{
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public UnityEngine.UI.Button E_AgainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AgainButton == null )
     			{
		    		this.m_E_AgainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Again");
     			}
     			return this.m_E_AgainButton;
     		}
     	}

		public UnityEngine.UI.Image E_AgainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AgainImage == null )
     			{
		    		this.m_E_AgainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Again");
     			}
     			return this.m_E_AgainImage;
     		}
     	}

		public UnityEngine.UI.Button E_MainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainButton == null )
     			{
		    		this.m_E_MainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Main");
     			}
     			return this.m_E_MainButton;
     		}
     	}

		public UnityEngine.UI.Image E_MainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainImage == null )
     			{
		    		this.m_E_MainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Main");
     			}
     			return this.m_E_MainImage;
     		}
     	}

		public UnityEngine.UI.Image E_FillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FillImage == null )
     			{
		    		this.m_E_FillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/GameObject/E_Fill");
     			}
     			return this.m_E_FillImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_LengthText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_LengthText == null )
     			{
		    		this.m_ELabel_LengthText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/GameObject/ELabel_Length");
     			}
     			return this.m_ELabel_LengthText;
     		}
     	}

		public UnityEngine.RectTransform EG_SettlementRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SettlementRectTransform == null )
     			{
		    		this.m_EG_SettlementRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround/EG_Settlement");
     			}
     			return this.m_EG_SettlementRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_ResultText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ResultText == null )
     			{
		    		this.m_E_ResultText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EG_Settlement/E_Result");
     			}
     			return this.m_E_ResultText;
     		}
     	}

		public UnityEngine.UI.Text E_LevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelText == null )
     			{
		    		this.m_E_LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EG_Settlement/E_Level");
     			}
     			return this.m_E_LevelText;
     		}
     	}

		public UnityEngine.UI.Button E_ContinueButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ContinueButton == null )
     			{
		    		this.m_E_ContinueButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EG_Settlement/E_Continue");
     			}
     			return this.m_E_ContinueButton;
     		}
     	}

		public UnityEngine.UI.Image E_ContinueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ContinueImage == null )
     			{
		    		this.m_E_ContinueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EG_Settlement/E_Continue");
     			}
     			return this.m_E_ContinueImage;
     		}
     	}

		public UnityEngine.RectTransform EGuide1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGuide1RectTransform == null )
     			{
		    		this.m_EGuide1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround/EGuide1");
     			}
     			return this.m_EGuide1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGuide2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGuide2RectTransform == null )
     			{
		    		this.m_EGuide2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround/EGuide2");
     			}
     			return this.m_EGuide2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGuide3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGuide3RectTransform == null )
     			{
		    		this.m_EGuide3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround/EGuide3");
     			}
     			return this.m_EGuide3RectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_EnterMapButton = null;
			this.m_E_EnterMapImage = null;
			this.m_E_AgainButton = null;
			this.m_E_AgainImage = null;
			this.m_E_MainButton = null;
			this.m_E_MainImage = null;
			this.m_E_FillImage = null;
			this.m_ELabel_LengthText = null;
			this.m_EG_SettlementRectTransform = null;
			this.m_E_ResultText = null;
			this.m_E_LevelText = null;
			this.m_E_ContinueButton = null;
			this.m_E_ContinueImage = null;
			this.m_EGuide1RectTransform = null;
			this.m_EGuide2RectTransform = null;
			this.m_EGuide3RectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_E_EnterMapButton = null;
		private UnityEngine.UI.Image m_E_EnterMapImage = null;
		private UnityEngine.UI.Button m_E_AgainButton = null;
		private UnityEngine.UI.Image m_E_AgainImage = null;
		private UnityEngine.UI.Button m_E_MainButton = null;
		private UnityEngine.UI.Image m_E_MainImage = null;
		private UnityEngine.UI.Image m_E_FillImage = null;
		private UnityEngine.UI.Text m_ELabel_LengthText = null;
		private UnityEngine.RectTransform m_EG_SettlementRectTransform = null;
		private UnityEngine.UI.Text m_E_ResultText = null;
		private UnityEngine.UI.Text m_E_LevelText = null;
		private UnityEngine.UI.Button m_E_ContinueButton = null;
		private UnityEngine.UI.Image m_E_ContinueImage = null;
		private UnityEngine.RectTransform m_EGuide1RectTransform = null;
		private UnityEngine.RectTransform m_EGuide2RectTransform = null;
		private UnityEngine.RectTransform m_EGuide3RectTransform = null;
		public Transform uiTransform = null;
	}
}
