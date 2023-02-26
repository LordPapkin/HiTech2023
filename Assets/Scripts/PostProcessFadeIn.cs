using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessFadeIn : MonoBehaviour
{
    public AnimationClip anim;
    void Start()
    {
        anim.wrapMode = WrapMode.Once;
        
    }
}
