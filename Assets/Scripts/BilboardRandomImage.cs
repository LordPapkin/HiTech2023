using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardRandomImage : MonoBehaviour
{

    public List<Texture2D> images;
    private Material material;

    void Start()
    {
        material = gameObject.GetComponent<Renderer>().materials[1];
        Texture2D[] arr = images.ToArray();
        material.SetTexture("_Picture", arr[Random.Range(0, arr.Length)]);
    }
}
