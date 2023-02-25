using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlePonte : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D ponteRb;

    private bool instanciado;
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        ponteRb = GetComponent<Rigidbody2D>();

        ponteRb.velocity = new Vector2(_GameController.velocidadeObjeto, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (instanciado == false)
        {
            if (transform.position.x <= 0)
            {
                instanciado = true;
                GameObject Temp = Instantiate(_GameController.pontePrefab);
                float posX = transform.position.x + _GameController.tamanhoPonte;
                float posY = transform.position.y;
                Temp.transform.position = new Vector3(posX, posY, 0);
            }
        }
        if (transform.position.x < _GameController.distanciaDestruir)
        {
            Destroy(this.gameObject);
        }       
    }
}
