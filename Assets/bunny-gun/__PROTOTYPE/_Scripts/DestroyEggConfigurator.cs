using UnityEngine;

public class DestroyEggConfigurator : MonoBehaviour {

    public void SetEggDestroyable () {

        EggController.destroyEgg = !EggController.destroyEgg;
    }
}