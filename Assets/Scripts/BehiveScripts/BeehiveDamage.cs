using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BeehiveDamage : MonoBehaviour
{
    public float chancePerTick = 0.1f;
    public float TickPerSecond = 1f;
    private SphereCollider sphereCollider;
    private AllergyBehaviour currentTarget = null;
    private float lastDamageAttempt = 0f;
    private void Awake() {
        sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider == null)
        {
            Debug.LogError("SphereCollider component not found on BeehiveDamage object.");
        }
    }

    private void OnTriggerEnter(Collider other){
        print("Started damaging " + other.name);
        if (other.TryGetComponent<AllergyBehaviour>(out AllergyBehaviour allergyLevel)){
            currentTarget = allergyLevel;
        }
    }

    private void OnTriggerExit(Collider other){
        print("Stopped damaging " + other.name);
        if (other.TryGetComponent<AllergyBehaviour>(out AllergyBehaviour allergyLevel) && currentTarget == allergyLevel)
        {
            currentTarget = null;
        }
    }

    private void Update()
    {
        if (currentTarget != null && Time.time - lastDamageAttempt >= (1f/TickPerSecond))
        {
            if (Random.value < chancePerTick)
            {
                currentTarget.Sting();
            }
            lastDamageAttempt = Time.time;
        }
    }
}
