using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    private GameController _GameController;
    public float horizontal;
    public float vertical;
    public float posY;
    public float posX;

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {               
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        playerRb.velocity = new Vector2(_GameController.velocidadeMovimento * horizontal, _GameController.velocidadeMovimento * vertical);
        posX = transform.position.x;
        posY = transform.position.y;

        //Verificar limiteY
        if (transform.position.y > _GameController.limiteMaxY)
        {
            posY = _GameController.limiteMaxY;
        }
        else if (transform.position.y < _GameController.limiteMinY)
        {
            posY = _GameController.limiteMinY;
        }

        //Verificar limiteX
        if (transform.position.x > _GameController.limiteMaxX)
        {
            posX = _GameController.limiteMaxX;
        }
        else if (transform.position.x < _GameController.limiteMinX)
        {
            posX = _GameController.limiteMinX;
        }

        transform.position = new Vector3(posX, posY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _GameController.mudarCena("GameOver");
    }
}
