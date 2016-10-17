using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject projectile_prefab;
    public Transform pointer;
    public float forwardDirOffset = 45f;

    public float projectileDamage = 10f;
    public float walkForce = 500f;
    public float shootForce = 5000f;

    private Rigidbody body;
    private Collider coll;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Vector3 delta = mouse - transform.position;
        delta.y = 0;

        transform.rotation = Quaternion.Euler(0,Mathf.Rad2Deg * Mathf.Atan2(-delta.z, delta.x) + forwardDirOffset,  0);

        Vector3 move = Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical");

        body.AddForce(move.normalized * Time.deltaTime * walkForce);


        if(Input.GetMouseButtonDown(0)){
            GameObject g = Instantiate(projectile_prefab, Vector3.zero, Quaternion.identity) as GameObject;
            g.transform.position = transform.position + delta.normalized * 0.3f;
            g.transform.position = new Vector3(g.transform.position.x, 0.05f, g.transform.position.z);
            g.transform.LookAt(transform.position + delta);

            Projectile p = g.GetComponent<Projectile>();
            p.damage = projectileDamage;

            g.GetComponent<Rigidbody>().AddForce(delta.normalized * shootForce);
            Physics.IgnoreCollision(p.coll, coll);

        }
	
	}

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Enemy"){
            //die


        }
    }
}
