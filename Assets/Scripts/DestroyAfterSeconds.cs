using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

    public float seconds = 1f;

	// Use this for initialization
	void Start () {
        StartCoroutine(destroyAfter(seconds));
	}

    IEnumerator destroyAfter(float seconds){
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
