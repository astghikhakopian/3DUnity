using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

    public void ReactToHit() { // iran krakelu t kanchvogh method
        StartCoroutine(Die());
    }

    private IEnumerator Die() {
        this.transform.Rotate(-75, 0, 0); // vor ynkni, nor merni

        yield return new WaitForSeconds(1.5f); // chgitem` es yieldy inch a u inch a anum. kardal. heto.

        Destroy(this.gameObject);
    }
}
