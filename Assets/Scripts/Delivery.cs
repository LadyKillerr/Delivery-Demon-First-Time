using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Delivery : MonoBehaviour
{
    // Adding Sound effects through inspector clip

    [SerializeField] AudioClip deliveredSFX;
    [SerializeField] AudioClip pickupSFX;

    // How long the object will disappear after picked up
    public bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.3f;

    // Changing car's color using these variables 
    [SerializeField] Color32 hasPackageColor = new Color32(243, 253, 82, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    // creating a variables to store our Sprite Renderer so that we can re~use anytime, anywhere
    // creating a component to access later on in Start
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;


    // store things in variables spriteRenderer
    // this is how we getting a component in the start method
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && hasPackage == false)
        {
            Debug.Log("Your car has picked up the package.");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
            // Play Audio
            audioSource.PlayOneShot(pickupSFX, 0.6f);
        }

        if (other.CompareTag("Customer") && hasPackage == true)
        {
            Debug.Log("You have delivered the package to the customer sucessfully.");
            hasPackage = false;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = noPackageColor;
            // Play delivered sound
            audioSource.PlayOneShot(deliveredSFX, 0.6f);
        }




    }
}
