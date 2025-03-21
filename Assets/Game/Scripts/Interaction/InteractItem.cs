using Game.Action;
using System.Collections.Generic;
using UnityEngine;


public class InteractItem : MonoBehaviour
{
    [SerializeField] private List<ActionBase> _primaryAction;
    [SerializeField] private List<ActionBase> _secondaryActions;
    [SerializeField] private List<ActionBase> _specialActions;
    [SerializeField] private List<ActionBase> _reloadActions;


    public void Primary(GameObject source)
    {
        foreach (var action in _primaryAction)
            action.PerformAction(source);
    }
    public void Secondary(GameObject source)
    {
        foreach (var action in _secondaryActions)
            action.PerformAction(source);
    }
    public void Special(GameObject source)
    {
        foreach (var action in _specialActions)
            action.PerformAction(source);
    }
    public void Reload(GameObject source)
    {
        foreach (var action in _reloadActions)
            action.PerformAction(source);
    }
}
