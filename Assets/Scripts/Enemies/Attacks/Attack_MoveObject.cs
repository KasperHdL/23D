using UnityEngine;
using System.Collections;

public class Attack_MoveObject : MonoBehaviour {

    public Transform obj;

    public Vector3 restPosition;
    public Vector3 attackPosition;


    public float toAttackDuration;
    public float toRestDuration;

    public float cooldown;

    private float lastAttack;

    private bool isAttacking = false;

	void Start () {
        lastAttack = Time.time;
	
	}
	
	void FixedUpdate () {
        if(!isAttacking && lastAttack + cooldown < Time.time){
            StartCoroutine(attack());
        }
	
	}

    IEnumerator attack(){
        isAttacking = true;
        float startTime = Time.time;
        

        float t = 0f;

        while(t < 1f){
            t = (Time.time - startTime) / toAttackDuration;
            obj.localPosition = Vector3.Lerp(restPosition, attackPosition, t);
            yield return null;
        }

        obj.localPosition = attackPosition;
        t = 0f;
        startTime = Time.time;
        while(t < 1f){
            t = (Time.time - startTime) / toRestDuration;
            obj.localPosition = Vector3.Lerp(attackPosition, restPosition, t);
            yield return null;
        }

        obj.localPosition = restPosition;
        lastAttack = Time.time;
        isAttacking = false;

    }
}
