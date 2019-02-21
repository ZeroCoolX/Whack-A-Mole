using UnityEngine;

public class Player : MonoBehaviour {

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
                    hit.transform.GetComponent<Mole>().HideMole();
                }
            }
        }
	}
}
