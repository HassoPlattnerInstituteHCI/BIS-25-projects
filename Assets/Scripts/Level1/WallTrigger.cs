using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public static event Action<GameObject> OnWallHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MeHandle"))
        {
            OnWallHit?.Invoke(this.gameObject);
        }
    }
}
