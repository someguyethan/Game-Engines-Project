using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamController : MonoBehaviour
{
    public PlaceTile tileManager;
    public Canvas canvas;
    public Camera cam;
    public float freelookSpeed = 1f;
    bool isFreelook = false;
    public PlayerMovement pm;


    private void Start()
    {
        tileManager.enabled = false;
        cam.enabled = false;
        canvas.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isFreelook = !isFreelook;
            pm.canMove = !pm.canMove;
            //tileManager.ClearPreviews(tileManager.wPos);
        }
        if (isFreelook)
        {
            tileManager.enabled = true;
            canvas.enabled = true;
            cam.enabled = true;

            if (Input.GetKey(KeyCode.W))
                cam.transform.position = new Vector3(cam.transform.position.x,
                                                     cam.transform.position.y + freelookSpeed * Time.deltaTime,
                                                     -10f);
            if (Input.GetKey(KeyCode.A))
                cam.transform.position = new Vector3(cam.transform.position.x - freelookSpeed * Time.deltaTime,
                                                     cam.transform.position.y,
                                                     -10f);
            if (Input.GetKey(KeyCode.S))
                cam.transform.position = new Vector3(cam.transform.position.x,
                                                     cam.transform.position.y - freelookSpeed * Time.deltaTime,
                                                     -10f);
            if (Input.GetKey(KeyCode.D))
                cam.transform.position = new Vector3(cam.transform.position.x + freelookSpeed * Time.deltaTime,
                                                     cam.transform.position.y,
                                                     -10f);
        }
        else if (!isFreelook)
        {
            cam.enabled = false;
            tileManager.enabled = false;
            canvas.enabled = false;
        }
    }
}
