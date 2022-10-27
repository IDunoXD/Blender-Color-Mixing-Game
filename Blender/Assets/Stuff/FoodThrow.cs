using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodThrow : MonoBehaviour
{
    public GameObject summon;
    public Vector3 Force;
    MeshRenderer mesh;
    MeshCollider coll;
    bool hover=false;
    float wait=2,TriggerTime=0;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        coll = GetComponent<MeshCollider>();
    }
    void Update(){
        if(TriggerTime + wait <= Time.time){
            mesh.enabled=true;
            coll.enabled=true;
        }
        if(hover && Input.GetKeyDown(KeyCode.Mouse0) && (TriggerTime + wait <= Time.time)){
            TriggerTime = Time.time;
            mesh.enabled=false;
            coll.enabled=false;
            var food = Instantiate(summon,transform.position + Vector3.up*0.1f,transform.rotation);
            food.GetComponent<Rigidbody>().AddForce(Force);
        }
    }
    void OnMouseEnter(){hover=true;}
    void OnMouseExit(){hover=false;}
}
