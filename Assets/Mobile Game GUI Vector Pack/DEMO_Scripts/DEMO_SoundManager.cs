using UnityEngine;

public class DEMO_SoundManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayClickSound() {
        this.GetComponent<AudioSource>().Play();
    }
}
