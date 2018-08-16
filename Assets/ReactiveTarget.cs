using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

    public void ReactToHit() { // իրան կրակելու t կանչվող method․
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)   // սաղ լինի, նոր սպանենք․ եթե սաղ չի, սատկացնել, նոր սպանել․
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die() {
        this.transform.Rotate(-75, 0, 0); // որ ընկնի, նոր մեռնի

        yield return new WaitForSeconds(1.5f); // չգիտեմ, էս yieldը ինչ ա անում սիշարփում․ կարդալ․ հետո․

        Destroy(this.gameObject); // երբ սաղ referenceները ջնջվում են objectի վրայից, ինքը c#ում էլ ա ջնջվում․ 
        //Destroy()ը նրա համար ա, որ unityի գրաֆում էլ ինքը ջնջվի․ եթե չենք ջնջում,էդ գրաֆի referenceների պատճառով մնում ա հիշողությունում․
    }   
}
