using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Money))]
public class InteractionTrigger : MonoBehaviour
{
    IUpgradeable _upgrade;
    Money _money;
    public UnityEvent<string> TriggerAction;

    private void Start()
    {
        _money = GetComponent<Money>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IUpgradeable>(out _upgrade))
        {
            TriggerAction.Invoke($"'E' to upgrade plot\n${_upgrade.GetCost()}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IUpgradeable upgrade;
        if (other.TryGetComponent<IUpgradeable>(out upgrade) && upgrade == _upgrade)
        {
            TriggerAction.Invoke("");
            upgrade = null;
        }
    }

    public void StartInteraction(CallbackContext callbackContext)
    {
        if (!callbackContext.performed)
        {
            return;
        }
        if (_upgrade != null && _upgrade.MaxUpgradeLevel > _upgrade.CurrentUpgradeLevel && _money.RemoveMoney(_upgrade.GetCost()))
        {
            _upgrade.Upgrade();
            if (_upgrade.MaxUpgradeLevel > _upgrade.CurrentUpgradeLevel)
            {
                TriggerAction.Invoke($"'E' to upgrade plot\n${_upgrade.GetCost()}");
            }
            else
            {
                TriggerAction.Invoke("");
            }
        }

    }
}
