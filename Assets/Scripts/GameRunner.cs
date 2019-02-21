using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRunner : MonoBehaviour {
    public Player Player;
    public TextMesh InfoText;
    public float GameTimer = 30f;

    private float _spawnDuration = 1.5f;
    private float _spawnDecrement = 0.1f;
    private float _minimumSpawnDuration = 0.5f;

    private List<Mole> _moles;
    private float _spawnTimer;

    private float _resetTimer = 10f;

    // Use this for initialization
    void Start () {
        _moles = GameObject.FindGameObjectsWithTag("Mole").Select(mole => mole.GetComponent<Mole>()).ToList();
        Random.InitState((int)Time.time);
    }
	
	// Update is called once per frame
	void Update () {
        var score = "["+Player.Score+"]";
        if((GameTimer -= Time.deltaTime) > 0f) {
            InfoText.text = "WHACK THOSE MOLES!\nTime (" + Mathf.Floor(GameTimer) + ")\nMoles Whacked " + score;
            SpawnMoleIfReady();
        } else {
            InfoText.text = "Game Over\nYou Whacked " + score + " Moles!";
            InfoText.text += "\nRestarting in ("+Mathf.Floor(_resetTimer)+") seconds";
            if ((_resetTimer -= Time.deltaTime) < 0f) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void SpawnMoleIfReady() {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0f) {
            _moles[Random.Range(0, _moles.Count())].RaiseMole();

            _spawnDuration -= _spawnDecrement;
            _spawnTimer = Mathf.Max(_spawnDuration, _minimumSpawnDuration);
        }
    }
}
