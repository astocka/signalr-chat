using CoffeeChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeChat.Helpers
{
    public static class EnumHelper
    {
        static Dictionary<string, string> AvatarUrl = new Dictionary<string, string>
        {
            {"Bear",    "icons8-bear-48.png"},
            {"BlackJaguar", "icons8-black-jaguar-48.png"},
            {"Butterfly",   "icons8-cat-48.png"},
            {"Cat", "icons8-christmas-penguin-48.png"},
            {"Dog", "icons8-dolphin-48.png"},
            {"Dolphin", "icons8-dove-48.png"},
            {"Dove",    "icons8-fox-48.png"},
            {"Fox", "icons8-german-shepherd-48.png"},
            {"Giraffe", "icons8-giraffe-48.png"},
            {"Horse",   "icons8-horse-48.png"},
            {"KoiFish", "icons8-koi-fish-48.png"},
            {"Lion",    "icons8-lion-48.png"},
            {"Panda",   "icons8-machaon-butterfly-48.png"},
            {"Penguin", "icons8-panda-48.png"},
            {"Sheep",   "icons8-sheep-48.png"},
            {"Snake",   "icons8-snake-48.png"},
            {"Swan",    "icons8-swan-48.png"}
        };

        public static string GetAvatarUrl(string avatar)
        {
            return AvatarUrl[avatar];
        }
    }
}
