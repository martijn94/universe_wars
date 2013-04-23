using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    public interface IShootBehaviour
    {
        void shoot();

        Game getGame();
    }
}
