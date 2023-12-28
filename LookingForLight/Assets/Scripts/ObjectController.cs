using UnityEngine;


public class ObjectController : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D[] lights;

    private void Start()
    {
        lights = GetComponentsInChildren<UnityEngine.Rendering.Universal.Light2D>();
    }

    private void OnEnable()
    {
        BonusManager.OnBonusCollected += OnBonusCollected;
    }

    private void OnDisable()
    {
        BonusManager.OnBonusCollected -= OnBonusCollected;
    }

    public void OnBonusCollected()
    {
        GameManager.Instance.remainingTime = GameManager.Instance.duration; // Сброс таймера
        IncreaseLightRadius();
    }

    private void IncreaseLightRadius()
    {
        foreach (UnityEngine.Rendering.Universal.Light2D spotLight in lights)
        {
            if (spotLight != null)
            {
                float originalRadius = spotLight.pointLightOuterRadius;
                spotLight.pointLightOuterRadius = originalRadius + GameManager.Instance.increasedRadius;
                StartCoroutine(ResetLightRadius(spotLight, originalRadius));
            }
        }
    }

    private System.Collections.IEnumerator ResetLightRadius(UnityEngine.Rendering.Universal.Light2D spotLight, float originalRadius)
    {
        yield return new WaitForSeconds(GameManager.Instance.duration);
        spotLight.pointLightOuterRadius = originalRadius;
    }
}
