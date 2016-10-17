using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public Collider coll;
    public float damage;

    public GameObject hitPS_prefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Enemy"){
            Enemy e = coll.gameObject.GetComponent<Enemy>();
            if(e == null)
                e = coll.gameObject.GetComponent<PointerTo>().obj.GetComponent<Enemy>();

            e.ProjectileHit(damage);

            Vector3 p = coll.contacts[0].point;
            p.y = 0.1f;
            Instantiate(hitPS_prefab, p, Quaternion.Euler(90,0,0));
        }
        Destroy(gameObject);
    }

}
