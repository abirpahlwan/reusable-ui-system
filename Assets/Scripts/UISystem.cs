using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Reusable.UI {
	public class UISystem : MonoBehaviour {
		
		#region Variables
		[Header("Main Properties")]
		public UIScreen startScreen;
		
		[Header("System Events")]
		public UnityEvent onSwitchedScreen = new UnityEvent();

		[Header("Fader Properties")]
		[SerializeField] private Image fader;
		[SerializeField] private float fadeInDuration = 1.8f;
		[SerializeField] private float fadeOutDuration = 1.8f;
		
		private Component[] screens = new Component[0];
		
		private UIScreen previousScreen;
		public UIScreen PreviousScreen {get {return previousScreen;}}
		
		private UIScreen currentScreen;
		public UIScreen CurrentScreen {get {return currentScreen;}}

		#endregion


		#region Unity Methods
		void OnEnable() {
			screens = GetComponentsInChildren<UIScreen>(true);
		}

		void Start() {
			InitilizeScreens();
			
			if (startScreen) {
				SwitchScreen(startScreen);
			}

			if (fader) {
				fader.gameObject.SetActive(true);
			}
			FadeIn();
		}
		#endregion

		
		#region Helper Methods
		private void InitilizeScreens() {
			foreach (var screen in screens) {
				screen.gameObject.SetActive(true);
			}
		}

		public void SwitchScreen(UIScreen uiScreen) {
			if (uiScreen) {
				if (currentScreen) {
					currentScreen.CloseScreen();
					previousScreen = currentScreen;
				}

				currentScreen = uiScreen;
				currentScreen.gameObject.SetActive(true);
				currentScreen.StartScreen();

				if (onSwitchedScreen != null) {
					onSwitchedScreen.Invoke();
				}
			}
		}

		public void FadeIn() {
			if (fader) {
				fader.CrossFadeAlpha(0f, fadeInDuration, false);
			}
		}
		
		public void FadeOut() {
			if (fader) {
				fader.CrossFadeAlpha(1f, fadeOutDuration, false);
			}
		}

		public void GoToPreviousScreen() {
			if (previousScreen) {
				SwitchScreen(previousScreen);
			}
		}

		public void LoadScene(int sceneIndex) {
			StartCoroutine(WaitToLoadScene(sceneIndex));
		}

		IEnumerator WaitToLoadScene(int sceneIndex) {
			yield return null;
		}
		#endregion
	}
}
