using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {
    public float MoveSpeed;
    public int GetMoleReward { get { return _reward; } }

    private int _reward;

    private float _hiddenHeight = 0.442f;
    private float _visibleHeight = 1.23f;
    private Vector2 _hideDurationRange = new Vector2(1.25f, 3f);
    private float _timeToHide;

    private Vector3 _targetPosition;

    public void HideMole() {
        _targetPosition.y = _hiddenHeight;
        _reward = 0;
    }

    public void RaiseMole() {
        _targetPosition.y = _visibleHeight;
        _timeToHide = Time.time + _hideDurationRange.x;// Random.Range(_hideDurationRange.x, _hideDurationRange.y);
        _reward = 1;
    }

    // Use this for initialization
    void Awake () {
        _targetPosition = transform.position;
        Random.InitState((int)Time.time);
    }

    // Update is called once per frame
    void Update () {
        if(Time.time > _timeToHide) {
            HideMole();
        }

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * MoveSpeed);
	}
}
