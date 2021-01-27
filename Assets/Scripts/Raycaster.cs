using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))] // tells Unity, this script NEEDS to work.
public class Raycaster : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Fire a ray into the screen.

        if (cam != null && Input.GetButtonDown("Fire1"))
        { // Did the user click on this game tick?
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;

            //????
            Debug.DrawRay(ray.origin, ray.direction, Color.black, .5f);

            if (Physics.Raycast(ray, out hit)) // raycast hit a collider in the scene!
            {
                DoorController door = hit.transform.GetComponentInParent<DoorController>();
                if(door != null)
                {
                    door.PlayerInteract(transform.parent.position);
                }
            }
        }
    }

}
