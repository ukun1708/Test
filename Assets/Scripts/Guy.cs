using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour, IContactable
{
    public bool active;
    Animator animator;

    [SerializeField]
    Material disabledMat, guyMat;

    public SkinnedMeshRenderer skinnedMeshRenderer;
    private void Start()
    {
        animator = GetComponent<Animator>();

        guyMat = skinnedMeshRenderer.material;
        CheckActive();
    }
    void CheckActive()
    {
        if (active == false)
        {
            animator.enabled = false;
            skinnedMeshRenderer.material = disabledMat;
        }
    }
    public void Run()
    {
        animator.SetBool("Run", true);
    }
    public void Win()
    {
        animator.SetBool("Win", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IContactable idamagable))
        {
            if (active == true)
            {
                idamagable.Contact(gameObject);
            }            
        }
    }

    public void Contact(GameObject guy)
    {
        active = true;
        skinnedMeshRenderer.material = guyMat;
        animator.enabled = true;
        Run();
        transform.parent = guy.transform.parent;
    }
}
