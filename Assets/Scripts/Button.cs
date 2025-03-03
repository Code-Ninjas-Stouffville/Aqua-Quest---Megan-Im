using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private bool interactable;

    // Start is called before the first frame update
    public class TemporaryButtonDisable : MonoBehaviour
    {
        public Button myButton; // Reference to the button
        public Text gameText;
        public Image treasurechestImage;
        public Button startButton;


        // Call this method to disable the button temporarily
        public void DisableButtonTemporarily()
        {
            StartCoroutine(DisableButtonCoroutine());
        }

        private IEnumerator DisableButtonCoroutine()
        {
            // Disable interaction with the button
            myButton.interactable = false; // Set the button to non-clickable

            // Wait for 1 second
            yield return new WaitForSeconds(8f);

            // Re-enable interaction with the button
            myButton.interactable = true; // Set the button back to clickable
        }

        public void OnButtonClicked()
        {
            if (SceneManager.sceneCountInBuildSettings > 1)
            {
                SceneManager.LoadScene("Fish and Wish");
                
            }
        }

        void Start()
        {
            gameText.gameObject.SetActive(true);
            treasurechestImage.gameObject.SetActive(true);


        }

        void OnStartButtonClick()
        {
            gameText.gameObject.SetActive(false);
            treasurechestImage.gameObject.SetActive(false);
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
