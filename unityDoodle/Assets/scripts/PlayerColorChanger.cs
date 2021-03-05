using System.Collections;
using System.Collections.Generic;
using UnityEngine;
             

 [CreateAssetMenu(fileName="New Color",menuName="Color")]            
public class PlayerColorChanger : ScriptableObject
{

   [SerializeField] private new string  name = "Color Name";
   [SerializeField] private Color col = new Color(0f,0f,0f,1f);

      public Color Col=>col;


}
