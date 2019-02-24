using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    private Vector3 _restingPosition;

	// Use this for initialization
	void Start () {
        _restingPosition = transform.position;
    }

    public void HitMole(Vector3 targetPosition) {
        transform.position = targetPosition;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, _restingPosition, Time.deltaTime);
	}
}
