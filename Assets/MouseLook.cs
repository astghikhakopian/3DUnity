using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

    public RotationAxes axes = RotationAxes.MouseX;

	// Use this for initialization
	void Start () {
        // ստուգում ենք, թե օբյեկտը գոյություն ունի, թե չէ։ եթե չէ՝ չենք թողում rotate անի։
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;

	}
	
	// Update is called once per frame
	void Update () {
        switch (axes) {
            case RotationAxes.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

                //Debug.Log("Հորիզոնական։");
                break;

            case RotationAxes.MouseY:
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

                //Debug.Log("Վերտիկալ։");
                break;

            case RotationAxes.MouseXAndY:
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float _rotationY = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);

                //Debug.Log("2 ուղղություններով։");
                break;
            default:
                Debug.Log("ձեւ չի");
                break;
        }
	}
}
