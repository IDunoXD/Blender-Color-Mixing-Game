using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationPath : MonoBehaviour
{
    public Transform[] locations;
    Vector3[] positionsF,positionsB;
    public bool AnimDirection=true;
    bool hover=false;
    void Start(){
        positionsF = new Vector3[locations.Length];
        for(int i=0;i<locations.Length;i++){
            positionsF[i] = locations[i].position;
        }
        positionsB = new Vector3[locations.Length];
        for(int i=0;i<locations.Length;i++){
            positionsB[i] = locations[locations.Length-i-1].position;
        }
    }
    void Update(){
        if(hover && Input.GetKeyDown(KeyCode.Mouse0) && AnimDirection){
            transform.DOPath(positionsF, 2, PathType.CatmullRom, PathMode.Full3D, 10, Color.green);
            transform.DORotate(locations[locations.Length-1].eulerAngles,2,RotateMode.Fast);
            AnimDirection = false;
        }else if(hover && Input.GetKeyDown(KeyCode.Mouse0) && !AnimDirection){
            transform.DOPath(positionsB, 2, PathType.CatmullRom, PathMode.Full3D, 10, Color.green);
            transform.DORotate(locations[0].eulerAngles,2,RotateMode.Fast);
            AnimDirection = true;
        }
    }
    void OnMouseEnter(){hover=true;}
    void OnMouseExit(){hover=false;}
}