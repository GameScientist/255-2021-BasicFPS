using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float cameraPitch;
    public float moveSpeed = 2;
    public float mouseSensitivityX = 10;
    public float mouseSensitivityY = 10;

    private CharacterController pawn;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        TurnPlayer();
    }

    void TurnPlayer()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        transform.Rotate(0, h * mouseSensitivityX, 0);

        //cam.transform.Rotate(v * mouseSensitivityY, 0, 0);

        cameraPitch += v * mouseSensitivityY;

        if (cameraPitch < -80) cameraPitch = -80;
        if (cameraPitch > 80) cameraPitch = 80;

        cam.transform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
    }

    void MovePlayer()
    {
        // get input:

        float v = Input.GetAxis("Vertical");// W + S / UP + DOWN: a value between -1 and 1.
        float h = Input.GetAxis("Horizontal"); // A+D / LEFT+RIGHT : a value between -1 and 1.

        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime * h * moveSpeed;
        //transform.position += new Vector3(0, 0, 1) * Time.deltaTime * v * moveSpeed;

        //transform.position += (transform.right * h + transform.forward * v) * moveSpeed * Time.deltaTime;

        Vector3 speed = (transform.right * h + transform.forward * v) * moveSpeed;

        pawn.SimpleMove(speed); // simple move add gravity for us!
    }
}
