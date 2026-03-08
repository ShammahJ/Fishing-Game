using UnityEngine;

public class CloudAnimation : MonoBehaviour
{


   Animator anim;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed",-1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
