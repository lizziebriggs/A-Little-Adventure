using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private List<MouseBehaviour> mice = new List<MouseBehaviour>();

    public void ChangeTarget(Transform newTarget)
    {
        foreach (MouseBehaviour mouse in mice)
        {
            mouse.playerToAttack = newTarget;
        }
    }
}
