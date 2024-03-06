using UnityEngine;
    public class CheckPointTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var pm = other.GetComponentInParent<PickerManager>();
            pm.speed = 0;
            pm.PushCollectibles();
        }
    }