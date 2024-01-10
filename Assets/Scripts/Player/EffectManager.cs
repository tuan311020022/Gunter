using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType {
    Shoot, 
    Dead, 
    Rescue, 
    Hit,
    HitRed,
    HitYellow,
    Break,
    Blood,
    BossLaser,
    BodyHit,
    Grenade,
}

public class EffectManager : MonoBehaviour
{
    // an mau, ban, dan va cham,
    public GameObject Shoot_FX;
    public GameObject Dead_FX;
    public GameObject Rescue_FX;

    public GameObject Hit_FX;
    public GameObject HitRed_FX;
    public GameObject HitYellow_FX;
    public GameObject Break_FX;

    public GameObject Blood_FX;
    public GameObject BossLaser_FX;
    public GameObject Grenade_FX;

    private Dictionary<EffectType, GameObject> dictionary;
   private void Awake() {
        dictionary =  new Dictionary<EffectType, GameObject>
        {
            {EffectType.Shoot, Shoot_FX},
            {EffectType.Dead, Dead_FX},
            {EffectType.Rescue, Rescue_FX},
            {EffectType.Hit, Hit_FX},
            {EffectType.HitRed, HitRed_FX},

            {EffectType.HitYellow, HitYellow_FX},
            {EffectType.Break, Break_FX},
            {EffectType.Blood, Blood_FX},
            {EffectType.BossLaser, BossLaser_FX},
            {EffectType.Grenade, Grenade_FX},
        };
   }

    public void PlayEffect(EffectType effect, Transform posTrans){
        GameObject obj =  Instantiate(dictionary[effect], posTrans.position, Quaternion.identity);
        StartCoroutine(EffectCoroutine(obj));
    }

    IEnumerator EffectCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(obj);
    }
}
