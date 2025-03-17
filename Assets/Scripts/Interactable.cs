using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType { Enemy, Item }

public class Interactable : MonoBehaviour
{
    public Actor MyActor { get; private set; }

    public InteractableType interactionType;

    void Awake()
    {
        if (interactionType == InteractableType.Enemy)
        { 
            MyActor = GetComponent<Actor>(); 
        }
    }

    public void InteractWithItem()
    {
        // Pickup Item
        Destroy(gameObject);
    }
}