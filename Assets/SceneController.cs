using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneController : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab; //Serialized variable for linking to the prefab object
    // էս SerializeFieldը գրում ենք էն վախտ, երբ ուզում ենք inspectorի windowում հայտնվի, unityի, բայց ուզում ենք, համել, որ private լինի․
    private GameObject _enemy; // A private variable to keep track of the enemy instance in the scene

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_enemy == null) // էն վախտ կսարքի, երբ ուրիշը չլինի
        {
            _enemy = Instantiate(enemyPrefab) as GameObject; //prefacի objectը copy անող
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
