using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {

        public static GameController _instance;

        public static GameController Instance {
            get {
                return _instance;
            }
        }


        public List<Satellite> SatellitesP1 = new List<Satellite>();
        public List<Satellite> SatellitesP2 = new List<Satellite>();

        public int p1Sats;
        public int p2Sats;


        private void Awake() {
            _instance = this;
        }

        // Start is called before the first frame update
        void Start() {
            GameStart();

        }

        // Update is called once per frame
        void Update() {


        }

        public static void KillSat(PlayerId player) {
            if (player == PlayerId.Player1) {
                if (Instance.p1Sats > 0) {
                    Instance.p1Sats--;
                }
            }
            if (player == PlayerId.Player2) {
                if (Instance.p2Sats > 0) {
                    Instance.p2Sats--;
                }
            }
        }

        private void GameStart() {
            //Do game start stuff here

        }

        private void CheckGameEnd() {
            if (p1Sats < 1) {
                if (p2Sats < 1) {
                    GameEnd(PlayerId.None);
                }
                GameEnd(PlayerId.Player1);
            } else if (p2Sats < 1) {
                GameEnd(PlayerId.Player2);
            }
        }
        


        private void GameEnd(PlayerId player) {
            if (player == PlayerId.None) {
                //Caso de empate
                StartCoroutine(DoDraw());
            } else if (player == PlayerId.Player1) {
                //Caso de jugador 1
                StartCoroutine(Player1Wins());
            } else if (player == PlayerId.Player2) {
                //Caso de jugador 2
                StartCoroutine(Player2Wins());
            }


        }

        private IEnumerator DoDraw() {
            //Display draw sign
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("SampleScene");
        }

        private IEnumerator Player1Wins() {
            //Display player 1 sign
            while (!Input.anyKey && !Input.anyKeyDown) {
                yield return null;
            }
            SceneManager.LoadScene("SampleScene");
        }

        private IEnumerator Player2Wins() {
            //Display player 2 sign
            while (!Input.anyKey && !Input.anyKeyDown) {
                yield return null;
            }
            SceneManager.LoadScene("SampleScene");
        }

        
    }

    public enum PlayerId {
        Player1,
        Player2,
        None
    }
}