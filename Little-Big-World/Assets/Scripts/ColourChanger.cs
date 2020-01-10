using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColourChanger : MonoBehaviour
{
    [SerializeField] private Color colour = Color.white;

    void Start()
    {
        GetComponent<Renderer>().material.color = colour;
    }
}
