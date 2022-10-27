using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Color[] TaskColors;
    public Image DesiredColor,JuiceColor,Check,Cross;
    float NextLevelTime=3,CountDown=0;
    bool LevelTransition=false;
    int level=0;
    void Start()
    {
        DesiredColor.color=TaskColors[level];
        Check.enabled=false;
        Cross.enabled=true;
    }
    void Update()
    {
        if((Mathf.Abs(DesiredColor.color.r - JuiceColor.color.r) <= 0.15f) 
        && (Mathf.Abs(DesiredColor.color.g - JuiceColor.color.g) <= 0.15f)
        && (Mathf.Abs(DesiredColor.color.b - JuiceColor.color.b) <= 0.15f)
        && !LevelTransition)
        {
            CountDown=Time.time;
            Check.enabled=true;
            Cross.enabled=false;
            LevelTransition=true;
            level++;
        }
        if(LevelTransition && (CountDown + NextLevelTime <= Time.time)){
            if(TaskColors.Length<=level) level=0;
            DesiredColor.color=TaskColors[level];
            Check.enabled=false;
            Cross.enabled=true;
            LevelTransition=false;
        }
    }
}
