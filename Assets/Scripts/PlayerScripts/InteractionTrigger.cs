using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Money))]
[RequireComponent (typeof(BeeSuit))]
public class InteractionTrigger : MonoBehaviour
{
    IUpgradeable _upgrade;
    Money _money;
    BeeSuit _beeSuit;
    public UnityEvent<string> TriggerAction;

    private void Start()
    {
        _money = GetComponent<Money>();
        _beeSuit = GetComponent<BeeSuit>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IUpgradeable>(out _upgrade))
        {
            System.Type type = _upgrade.GetType();

            if (type == typeof(PlotUpgrade))
            {
                TriggerAction.Invoke($"'E' to upgrade plot\n${_upgrade.GetCost()}");
            }
            else if (type == typeof(SuitUpgrade))
            {
                TriggerAction.Invoke($"'E' to upgrade suit\n${_upgrade.GetCost()}");
            }
            else if (type == typeof(SuitUpgrade))
            {
                TriggerAction.Invoke($"'E' to upgrade farm\n${_upgrade.GetCost()}");
            }

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
        if (_upgrade == null)
        {
            return;
        }

            System.Type type = _upgrade.GetType();

        if (!callbackContext.performed)
        {
            return;
        }
        if (_upgrade.MaxUpgradeLevel > _upgrade.CurrentUpgradeLevel && _money.RemoveMoney(_upgrade.GetCost()))
        {
            _upgrade.Upgrade();
            if (type == typeof(SuitUpgrade))
            {
                _beeSuit.Upgrade();
            }

            if (_upgrade.MaxUpgradeLevel > _upgrade.CurrentUpgradeLevel)
            {


                if (type == typeof(PlotUpgrade))
                {
                    TriggerAction.Invoke($"'E' to upgrade plot\n(${_upgrade.GetCost()})");
                }
                else if (type == typeof(SuitUpgrade))
                {
                    TriggerAction.Invoke($"'E' to upgrade suit\n(${_upgrade.GetCost()})");
                }
                else if (type == typeof(SuitUpgrade))
                {
                    TriggerAction.Invoke($"'E' to upgrade farm\n(${_upgrade.GetCost()})");
                }
            }
            else
            {
                TriggerAction.Invoke("");
            }
        }

    }
}
