using UnityEngine;

[RequireComponent(typeof(BeeSuit))]
public class AllergyBehaviour : MonoBehaviour
{
    public float epipenEffect = 5;
    private float allergyLevel = 0;
    private float maxAllergyLevel = 100;
    private BeeSuit beeSuit;

    private void Awake()
    {
        Shader.SetGlobalFloat("_AllergyPercentage", 0f);
        beeSuit = GetComponent<BeeSuit>();
    }
    public void Sting()
    {
        // Implement the logic for what happens when the bee stings the target
        Debug.Log($"{gameObject.name} has been stung!");

        allergyLevel += 1f/(beeSuit.GetSuitlevel() + 1f);

        UpdateShader();
    }

    public void Epipen()
    {
        // Implement the logic for what happens when the target uses an epipen
        Debug.Log($"{gameObject.name} has used an epipen!");
        allergyLevel = Mathf.Max(0, allergyLevel - epipenEffect); // Reduce allergy level by 5, but not below 0
        UpdateShader();
    }

    private void UpdateShader()
    {
        Shader.SetGlobalFloat("_AllergyPercentage", allergyLevel / maxAllergyLevel);
    }
}
