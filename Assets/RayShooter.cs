using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    private Camera _camera;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();

        // hide the mouse cursor at the center of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // That function runs every frame right after the 3D scene is rendered, resulting in everything drawn during OnGUI() appearing on top of the 3D scene(imagine stickers applied to a painting of a landscape
    void OnGUI() {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) { // անընդհատ աշխատում ա։ true ա վերադարձնում էն t, երբ click ա արած։
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0); // rayի համար էկրանի կոորդինատներն ա որոշում։ 
            // pixelWidth, pixelHeightը էկրանի չափերն ա վերադարձնոում։ սսենց գտնում ենք կեբտրոնը էկրանի։
            Ray ray = _camera.ScreenPointToRay(point); // սարքում ենք էդ rayը։
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {  // swiftի inoutից ա outը։
                GameObject hitObject = hit.transform.gameObject; // Retrieve the object the ray hit
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null) {
                    target.ReactToHit(); //  Targetiin asum enk, vor ian krakel en
                } else {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
     }

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
