using UnityEngine;

public class Target : MonoBehaviour
{
    private GameObject l;
    public bool hover=false;
    void Start()
    {
        l = transform.GetChild(0).gameObject;
    }

    private void OnMouseEnter()
    {
	    l.gameObject.SetActive(true);
        hover=true;
    }

    private void OnMouseExit()
    {
	    l.gameObject.SetActive(false);
        hover=false;
    }
}