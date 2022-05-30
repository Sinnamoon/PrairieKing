namespace Assets.Scripts.UI
{
    using TMPro;
    using UnityEngine;

    public class UIController : MonoBehaviour
    {
        [System.Serializable]
        private class LeftSideUI
        {
            [SerializeField]
            public TextMeshProUGUI lifeCountText;

            [SerializeField]
            public TextMeshProUGUI coinCountText;


        }

        [System.Serializable]
        private class TopSideUI
        {
            [SerializeField]
            private TimerSlider timerSlider;

            public TimerSlider GetTimeSlider => timerSlider;
        }

        [SerializeField]
        private LeftSideUI leftSideUI = new LeftSideUI();

        [SerializeField]
        private TopSideUI topSideUI = new TopSideUI();

        public void TimerStart(float second)
        {
            topSideUI.GetTimeSlider.TimerStart(10f);
        }

        #region Wrong
        
        private void Awake()
        {
            LiteEvents.OnPlayerDeadCallback += Ded;
            LiteEvents.OnButtonPressedPlay += Respawn;


        }

        private void Ded()
        {
            SetPlayerLives(0);
        }

        private void Respawn()
        {
            SetPlayerLives(1);
        }

        private void SetPlayerLives(in int count) => leftSideUI.lifeCountText.text = $"x{count}";




        #endregion

    }
}