using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;

    private void OnEnable()
    {
        GameManager.OnPowerUp += PowerUp;
    }

    private void OnDisable()
    {
        GameManager.OnPowerUp -= PowerUp;
    }

    private void PowerUp(Color c)
    {
        GetComponent<Renderer>().material.color = c;
    }
    private void OnTriggerEnter(Collider col)
        {
            
            if(col.CompareTag("Player"))
            {
                switch (type)
                {
                    case CollectableType.Key:
                    {
                        GameManager.instance.OnKeyCollected();
                        break;
                    }
                    case CollectableType.collectable:
                    {
                        GameManager.instance.OnCollect();
                        break;
                    }
                    case CollectableType.Powerup:
                    {
                        GameManager.instance.OnPowerCollected();
                        break;
                    }
                }

                Destroy(gameObject);

                }
            }
}

public enum CollectableType
{
    collectable,
    Key,
    Powerup
}
