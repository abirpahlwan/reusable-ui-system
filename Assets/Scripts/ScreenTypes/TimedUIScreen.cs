using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Reusable.UI
{
    public class TimedUIScreen : UIScreen
    {
        #region Variables

        [Header("Timed Screen Properties")]
        [SerializeField] private float screenTime = 2.0f;
        public UnityEvent onTimeCompleted = new UnityEvent();

        private float startTime;

        #endregion

        
        #region Helper Methods

        public override void StartScreen() {
            base.StartScreen();

            startTime = Time.time;
            StartCoroutine(WaitForTime());
        }

        IEnumerator WaitForTime() {
            yield return new WaitForSeconds(screenTime);

            if (onTimeCompleted != null) {
                onTimeCompleted.Invoke();
            }    
        }

        #endregion
    }
}