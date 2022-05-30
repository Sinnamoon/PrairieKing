namespace Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;

    public class MenuScreen : MonoBehaviour
    {
        [SerializeField]
        GameObject menuToHideUI;

        [SerializeField]
        Button playButton;

        [SerializeField]
        Button contunieButton;

        public void Show()
        {
            menuToHideUI.SetActive(true);

            bool status = FindObjectOfType<PlayerController>() == null;
            if (status)
            {
                playButton.gameObject.SetActive(status);
                contunieButton.gameObject.SetActive(!status);
            }
            else
            {
                playButton.gameObject.SetActive(status);
                contunieButton.gameObject.SetActive(!status);
            }

        }

        public void Hide()
        {
            menuToHideUI.SetActive(false);
        }

        public void Play()
        {
            LiteEvents.OnButtonPressedPlay?.Invoke();
        }

        public void Contunie()
        {
            LiteEvents.OnButtonPressedContinue?.Invoke();
        }

        public void Exit()
        {
            Application.Quit();
        }

       
    }
}