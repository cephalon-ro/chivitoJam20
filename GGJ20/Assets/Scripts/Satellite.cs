using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts
{
    public class Satellite : MonoBehaviour
    {
        public string codename;
        public Slider hpSlider;
        public TextMesh satText;
        public float hp;
        public float maxHp;
        RectTransform rt;
        
         void Start()
        {
            satText.gameObject.SetActive(false);
            satText.transform.position = new Vector3(transform.position.x, (transform.position.y + 8), transform.position.z);
            rt = hpSlider.GetComponent<RectTransform>();
            rt.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            hpSlider.transform.position = new Vector3(transform.position.x, (transform.position.y + 5), transform.position.z);
            hp = maxHp;
            hpSlider.maxValue = maxHp;
            hpSlider.value = hp;
            satText.text = codename;
        }
        void Update()
        {
           hp -= 1 * Time.deltaTime;
           hpSlider.value = hp;

            if (hp <= 0)
            {
                hpSlider.gameObject.SetActive(false);
            }
        }
    }
  
    

}