using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaroDeck : MonoBehaviour 
{
    public List<Tarot> avJ = new List<Tarot>();
    public Tarot DavJ;
    public Tarot avIa;
    public Tarot DavIa;
}

public class CreationPersoManager : MonoBehaviour
{
    public TaroDeck taroDeck = new TaroDeck();
    public Archetype archetype;

    // Start is called before the first frame update
    void Start()
    {
        taroDeck = new TaroDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
