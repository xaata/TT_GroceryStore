using UnityEngine;

namespace Game.Action
{
    public abstract class ActionBase : MonoBehaviour
    {
        public abstract void PerformAction(GameObject source);
    }
}
