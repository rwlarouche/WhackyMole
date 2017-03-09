using UnityEngine;
using System.Collections;

public class SqueakSound : MonoBehaviour
{

    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        gameObject.AddComponent<AudioSource>(); //Create AudioSource
        source.clip = sound; //Set which sound clip will be played
        source.playOnAwake = false; //AudioSource will not play sound when it is created
    }

    void Update()
    {
        CheckHit(); //Check if a mole was hit
    }

    public void CheckHit()
    {
        if (Input.GetMouseButtonDown(0)) //If mouse is clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if ((hit) && (hit.transform.tag == "mole") ) //If mouse is clicked on a mole
            {
                source.PlayOneShot(sound); //Play sound once
            }
        }
    }
}
