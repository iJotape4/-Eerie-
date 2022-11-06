using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public void Interact();
}

public interface IPickable: IInteractable
{
    public void Pick();
}

public interface IDeactivableInteraction : IInteractable
{
    public void DeactivateInteraction();
}

public interface IReactivableInteraction : IDeactivableInteraction
{
    public void ReactivateInteraction();
}

