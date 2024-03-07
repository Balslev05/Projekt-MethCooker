using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBathCondition : MonoBehaviour
{
   public AcidBath acid;
   public Animator startAcid;
   public void acidBath()
   {
      acid.endAcid = true;
   }
}
