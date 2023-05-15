using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Lane> lanes = new List<Lane>();

            // lineas
            // parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            // Lane(int posY, bool speedPlayer, ConsoleColor background, bool damageElements, bool damageBackground, float elementsPercent, char elementsChar, List<ConsoleColor> colorsElements)
            lanes.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0f, ' ', new List<ConsoleColor>()));
            lanes.Add(new Lane(1, false, ConsoleColor.DarkGreen, false, false, 0f, ' ', new List<ConsoleColor>()));
            lanes.Add(new Lane(2, true, ConsoleColor.DarkBlue, false, true, 0.4f, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow }));
            lanes.Add(new Lane(3, true, ConsoleColor.DarkBlue, false, true, 0.4f, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow }));
            lanes.Add(new Lane(4, true, ConsoleColor.DarkBlue, false, true, 0.4f, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow }));
            lanes.Add(new Lane(5, true, ConsoleColor.DarkBlue, false, true, 0.4f, Utils.charLogs, new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow }));
            lanes.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0f, ' ', new List<ConsoleColor>()));
            lanes.Add(new Lane(7, false, ConsoleColor.DarkGreen, false, false, 0f, ' ', new List<ConsoleColor>()));
            lanes.Add(new Lane(8, true, Console.BackgroundColor, true, false, 0.2f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red }));
            lanes.Add(new Lane(9, true, Console.BackgroundColor, true, false, 0.2f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red }));
            lanes.Add(new Lane(10, true, Console.BackgroundColor, true, false, 0.2f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red }));
            lanes.Add(new Lane(11, true, Console.BackgroundColor, true, false, 0.2f, Utils.charCars, new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red }));
            lanes.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0f, ' ', new List<ConsoleColor>()));
            lanes.Add(new Lane(13, false, ConsoleColor.DarkGreen, false, false, 0f, ' ', new List<ConsoleColor>()));

            // crear personaje
            Player player = new Player();
            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;

            while (gameState == Utils.GAME_STATE.RUNNING)
            {

                // inputs
                Vector2Int input = Utils.Input();
                gameState = player.Update(input, lanes);
                Console.Clear();

                foreach (Lane lane in lanes)
                {
                    lane.Draw();
                    lane.Update();
                }
                // dibujado
                player.Draw(lanes);
                // si el jugador gana, q se muestre en pantalla "YOU WON!"
                // si el jugador pierde, q se muestre en pantalla "YOU LOST"
                Console.SetCursorPosition(0, Utils.MAP_HEIGHT + 1);
                if (gameState == Utils.GAME_STATE.WIN)
                {
                    Console.WriteLine("YOU WON!");
                }
                else if (gameState == Utils.GAME_STATE.LOOSE)
                {
                    Console.WriteLine("YOU LOST");
                }

                // gestion d frames
                TimeManager.NextFrame();

            }

        }

        // (・_・;)
    }

}
