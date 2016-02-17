﻿/**
     Because i love chocolat...                                      
                                    88 88  
                                    "" 88  
                                       88  
8b       d8 88       88 8b,dPPYba,  88 88  
`8b     d8' 88       88 88P'    "8a 88 88  
 `8b   d8'  88       88 88       d8 88 ""  
  `8b,d8'   "8a,   ,a88 88b,   ,a8" 88 aa  
    Y88'     `"YbbdP'Y8 88`YbbdP"'  88 88  
    d8'                 88                 
   d8'                  88     
   
   Private Habbo Hotel Emulating System
   @author Claudio A. Santoro W.
   @author Kessiler R.
   @version dev-beta
   @license MIT
   @copyright Sulake Corporation Oy
   @observation All Rights of Habbo, Habbo Hotel, and all Habbo contents and it's names, is copyright from Sulake
   Corporation Oy. Yupi! has nothing linked with Sulake. 
   This Emulator is Only for DEVELOPMENT uses. If you're selling this you're violating Sulakes Copyright.
*/

using Yupi.Emulator.Core.Security.BlackWords.Enums;

namespace Yupi.Emulator.Core.Security.BlackWords.Structs
{
    /// <summary>
    ///     Struct BlackWord
    /// </summary>
    internal struct BlackWord
    {
        /// <summary>
        ///     The word
        /// </summary>
        public string Word;

        /// <summary>
        ///     The type
        /// </summary>
        public BlackWordType Type;

        public BlackWordTypeSettings TypeSettings => BlackWordsManager.GetSettings(Type);

        /// <summary>
        ///     Initializes a new instance of the <see cref="BlackWord" /> struct.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="type">The type.</param>
        public BlackWord(string word, BlackWordType type)
        {
            Word = word;
            Type = type;
        }
    }
}