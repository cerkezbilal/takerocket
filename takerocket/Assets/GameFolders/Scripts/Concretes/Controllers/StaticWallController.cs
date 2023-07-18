using System.Collections;
using System.Collections.Generic;
using takerocket.Abstract.Controllers;
using UnityEngine;

namespace takerocket.Controllers
{
    public class StaticWallController : WallController
    {
        //Artık oncollisionEnter burda da çalışacak. StaticWall da başka kod yazmıcaz çünkü bu sınıf sadece çarpma işlemi var onu da atasından(WallControllerdan) alacak zaten. Ama güzel yanı static e sonradan başka özellik vermek istersek yazabiliriz.
    }
}

