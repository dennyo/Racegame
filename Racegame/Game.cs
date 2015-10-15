using RaceGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Racegame {

    public enum Character {Jos, Fiona, David, Jop, Nynke, Sibbele, Joris, Dick};
    public enum Map {Standard, Koopa_Beach, Rainbow_Road, Zelda };

    class Game {
       
        SoundPlayer soundtrack;
        Player p1;
        Player p2;
        Map map;

        public Game(Player p1, Player p2, Map map, string soundtrack) {
            this.p1 = p1;
            this.p2 = p2;
            this.map = map;
            
            SoundPlayer soundplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, soundtrack));
            this.soundtrack = soundplayer;

        }

    }
}
