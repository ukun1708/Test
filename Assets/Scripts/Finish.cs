using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour, IContactable
{
    public void Contact(GameObject gameObject)
    {
        GameManager.instance.Win();
    }
}
