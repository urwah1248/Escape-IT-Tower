using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCallBack : MonoBehaviour
{
    [SerializeField] Attack Script;
    public void Attack()
    {
        Script.attack();
    }
}
