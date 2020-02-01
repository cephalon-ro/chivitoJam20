using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts
{
    public class Satellite : MonoBehaviour
    {
        public string codename;
        public Slider hpSlider;
        public Text satText;
        public float hp;
        public float maxHp;

         void Start()
        {
            hp = maxHp;
            hpSlider.maxValue = maxHp;
            hpSlider.value = hp;
            satText.fontSize = 20;
            satText.text = codename;
        }
        void Update()
        {
           hp -= 1 * Time.deltaTime;
           hpSlider.value = hp;
        }
    }
  
    

}