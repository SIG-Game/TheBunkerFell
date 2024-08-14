using System;
using UnityEngine;

public class NPCSensor : MonoBehaviour
{
    public event EventHandler<GameObject> OnPlayerEnterSensor;
    public event EventHandler OnPlayerExitSensor;

    private void OnTriggerEnter(Collider collision)
    {
        var target = collision.gameObject.GetComponent<PlayerMovement>();

        if (target != null)  // found a player to follow
        {
            OnPlayerEnterSensor?.Invoke(this, collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        var target = collision.gameObject.GetComponent<PlayerMovement>();

        if (target != null)  // player has left the sensor
        {
            OnPlayerExitSensor?.Invoke(this, null);
        }
    }
}
