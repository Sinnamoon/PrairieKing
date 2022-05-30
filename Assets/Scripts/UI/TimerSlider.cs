namespace Assets.Scripts.UI
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;

    [RequireComponent(typeof(Slider))]
    public class TimerSlider : MonoBehaviour
    {
        [SerializeField]
        [Range(10, 60)]
        private float defaultWaveSeconds = 10;

        private Slider _TimerSlider;

        #region Properties
        
        public Action TimeEndCallback { get; set; }

        private float SliderValue { get => _TimerSlider.value; set => _TimerSlider.value = value; }

        private float GetMaxSliverValue => _TimerSlider.maxValue;
        private float GetMinSliverValue => _TimerSlider.minValue;

        #endregion
        private void OnValidate()
        {
            GetComponent<Slider>().minValue = 0;
        }

        #region Wrong

        private void Awake()
        {
            TimeEndCallback += SpawnEnemiesAgain;
            LiteEvents.OnPlayerDeadCallback += TimerReset;
        }

        private void SpawnEnemiesAgain()
        {
            FindObjectOfType<EnemySpawnController>().SpawnEnemy(100);
            TimerReset();
            TimerStart();
        }

        #endregion

        private void OnEnable()
        {
            _TimerSlider = GetComponent<Slider>();
        }

        public void TimerStart(float seconds = default)
        {
            if (seconds == default)
                seconds = defaultWaveSeconds;

            TimerReset();
            StartCoroutine(TimerStartCoroutin(seconds));
        }

        private IEnumerator TimerStartCoroutin(float seconds)
        {
            _TimerSlider.maxValue = seconds;
            SliderValue = GetMaxSliverValue;
            SliderValue = seconds;

            while (0.05f < SliderValue)//for faster 0.05f but 0 is correct too
            {
                
                SliderValue = Mathf.MoveTowards(SliderValue, seconds, -1f * Time.deltaTime);

                yield return null;
            }            
            TimeEndCallback?.Invoke();            
        }

        public void TimerReset()
        {
            StopAllCoroutines();
        }

    }
}
