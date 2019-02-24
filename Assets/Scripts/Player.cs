using UnityEngine;

public class Player : MonoBehaviour {

    public Hammer Hammer;
    public int Score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit)) {
            if(hit.transform.tag == "Mole") {
                print("Mole [" + hit.transform.gameObject.GetInstanceID() + "] hit");
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Score += hit.transform.GetComponent<Mole>().GetMoleReward;
                    hit.transform.GetComponent<Mole>().HideMole();
                    Hammer.HitMole(hit.transform.position);
                }
            }
        }
	}
}
