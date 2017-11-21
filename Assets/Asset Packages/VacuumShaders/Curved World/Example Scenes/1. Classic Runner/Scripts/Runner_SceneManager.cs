//VacuumShaders 2014
// https://www.facebook.com/VacuumShaders

using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace VacuumShaders
{
    namespace CurvedWorld
    {
        [AddComponentMenu("VacuumShaders/Curved World/Example/Runner/Scene Manager")]
        public class Runner_SceneManager : MonoBehaviour
        {
            //////////////////////////////////////////////////////////////////////////////
            //                                                                          // 
            //Variables                                                                 //                
            //                                                                          //               
            //////////////////////////////////////////////////////////////////////////////
            static public Runner_SceneManager get;

            public float speed = 1;
            public GameObject[] chunks;

            public GameObject[] cars;

            static public float chunkSize = 10000;
            static public Vector3 moveVector = new Vector3(0, 0, -1);
            static public GameObject lastChunk;

            List<Material> listMaterials;

            public List<GameObject> activeChunks;
            int currentChunk;

            GameObject player;
            bool checkingTarget;

            //////////////////////////////////////////////////////////////////////////////
            //                                                                          // 
            //Unity Functions                                                           //                
            //                                                                          //               
            //////////////////////////////////////////////////////////////////////////////
            void Awake()
            { 
                get = this;

                player = GameObject.Find("Player");

                InstantiateChunks();
          

                //Instantiate cars
                for (int i = 0; i < cars.Length; i++)
                {
                    Instantiate(cars[i]);
                }
            } 

            // Use this for initialization
            void Start()
            {
                Renderer[] renderers = FindObjectsOfType(typeof(Renderer)) as Renderer[];

                listMaterials = new List<Material>();
                foreach (Renderer _renderer in renderers)
                {
                    listMaterials.AddRange(_renderer.sharedMaterials);
                }

                listMaterials = listMaterials.Distinct().ToList();
            }

            private void Update()
            {
                if(!checkingTarget)
                {
                    checkingTarget = true;
                    StartCoroutine(CheckTarget());
                }
            }

            //////////////////////////////////////////////////////////////////////////////
            //                                                                          // 
            //Custom Functions                                                          //
            //                                                                          //               
            //////////////////////////////////////////////////////////////////////////////

            IEnumerator CheckTarget()
            {
                if(Vector3.Distance(activeChunks[currentChunk].transform.position, player.transform.position) > 50)
                {
                    currentChunk++;
                    InstantiateChunks();
                }

                yield return new WaitForSeconds(1);
                checkingTarget = false;
            }

            void InstantiateChunks()
            {
                for (int i = 0; i < chunks.Length; i++)
                {
                    GameObject obj = (GameObject)Instantiate(chunks[i]);

                    obj.transform.position = new Vector3(0, -10, i * chunkSize);

                    activeChunks.Add(obj);
                    lastChunk = obj;
                }
            }

            public void DestroyChunk(Runner_Chunk moveElement)
            {
                Vector3 newPos = lastChunk.transform.position;
                newPos.z += chunkSize;


                lastChunk = moveElement.gameObject;
                lastChunk.transform.position = newPos;
            }

            public void DestroyCar(Runner_Car car)
            {
                GameObject.Destroy(car.gameObject);

                Instantiate(cars[Random.Range(0, cars.Length)]);
            }
        }
    }
}