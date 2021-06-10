using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_level : MonoBehaviour
{
    
    public int numPlatWater;//numero de platafroma desde nivel com agua
    public int maxPlatWater;//numero limite de plataforma com agua
    public bool onPlat;//alternar plataformas com agua
    public List<Transform> platlevelList = new List<Transform>();// lista que ira receber as plataformas instanciadas do level 1
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
