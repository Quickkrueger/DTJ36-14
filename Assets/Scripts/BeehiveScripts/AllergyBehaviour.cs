using UnityEngine;

[RequireComponent(typeof(BeeSuit))]
public class AllergyBehaviour : MonoBehaviour
{
    public float epipenEffect = 5;
    private float allergyLevel = 0;
    private float maxAllergyLevel = 100;
    private BeeSuit beeSuit;
    private LoadScene loadScene;

    private void Awake()
    {
        Shader.SetGlobalFloat("_AllergyPercentage", 0f);
        beeSuit = GetComponent<BeeSuit>();

        loadScene = gameObject.GetComponent<LoadScene>();
    }
    public void Sting()
    {
        // Implement the logic for what happens when the bee stings the target

        allergyLevel += 1f / (beeSuit.GetSuitlevel() + 1f);

        UpdateShader();
        if (allergyLevel >= maxAllergyLevel)
        {
            loadScene.LoadGivenScene("GameOverStings");
        }
    }

    public void Epipen()
    {
        // Implement the logic for what happens when the target uses an epipen
        allergyLevel = Mathf.Max(0, allergyLevel - epipenEffect); // Reduce allergy level by 5, but not below 0
        UpdateShader();
    }

    private void UpdateShader()
    {
        Shader.SetGlobalFloat("_AllergyPercentage", allergyLevel / maxAllergyLevel);
    }
}
