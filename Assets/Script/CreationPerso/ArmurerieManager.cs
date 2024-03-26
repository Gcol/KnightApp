using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ArmurerieManager : MonoBehaviour
{
    public CreationPersoManager cMM;

    public Arme currentObj;//Todo voir pour les modules

    public void UpdatePerso()
    {
        cMM.UpdatePerso(currentObj);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
