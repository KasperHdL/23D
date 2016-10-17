using UnityEngine;
using System.Collections;

public class Attack_Charge : MonoBehaviour {
    
    public Transform player;

    public float chargeForce;

    public float stunCooldown;
    public float chargeCooldown;

    public float maxChargeTime;
    public float nextChargeTime;


    public bool isCharging = false;
    public bool isStunned = false;

    private Rigidbody body;
	// Use this for initialization
	void Start () {
        nextChargeTime = Time.time + chargeCooldown;
        body = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(!isCharging && !isStunned && nextChargeTime < Time.time){
            //charging
            StartCoroutine(charge());

        }else if(!isCharging && !isStunned){
            //aiming
            
            Vector3 delta = player.position - transform.position;
            delta.y = 0;
            
            transform.LookAt(transform.position + delta);

        }
	}

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Wall"){
            isStunned = true;
            isCharging = false;
        }
    }


    IEnumerator charge(){
        isCharging = true;

        float startTime = Time.time;
        while(!isStunned){
            if(startTime + maxChargeTime < Time.time){
                isStunned = true;
                break;
            }

            body.AddForce(transform.forward * chargeForce * Time.deltaTime);

            yield return null;
        }
        isCharging = false;

        //stun cooldown
        yield return new WaitForSeconds(stunCooldown);

        isStunned = false;

        nextChargeTime = Time.time + chargeCooldown;
    }
}
