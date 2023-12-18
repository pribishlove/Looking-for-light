using UnityEngine;
 // Убедитесь, что импортирован нужный namespace

public class WhiteTrail : MonoBehaviour
{
    SpriteRenderer sR;
    UnityEngine.Rendering.Universal.Light2D spotLight;

    void Start()
    {
        sR = transform.GetComponent<SpriteRenderer>();
        spotLight = transform.GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
        if (spotLight != null)
        {
            // Выключаем Spot Light при старте
            spotLight.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            // Включаем спрайт и Spot Light
            sR.enabled = true;
            if (spotLight != null)
            {
                spotLight.enabled = true;
            }
        }
    }
}
