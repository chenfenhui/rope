using System.Collections.Generic;

namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	public  class DlgLogin :Entity,IAwake,IUILogic
	{

		public DlgLoginViewComponent View { get => this.Parent.GetComponent<DlgLoginViewComponent>();}

		public Dictionary<int, Scroll_Item_Level> levelDic = new Dictionary<int, Scroll_Item_Level>();
	}
}
