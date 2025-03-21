using Game.Action;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private List<ActionBase> _actions;
    public void OnInteract(GameObject source)
    {
        foreach (var action in _actions)
        {
            action.PerformAction(source);
        }
    }
}
