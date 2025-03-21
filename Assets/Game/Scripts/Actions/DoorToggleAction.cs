using UnityEngine;


namespace Game.Action
{
    public class DoorToggle : ActionBase
    {
        [SerializeField] private Door _door;
        public override void PerformAction(GameObject source)
        {
            _door.Toggle();
        }
    }
}