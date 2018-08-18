using UnityEngine;
using UnityEditor;

namespace Reusable.UI {
	public class UIMenu : MonoBehaviour {
		
		[MenuItem("GameObject/UI/Reusable UI/UIGroup")]
		public static void CreateUIGroup() {
			GameObject uiGroup = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/UIGroup.prefab");

			if (uiGroup) {
				GameObject createdGroup = Instantiate(uiGroup);
				createdGroup.name = "UIGroup";
			} else {
				EditorUtility.DisplayDialog("Reusable UI Warning", "Cannot find UIGroup Prefab", "OK");
			}
		}
	}
}
