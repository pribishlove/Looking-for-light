using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TakeBonus : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D spotLight;
    public float increasedRadius = 10f;
    public float duration = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bonus"))
        {
            // Увеличиваем радиус освещения
            StartCoroutine(IncreaseLightRadius());

            // Дополнительные действия при подборе объекта, если необходимо
            // Например: Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    private System.Collections.IEnumerator IncreaseLightRadius()
    {
        // Сохраняем текущий радиус
        float originalRadius = spotLight.pointLightOuterRadius;

        // Увеличиваем радиус
        spotLight.pointLightOuterRadius = increasedRadius;

        // Ждем указанное время
        yield return new WaitForSeconds(duration);

        // Возвращаемся к оригинальному радиусу
        spotLight.pointLightOuterRadius = originalRadius;
    }
}
