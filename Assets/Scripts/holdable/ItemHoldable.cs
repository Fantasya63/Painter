using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoldable : MonoBehaviour, IHoldable
{
    void Update()
    {
        if (Input.GetButtonDown("Drop"))
        {
            Destroy(gameObject);
        }
    }

    public void Drop()
    {
        throw new System.NotImplementedException();
    }

    public void Hold(Transform holderPosition)
    {
        transform.parent = holderPosition;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Use()
    {
        throw new System.NotImplementedException();
    }
}
