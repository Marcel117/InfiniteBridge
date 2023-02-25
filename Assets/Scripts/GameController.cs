using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private playerController _playerController;

    [Header("Config. Personagem")]
    public float limiteMaxY;
    public float limiteMinY;
    public float limiteMaxX;
    public float limiteMinX;
    public float velocidadeMovimento;

    [Header("Config. Objetos")]
    public float velocidadeObjeto;
    public float distanciaDestruir;
    public float tamanhoPonte;
    public GameObject pontePrefab;

    [Header("Config. Barril")]
    public float posYTop;
    public float posYDown;

    public int orderTop;
    public int orderDown;

    public float tempoSpawn;
    public GameObject barrilPreFab;

    [Header("Globals")]
    public float posXPlayer;
    public int score;
    public Text txtScore;

    [Header("FxSounds")]
    public AudioSource fxSource;
    public AudioClip fxPontos;


    void Start()
    {        
        _playerController = FindObjectOfType(typeof(playerController)) as playerController;

        StartCoroutine("spawnBarril");

        tempoSpawn = Random.Range(0.6f, 2);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        posXPlayer = _playerController.transform.position.x;       
    }
    IEnumerator spawnBarril()
    {
        yield return new WaitForSeconds(tempoSpawn);
        float posY = 0;
        int order = 0;
        int rand = Random.Range(0, 100);
        if(rand < 50)
        {
            posY = posYTop;
            order = orderTop;
        }
        else
        {
            posY = posYDown;
            order = orderDown;
        }
        GameObject temp = Instantiate(barrilPreFab);
        temp.transform.position = new Vector3(temp.transform.position.x, posY, 0);
        temp.GetComponent<SpriteRenderer>().sortingOrder = order;
        tempoSpawn = Random.Range(0.6f, 2);
        StartCoroutine("spawnBarril");
    }
     public void pontuar(int qtdpontos)
     {
        score += qtdpontos;
        txtScore.text = score.ToString();
        fxSource.PlayOneShot(fxPontos);
     }
    public void mudarCena(string cenaDestino)
    {
        SceneManager.LoadScene(cenaDestino);       
    }
}
