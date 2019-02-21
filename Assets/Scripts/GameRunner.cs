using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRunner : MonoBehaviour {
    public GameObject MoleContainer;

    private float _spawnDuration = 1.5f;
    private float _spawnDecrement = 0.1f;
    private float _minimumSpawnDuration = 0.5f;

    private List<Mole> _moles;
    private float _spawnTimer;

    // Use this for initialization
    void Start () {
        _moles = GameObject.FindGameObjectsWithTag("Mole").Select(mole => mole.GetComponent<Mole>()).ToList();
        print("Collected " + _moles.Count() + " moles");
        Random.InitState((int)Time.time);
        _moles[Random.Range(0, _moles.Count())].RaiseMole();

    }
	
	// Update is called once per frame
	void Update () {
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer <= 0f) {
            _moles[Random.Range(0, _moles.Count())].RaiseMole();

            _spawnDuration -= _spawnDecrement;
            _spawnTimer = Mathf.Max(_spawnDuration, _minimumSpawnDuration);
        }
    }
}
