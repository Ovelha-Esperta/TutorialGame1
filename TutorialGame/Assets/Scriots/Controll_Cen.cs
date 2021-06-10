using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll_Cen : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pla1;// plataforma de referencia para posição da instancia de plataforma
    public Transform platPref;// prefaf plataforma
    Transform platTemp; // variavel temporaria para guarda inctacia da plataforma instaciada
    public Transform platInter;// intervalo de plataforma por level
    public int numberPlat;//quantidades de plataformas que serão instaciadas no primeiro level
    Control_G control_G;//contrle geral do jogo
    void Start()
    {
        control_G = Camera.main.GetComponent<Control_G>();
        control_G.controll_Cen = GetComponent<Controll_Cen>();
        StartCoroutine(GeneratePlatformTemp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GeneratePlatformTemp()
    {
        platTemp = Instantiate(platPref, new Vector3(pla1.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity); // intanciar plataformas
        platTemp.SetParent(control_G.control_levelList[0].transform);// colococando a plataforma instanciadas como filho desde objeto que contem o scripty
        platTemp.GetComponent<ControlPlatPref>().levelPlat = 1;
        for (int i = 0; i < 3; i++) // laço do level
        {
            for (int j = 0; j < numberPlat; j++)//laço das plataformas pro level
            {
                yield return new WaitForSeconds(.1f);
                if (i == 0)
                {
                    Transform clone = Instantiate(platPref, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);// intanciar novas  plataformas
                    control_G.control_levelList[0].platlevelList.Add(clone);// add as plataformas level 1, na lista 
                    platTemp = clone;
                    clone.GetComponent<ControlPlatPref>().levelPlat = 1;
                    platTemp.SetParent(control_G.control_levelList[0].transform);// colococando a plataforma instanciadas como filho desde objeto que contem o scripty

                }
                else if (i == 1)
                {
                    Transform clone = Instantiate(platPref, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);// intanciar novas  plataformas
                    control_G.control_levelList[1].platlevelList.Add(clone);// add as plataformas level 2, na lista 
                    platTemp = clone;
                    clone.GetComponent<ControlPlatPref>().levelPlat = 2;
                    platTemp.SetParent(control_G.control_levelList[1].transform);// colococando a plataforma instanciadas como filho desde objeto que contem o scripty

                }
                else
                {
                    Transform clone = Instantiate(platPref, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);// intanciar novas  plataformas
                    control_G.control_levelList[2].platlevelList.Add(clone);// add as plataformas level 3, na lista 
                    platTemp = clone;
                    clone.GetComponent<ControlPlatPref>().levelPlat = 3;
                    platTemp.SetParent(control_G.control_levelList[2].transform);// colococando a plataforma instanciadas como filho desde objeto que contem o scripty

                }
                yield return new WaitForSeconds(.1f);
            }
            if (i == 0)
            {
                platTemp = Instantiate(platInter, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);// intanciar intervalo 1
                control_G.control_levelList[0].platlevelList.Add(platTemp);// add as plataforma intervalo da plataforma do level 0, na lista 
                platTemp.SetParent(control_G.control_levelList[0].transform);// colococando a plataforma de intervalo instanciadas como filho desde objeto que contem o scripty
               // platTemp.GetComponent<ControlPlatPref>().levelPlat = 1;


            }
            else if (i == 1)
            {
                platTemp = Instantiate(platInter, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);//  intanciar intervalo 2
                control_G.control_levelList[1].platlevelList.Add(platTemp);// add as plataforma intervalo da plataforma do level 1, na lista 
                platTemp.SetParent(control_G.control_levelList[1].transform);// colococando a plataforma de intervalo instanciadas como filho desde objeto que contem o scripty
              //  platTemp.GetComponent<ControlPlatPref>().levelPlat = 2;
            }
            else
            {
                platTemp = Instantiate(platInter, new Vector3(platTemp.transform.position.x + pla1.position.x, pla1.position.y, pla1.position.z), Quaternion.identity);//  intanciar intervalo 3
                control_G.control_levelList[2].platlevelList.Add(platTemp);// add as plataforma intervalo da plataforma do level 2WWWWWWWWWWW, na lista 
                platTemp.SetParent(control_G.control_levelList[2].transform);// colococando a plataforma de intervalo instanciadas como filho desde objeto que contem o scripty
               // platTemp.GetComponent<ControlPlatPref>().levelPlat = 3;
            }
           // platTemp.SetParent(transform);// colococando a plataforma instanciadas como filho desde objeto que contem o scripty
            numberPlat = numberPlat * 2;// duplicar o numero de plataforma no proximo level
        }
    }
}
