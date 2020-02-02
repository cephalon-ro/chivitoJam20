using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts
{
    public class Satellite : MonoBehaviour
    {
        public PlayerId player;
        public string codename;
        public Slider hpSlider;
        public TextMesh satText;
        public float hp;
        public float maxHp;
        MeshRenderer rend;
        RectTransform rt;
        AudioSource aSource;
        bool dead = false;

         void Start() {
            aSource = GetComponent<AudioSource>();
            satText.gameObject.SetActive(false);
            satText.transform.position = new Vector3(transform.position.x, (transform.position.y + 8), transform.position.z);
            rt = hpSlider.GetComponent<RectTransform>();
            rt.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            hpSlider.transform.position = new Vector3(transform.position.x, (transform.position.y + 5), transform.position.z);
            hp = maxHp;
            hpSlider.maxValue = maxHp;
            hpSlider.value = hp;
            satText.text = codename;
            rend = GetComponent<MeshRenderer>();
        }

        void Update() {
            if (GameController.GameIsInProgress) {
                hp -= 1 * Time.deltaTime;
                hpSlider.value = hp;

                if (hp <= 0 && !dead) {
                    dead = true;
                    hpSlider.gameObject.SetActive(false);
                    GameController.KillSat(player);
                    StartCoroutine(KillSatEffect());
                }
            }
        }

        private IEnumerator KillSatEffect() {
            Vector3 oldScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            float scaleMult = 1.5f;
            Vector3 newScale = new Vector3(oldScale.x * scaleMult, oldScale.y * scaleMult, oldScale.z * scaleMult);
            transform.localScale = newScale;
            aSource.PlayOneShot(Resources.Load<AudioClip>("Sats/Sat-Explotion"));
            Color oldColor = rend.material.color;
            //rend.material.color = rend.material.color + new Color(0.7f, 0.2f, 0.2f);
            yield return null;
            yield return null;
            yield return null;
            rend.material.color = oldColor * 0.3f;
            yield return null;
            transform.localScale = oldScale;
        }
    }
  
    

}