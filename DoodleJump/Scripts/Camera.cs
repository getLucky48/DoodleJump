﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DoodleJump.Scripts
{
    class Camera
    {

        //Перемещает "камеру"
        public static void TransformCamera(Canvas tCanvas, Player player)
        {

            //Если игрок достиг определенной высоты, то передвинуть игрока и все платформы
            if (player.GetLocation().Y < 300)
            {

                //Просчитываем смещение
                double translation = 300 - player.GetLocation().Y;

                //Задаем новые координаты Y игроку
                player.SetValue(Canvas.TopProperty, (double)player.GetValue(Canvas.TopProperty) + translation);

                //Задаем новые координаты Y всем платформам
                foreach (var target in tCanvas.Children.OfType<Platform>())
                {

                    target.SetValue(Canvas.TopProperty, (double)target.GetValue(Canvas.TopProperty) + translation);

                }

            }

        }

        public static void Death(Canvas tCanvas, Player player, Label over)
        {

            PlatformGenerator.RemoveAllPlatforms(tCanvas);

            over.Visibility = Visibility.Visible;

        }

    }

}
