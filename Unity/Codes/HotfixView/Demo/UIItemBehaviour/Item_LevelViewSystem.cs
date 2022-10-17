
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_LevelDestroySystem : DestroySystem<Scroll_Item_Level> 
	{
		public override void Destroy( Scroll_Item_Level self )
		{
			self.DestroyWidget();
		}
	}
}
