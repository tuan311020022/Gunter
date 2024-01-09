using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType {
    Shoot, 
    Dead, 
    Rescue, 
    EnemyDead,
    Break,
}

public class EffectManager : MonoBehaviour
{
    // an mau, ban, dan va cham,
    public GameObject Shoot_FX;
    public GameObject Dead_FX;
    public GameObject Rescue_FX;

    public GameObject EnemyDead_FX;
    public GameObject Break_FX;

    private Dictionary<EffectType, GameObject> dictionary;
   private void Awake() {
        dictionary =  new Dictionary<EffectType, GameObject>
        {
            {EffectType.Shoot, Shoot_FX},
            {EffectType.Dead, Dead_FX},
            {EffectType.Rescue, Rescue_FX},
            {EffectType.EnemyDead, EnemyDead_FX},
            {EffectType.Break, Break_FX}
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
