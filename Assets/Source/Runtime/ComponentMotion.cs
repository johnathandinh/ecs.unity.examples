//  Project : ecs.examples
// Contacts : Pix - info@pixeye.games
//     Date : 3/7/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
   [System.Serializable]
   public class ComponentMotion : IComponent
   {
       public float speed;
       public float direction = 1;
       public void Copy(int entityID)
       {
           var component = Storage<ComponentMotion>.Instance.GetFromStorage(entityID);
       }
       public void Dispose()
       {
         
       }

   }

   public static partial class HelperComponents
   {

       [RuntimeInitializeOnLoadMethod]
       static void ComponentMotionInit()
       {
           Storage<ComponentMotion>.Instance.Creator = () => { return new ComponentMotion(); };
       }

       public static ComponentMotion ComponentMotion(in this ent entity)
       {
           return Storage<ComponentMotion>.Instance.components[entity];
       }

   }
    
    
}