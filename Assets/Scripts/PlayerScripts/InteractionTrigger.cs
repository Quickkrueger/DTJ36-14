using UnityEngine;
using UnityEngine.Events;

public class InteractionTrigger : MonoBehaviour
{
    IUpgradeable _upgrade;
    public UnityEvent TriggerAction;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IUpgradeable>(out _upgrade))
        {
            TriggerAction.Invoke();
        }
    }

    public bool StartInteraction(int availableCash)
    {
        if (_upgrade != null && _upgrade.GetCost() <= availableCash)
        {
            _upgrade.Upgrade();
            return true;
        }

        return false;
    }
}
