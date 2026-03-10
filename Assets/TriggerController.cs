using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
   public string StatusModificado = "Speed";

   public int ValorModificado = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            if(StatusModificado == "Speed")
            {
                collision.GetComponent<PlayerController>().Speed += ValorModificado;
            }
            else if (StatusModificado == "Health")
            {
                collision.GetComponent <PlayerController>().Health += ValorModificado;
            }
            Destroy(gameObject);
        }
        
    }
}
