using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll_Cen : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pla1;// plataforma de referencia para posição da instancia de plataforma
    public Transform platPref;// prefaf plataforma
    public List<Transform> platListN1 = new List<Transform>();// lista que ira receber as plataformas instanciadas do level 1
    public List<Transform> platListN2 = new List<Transform>();// lista que ira receber as plataformas instanciadas do level 2
    public List<Transform> platListN3 = new List<Transform>();// lista que ira receber as plataformas instanciadas do level 3
    Transform platTemp; // variavel temporaria para guarda inctacia da plataforma instaciada
    public Transform platInter;// intervalo de plataforma por level
    public int numberPlat;//quantidades de plataformas que serão instaciadas no primeiro level
    void Start()
    {
        StartCoroutine(GeneratePlatformTemp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GeneratePlatformTemp()
    {
        platTemp = Instantiate(platPref, new Vector3(pla1.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity); // intanciar plataformas
        for (int i = 0; i < 3; i++) // laço do level
        {
            platTemp.SetParent(transform);// colococando a plataforma instanciadas como filho desde objeto que contem o scripty

            for (int j = 0; j < numberPlat; j++)//laço das plataformas pro level
            {
                yield return new WaitForSeconds(.1f);
                if (i == 0)
                {
                    Transform clone = Instantiate(platPref, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);// intanciar novas  plataformas
                    platListN1.Add(clone);// add as plataformas level 1, na lista 
                    platTemp = clone;

                }
                else if (i == 1)
                {
                    Transform clone = Instantiate(platPref, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);// intanciar novas  plataformas
                    platListN2.Add(clone);// add as plataformas level 1, na lista 
                    platTemp = clone;

                }
                else
                {
                    Transform clone = Instantiate(platPref, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);// intanciar novas  plataformas
                    platListN3.Add(clone);// add as plataformas level 1, na lista 
                    platTemp = clone;

                }
                platTemp.SetParent(transform);// colococando a plataforma instanciadas como filho desde objeto que contem o scripty
                yield return new WaitForSeconds(.1f);
            }
            if (i == 0)
            {
                platTemp = Instantiate(platInter, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);// intanciar intervalo 1
                platListN1.Add(platTemp); // add as plataforma intervalo da plataforma do level 1, na lista 

            }
            else if (i == 1)
            {
                platTemp = Instantiate(platInter, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);//  intanciar intervalo 2
                platListN2.Add(platTemp); // add as plataforma intervalo da plataforma do level 1, na lista 
            }
            else
            {
                platTemp = Instantiate(platInter, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);//  intanciar intervalo 3
                platListN3.Add(platTemp); // add as plataforma intervalo da plataforma do level 1, na lista 
            }
            platTemp.SetParent(transform);// colococando a plataforma instanciadas como filho desde objeto que contem o scripty
            numberPlat = numberPlat * 2;// duplicar o numero de plataforma no proximo level
        }
    }
}
