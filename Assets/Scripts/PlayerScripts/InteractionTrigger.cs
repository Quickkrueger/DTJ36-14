using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Money))]
[RequireComponent (typeof(BeeSuit))]
[RequireComponent(typeof(AllergyBehaviour))]
public class InteractionTrigger : MonoBehaviour
{
    IUpgradeable _upgrade;
    Money _money;
    BeeSuit _beeSuit;
    AllergyBehaviour _allergyBehaviour;
    public UnityEvent<string> TriggerAction;

    private void Start()
    {
        _money = GetComponent<Money>();
        _beeSuit = GetComponent<BeeSuit>();
        _allergyBehaviour = GetComponent<AllergyBehaviour>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!CheckForUpgradable(other))
        {
            CheckForHoney(other);
        }

    }

    private void CheckForHoney(Collider other)
    {
        if(other.gameObject.TryGetComponent<HoneyBuildup>(out HoneyBuildup honey))
        {
            _money.AddMoney(honey.honeyValue * (float)honey.honeyLevel);
            honey.honeyLevel = 0;
        }
    }

    private bool CheckForUpgradable(Collider other)
    {
        IUpgradeable upgradeable = _upgrade;
        if (other.gameObject.TryGetComponent<IUpgradeable>(out _upgrade) && _upgrade.MaxUpgradeLevel > _upgrade.CurrentUpgradeLevel)
        {
            System.Type type = _upgrade.GetType();

            if (type == typeof(PlotUpgrade))
            {
                TriggerAction.Invoke($"'E' to upgrade plot\n(${_upgrade.GetCost()})");
            }
            else if (type == typeof(SuitUpgrade))
            {
                TriggerAction.Invoke($"'E' to upgrade suit\n(${_upgrade.GetCost()})");
            }
            else if (type == typeof(FarmUpgrade))
            {
                TriggerAction.Invoke($"'E' to buy more plots\n(${_upgrade.GetCost()})");
            }
            else if (type == typeof(Medipack))
            {
                TriggerAction.Invoke($"'E' to use Epipen\n(${_upgrade.GetCost()})");
            }

            return true;

        }

        _upgrade = upgradeable;
        return false;
    }



    private void OnTriggerExit(Collider other)
    {
        IUpgradeable upgrade;
        if ((other.TryGetComponent<IUpgradeable>(out upgrade) && upgrade == _upgrade) || _upgrade == null)
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
            else if (type == typeof(Medipack))
            {
                _allergyBehaviour.Epipen();
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
                else if (type == typeof(FarmUpgrade))
                {
                    TriggerAction.Invoke($"'E' to buy more plots\n(${_upgrade.GetCost()})");
                }
                else if (type == typeof(Medipack))
                {
                    TriggerAction.Invoke($"'E' to use Epipen\n(${_upgrade.GetCost()})");
                }
            }
            else
            {
                TriggerAction.Invoke("");
            }
        }

    }
}
