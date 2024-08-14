using System;
using UnityEngine;

public class NPCSensor : MonoBehaviour
{
    public event Action<GameObject> OnPlayerEnterSensor = (_player) => {};
    public event Action OnPlayerExitSensor = () => { };

    private void OnTriggerEnter(Collider collision)
    {
        var target = collision.gameObject.GetComponent<PlayerMovement>();

        if (target != null)  // found a player to follow
        {
            OnPlayerEnterSensor(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        var target = collision.gameObject.GetComponent<PlayerMovement>();

        if (target != null)  // player has left the sensor
        {
            OnPlayerExitSensor();
        }
    }
}
