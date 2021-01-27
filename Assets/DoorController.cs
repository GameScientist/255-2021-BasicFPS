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

    private bool isClosed = true;


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
            if (!isClosed)
                animTimer += Time.deltaTime;
            else
                animTimer -= Time.deltaTime; // playing the animation...

            float percent = animTimer / animLength;

            if (percent < 0 && isClosed)
            {
                percent = 0;
                animIsPlaying = false;
            }
            if (percent > 1 && !isClosed)
            {
                percent = 1;
                animIsPlaying = false;
            }

            doorAngle = percent * 90;
            doorArt.rotation = Quaternion.Euler(0, doorAngle * percent, 0); // set angle of door art.
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

    public void PlayerInteract(Vector3 position)
    {
        if (animIsPlaying) return;

        if (!Inventory.main.hasKey) return;
        // if (isClosed) isClosed = false;
        // else isClosed = true;


        Vector3 disToPlayer = position - transform.position;
        disToPlayer = disToPlayer.normalized;

        
        bool playerOnOtherSide = (Vector3.Dot(disToPlayer, transform.forward) > 0f);
        
        isClosed = !isClosed;

        //if (!isClosed)
        //{
        //    doorAngle = 90;
        //    if (playerOnOtherSide) doorAngle = -90;
        //}

        if(!isClosed) doorAngle = (playerOnOtherSide) ? -90 : 90;


        animIsPlaying = true;

        // set playhead to end (or beginning)
        if (isClosed) animTimer = 0;
        else animTimer = 0;
    }
}
