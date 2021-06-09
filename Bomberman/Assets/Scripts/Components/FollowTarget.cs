using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            particleSystem.Play();
            animator.SetFloat("SpeedModifier", 1f);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            particleSystem.Stop();
            animator.SetFloat("SpeedModifier", 0f);
        }

    }
}
