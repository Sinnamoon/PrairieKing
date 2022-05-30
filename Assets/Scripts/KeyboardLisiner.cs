namespace Assets.Scripts
{
    using UnityEngine;
    using System.Collections;

    public class KeyboardLisiner : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                LiteEvents.OnEscapeButtonPressed?.Invoke();
        }

    }
}