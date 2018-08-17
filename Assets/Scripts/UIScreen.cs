using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Reusable.UI {
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CanvasGroup))]
	public class UIScreen : MonoBehaviour {
		
		#region Variables
		[Header("Main Properties")]
		[SerializeField] private Selectable startSelectable;
		
		[Header("Screen Events")]
		public UnityEvent onScreenStart = new UnityEvent();
		public UnityEvent onScreenClose = new UnityEvent();

		private Animator animator;
		#endregion


		#region Unity Methods
		void OnEnable() {
			animator = GetComponent<Animator>();
		}
		
		void Start() {
			if (startSelectable) {
				EventSystem.current.SetSelectedGameObject(startSelectable.gameObject);
			}
		}
		#endregion

		
		#region Helper Methods
		public virtual void StartScreen() {
			if (onScreenStart != null) {
				onScreenStart.Invoke();
			}

			HandleAnimator("show");
		}

		public virtual void CloseScreen() {
			if (onScreenClose != null) {
				onScreenClose.Invoke();
			}

			HandleAnimator("hide");
		}

		private void HandleAnimator(string trigger) {
			if (animator) {
				animator.SetTrigger(trigger);
			}
		}
		#endregion
	}
}
