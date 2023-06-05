using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject AxeHolder;
    public Animator animator;

    [SerializeField] bool PlayBreakingAnimation = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (FindObjectOfType<PlayerBehaviour>().AxePickedup)
            {
                AttackAnimation();
            }
        }
    }

    void AttackAnimation()
    {
        animator.SetTrigger("Hit");
    }

    public void attack()
    {
        Debug.Log("attack");
        if(FindObjectOfType<TriggerCallback>().Glass != null)
        {
            if (PlayBreakingAnimation)
            {
                FindObjectOfType<TriggerCallback>().Glass.GetComponent<MeshDestroyScript>().DestroyMesh();
            }
            else 
            {
                Destroy(FindObjectOfType<TriggerCallback>().Glass.gameObject);
            }
            
        }
    }
}
