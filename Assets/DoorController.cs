using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorArt;

    public float animLength = 0.5f;
    private float animTimer = 0;
    private bool animIsPlaying = false;
    private float doorAngle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        // Fire1 = left mouse button.

        if (animIsPlaying)
        {
            animTimer += Time.deltaTime; // playing the animation...

            float percent = animTimer / animLength;

            if (percent < 0) percent = 0;
            if (percent > 1) percent = 1;

            doorAngle = percent * 90;
            doorArt.rotation = Quaternion.Euler(0, doorAngle, 0); // set angle of door art.
        }
    }

    private void OnMouseEnter() // Detects when mouse is hovering over 3D object.
    {
        print("Mouse over!");
    }

    private void OnMouseDown() // Detects when left mouse button is pressed.
    {
        print("Mouse clicked!");
        // change something??
        // Destroy(gameObject);
    }

    public void PlayerInteract()
    {
        animIsPlaying = true;
        animTimer = 0;
    }
}
