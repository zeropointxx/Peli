using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peli.Scenes
{
    class SceneSys
    {
      static  List<SceneParent> currentScenes = new List<SceneParent>();
      static bool sceneChanged = false;
      public static void ChangeScene(SceneParent scene)
      {
          currentScenes.Clear();
          OpenScene(scene);
      }
      public static void OpenScene(SceneParent scene)
      {
          currentScenes.Add(scene);
          sceneChanged = true;
      }
      public static void Update(float dT)
      {
          for (int i = 0; i < currentScenes.Count(); i++)
          {
              SceneParent s = currentScenes[i];
              if (!s.Paused)
              {
                  currentScenes[i].Update(dT);
                  if (sceneChanged)
                      break;
              }
          }
      }
      public static void PauseCurrentScene(bool pause)
      {
          currentScenes[currentScenes.Count() - 1].Paused = pause;
      }
        public static void CloseCurrentScene()
        {
            currentScenes.RemoveAt(currentScenes.Count() - 1);
            sceneChanged = true;
        }

      public static void Draw(float dT)
      {
          foreach(SceneParent s in currentScenes)
          {
              s.Draw(dT);
          }
      }
    }
}
