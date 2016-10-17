using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float health = 100f;

    public GameObject deathPS_prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}


    public void ProjectileHit(float damage){
        health -= damage;
        if(health <= 0f){
            Vector3 pos = transform.position;
            pos.y = 0.1f;

            Instantiate(deathPS_prefab, pos, Quaternion.Euler(90,0,0));
            Destroy(gameObject);
            
        }
    }

}
