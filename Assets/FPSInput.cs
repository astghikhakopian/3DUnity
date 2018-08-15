using UnityEngine;
using System.Collections;

// 1. որ վստահ լինի, որ scriptին պետք եկած սաղ componentները կցված են։
// 2. որ կողը կցվի unityի editorին։
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour {
    public float speed = 6.0f;
    //public float gravity = 1f; // սա, որ վերեւ չթռնի։
    private CharacterController _charController;

    void Start() {
        _charController = GetComponent<CharacterController>();
    }
    void Update() {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        //movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
