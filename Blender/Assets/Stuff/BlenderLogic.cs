using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlenderLogic : MonoBehaviour
{
    List<GameObject> FoodInBlender = new List<GameObject>();
    public Image img;
    public Target BlenderButton;
    public AnimationPath BlenderCup;
    bool ButtonActive,IsCupClosed;
    Color mix;
    void Update()
    {
        
        ButtonActive = BlenderButton.hover;
        IsCupClosed = BlenderCup.AnimDirection;
        if(ButtonActive && IsCupClosed && Input.GetKeyDown(KeyCode.Mouse0)){
            mix=Color.black;
            FoodInBlender.ForEach(delegate(GameObject g){
                mix+=g.GetComponent<FoodColor>().c;
            });
            mix/=FoodInBlender.Count;
            mix.a=255;
            img.color=mix;
            FoodInBlender.ForEach(Destroy);
            FoodInBlender.Clear();
        }
    }
    void OnTriggerEnter(Collider collision){
        FoodInBlender.Add(collision.gameObject);
    }
    void OnTriggerExit(Collider collision){
        FoodInBlender.Remove(collision.gameObject);
    }
}
