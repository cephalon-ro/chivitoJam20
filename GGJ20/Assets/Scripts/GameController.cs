using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {

        public static GameController _instance;

        static bool gameInProgress = true;

        public static bool GameIsInProgress {
            get {
                return gameInProgress;
            }
        }

        public static GameController Instance {
            get {
                return _instance;
            }
        }


        public List<Satellite> SatellitesP1 = new List<Satellite>();
        public List<Satellite> SatellitesP2 = new List<Satellite>();

        public int p1Sats = 4;
        public int p2Sats = 4;

        public GameObject DrawCanvasObj;
        public GameObject P1WinCanvasObj;
        public GameObject P2WinCanvasObj;

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
                    Instance.CheckGameEnd();
                }
            }
            if (player == PlayerId.Player2) {
                if (Instance.p2Sats > 0) {
                    Instance.p2Sats--;
                    Instance.CheckGameEnd();
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
                GameEnd(PlayerId.Player2);
            } else if (p2Sats < 1) {
                GameEnd(PlayerId.Player1);
            }
        }
        


        private void GameEnd(PlayerId player) {
            if (player == PlayerId.None) {
                //Caso de empate
                gameInProgress = false;
                StartCoroutine(DoDraw());
            } else if (player == PlayerId.Player1) {
                //Caso de jugador 1
                gameInProgress = false;
                StartCoroutine(Player1Wins());
            } else if (player == PlayerId.Player2) {
                //Caso de jugador 2
                gameInProgress = false;
                StartCoroutine(Player2Wins());
            }


        }

        private IEnumerator DoDraw() {
            //Display draw sign
            DrawCanvasObj.SetActive(true);
            Debug.Log("Draw");
            yield return new WaitForSeconds(5f);
            gameInProgress = true;
            SceneManager.LoadScene("SampleScene");
        }

        private IEnumerator Player1Wins() {
            //Display player 1 sign
            P1WinCanvasObj.SetActive(true);
            Debug.Log("Player 1 wins");
            while (!Input.anyKey && !Input.anyKeyDown) {
                yield return null;
            }
            gameInProgress = true;
            SceneManager.LoadScene("SampleScene");
        }

        private IEnumerator Player2Wins() {
            //Display player 2 sign
            P2WinCanvasObj.SetActive(true);
            Debug.Log("Player 2 wins");
            while (!Input.anyKey && !Input.anyKeyDown) {
                yield return null;
            }
            gameInProgress = true;
            SceneManager.LoadScene("SampleScene");
        }

        
    }

    public enum PlayerId {
        Player1,
        Player2,
        None
    }
}