using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlatPref : MonoBehaviour
{
    public int levelPlat;
    public List<Transform> platL1 = new List<Transform>();//lista de plataforma piso 1
    public List<Transform> platL2 = new List<Transform>();//lista de plataforma piso 2
    public List<Transform> platL3 = new List<Transform>();//lista de plataforma piso 2
    public Control_level control_Level;


    // Start is called before the first frame update
    void Start()
    {
        control_Level = transform.parent.GetComponent<Control_level>();
        Invoke("RandPlat", .2f);
    }

    // Update is called once per frame

    void RandPlat()
    {
        control_Level.onPlat = !control_Level;//mudar caloe da variavel
        int rand = Random.Range(0, 4);////sortear do numero 0 a 3
        if (levelPlat == 2)
        {
            if (rand > 0 && control_Level.numPlatWater< control_Level.maxPlatWater && !control_Level.onPlat)
            {
                control_Level.maxPlatWater++;
            }
            else
            {
                rand=0;
            }
        }
        if (levelPlat == 3)
        {
            rand = Random.Range(0, 4);////sortear do numero 0 a 3
        }
        else
        {
            rand = 0;
        }

        switch (rand)//condição do piso 1
        {
            case 0:
                platL1[0].gameObject.SetActive(true);
                platL1[1].gameObject.SetActive(true);
                break;
            case 1:
                platL1[0].gameObject.SetActive(true);
                platL1[1].gameObject.SetActive(false);
                break;
            case 2:
                platL1[0].gameObject.SetActive(false);
                platL1[1].gameObject.SetActive(true);
                break;
            default:
                platL1[0].gameObject.SetActive(false);
                platL1[1].gameObject.SetActive(false);
                break;
        }

        rand = Random.Range(0, 4);////sortear do numero 0 a 3
        switch (rand)//condição do piso 2
        {
            case 0:
                platL2[0].gameObject.SetActive(true);
                platL2[1].gameObject.SetActive(true);
                break;
            case 1:
                platL2[0].gameObject.SetActive(true);
                platL1[1].gameObject.SetActive(false);
                break;
            default:
                platL2[1].gameObject.SetActive(true);
                platL1[0].gameObject.SetActive(false);
                break;
        }

        rand = Random.Range(0, 2);////sortear do numero 0 a 1
        switch (rand)//condição do piso 3
        {
            case 0:
                platL3[0].gameObject.SetActive(true);
                break;
            default:
                platL3[0].gameObject.SetActive(false);
                break;
        }
    }
}
