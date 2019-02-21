using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {
    public float MoveSpeed;

    private float _hiddenHeight = 0.442f;
    private float _visibleHeight = 1.23f;
    private float _hideDuration = 1.25f;
    private float _timeToHide;

    private Vector3 _targetPosition;

    public void HideMole() {
        _targetPosition.y = _hiddenHeight;
    }

    public void RaiseMole() {
        _targetPosition.y = _visibleHeight;
        _timeToHide = Time.time + _hideDuration;
    }

    // Use this for initialization
    void Awake () {
        _targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        if(Time.time > _timeToHide) {
            HideMole();
        }

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * MoveSpeed);
	}
}
