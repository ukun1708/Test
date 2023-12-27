using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour, IContactable
{
    [SerializeField]
    float speed;
    public void Contact(GameObject guy)
    {
        VfxManager.instance.PlayVFX(VfxManager.VfxType.explosion, guy.transform.position);
        
        Destroy(guy);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
