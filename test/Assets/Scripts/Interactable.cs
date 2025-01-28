using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour
{
    [HideInInspector] public string InteractText;
    public bool IsLastInteracted { get; protected set; }
    protected virtual void Awake()
    {
        IsLastInteracted = false;
    }
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
    public abstract void OnInteract();
}
