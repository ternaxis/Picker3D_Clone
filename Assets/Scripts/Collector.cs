using System;
using TMPro;
using UnityEngine;

    public class Collector : MonoBehaviour
    {
        public int designatedCollectibleCount;
        public TMP_Text collectibleCountText;
        
        private int currentCollectibleCount;

        private void Awake()
        {
            collectibleCountText.text = "0/" + designatedCollectibleCount;
        }

        private void OnTriggerEnter(Collider other)
        {
            currentCollectibleCount++;
            collectibleCountText.text = currentCollectibleCount + "/" + designatedCollectibleCount;
            if (currentCollectibleCount == designatedCollectibleCount)
            {
                GameManager.instance.GameWin();
            }
        }
    }
