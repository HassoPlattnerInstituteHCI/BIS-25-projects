using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckTrigger : MonoBehaviour
{
    public static event Action<GameObject> OnPuckHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MeHandle"))
        {
            OnPuckHit?.Invoke(this.gameObject);
        }
    }
}
