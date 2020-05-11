using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float mainSpeed = 10f; //regular speed

    [SerializeField] float scrollSpeed = 1f;
    [SerializeField] float maxFOV = 60f;
    [SerializeField] float minFOV = 35f;
    [SerializeField] float fovSpeed = 3f;
    
    private float totalRun = 1.0f;
    public Vector3 TargetPos;

    private Vector3 dragOrigin;
    private float dragSpeed = 10f;

    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {

        //Keyboard commands
        if (Main.Instance.phase != GamePhase.Shop)
        {
            float f = 0.0f;
            Vector3 p = GetBaseInput();

            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;

            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0.0f)
            {
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - fovSpeed, minFOV, maxFOV); 
            } else if (scroll < 0.0f)
            {
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + fovSpeed, minFOV, maxFOV);
            }

                if (Input.GetMouseButtonDown(2))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(2)) return;

            

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(-pos.x * dragSpeed * (camera.fieldOfView/minFOV), 0, -pos.y * dragSpeed * (camera.fieldOfView / minFOV));
            dragOrigin = Input.mousePosition;

            move += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * transform.forward;

            transform.Translate(move, Space.World);

        } else //automatic camera movement
        {
            float f = 0.0f;
            Vector3 p = TargetPos - transform.position;

            if (camera.fieldOfView > minFOV)
            {
                camera.fieldOfView -= 0.2f;
            }

            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p.normalized * mainSpeed;

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;

            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
            if ((transform.position - TargetPos).magnitude < 0.1f)
            {
                transform.position = TargetPos;
            }
        }
    }

    public void MoveTo(Vector3 target)
    {
        TargetPos = target + new Vector3(0, 0, -15f);
        TargetPos.y = transform.position.y;
    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 then it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
