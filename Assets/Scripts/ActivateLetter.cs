using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivateLetter : MonoBehaviour
{
    public float displayDuration = 5f; // Duration to display the image

     [SerializeField] private GameObject imageToActivate;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player colliding
        {
            StartCoroutine(DisplayImage());
        }
    }

    IEnumerator DisplayImage()
    {
        imageToActivate.SetActive(true); // Activate the image
        yield return new WaitForSeconds(displayDuration); // Wait for the specified duration
        imageToActivate.SetActive(false); // Deactivate the image
    }
}
