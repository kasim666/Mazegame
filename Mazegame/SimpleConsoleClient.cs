///////////////////////////////////////////////////////////
//  SimpleConsoleClient.cs
//  Implementation of the Class SimpleConsoleClient
//  Generated by Enterprise Architect
//  Created on:      28-Apr-2014 10:13:37 PM
//  Original author: Gsimmons
///////////////////////////////////////////////////////////


using System;
using Mazegame.Boundary;
namespace Mazegame {
	public class SimpleConsoleClient : IMazeClient {

		public SimpleConsoleClient(){
            Console.Title = "Greg's wacky maze game";
            Console.WindowWidth = 100;
            Console.ForegroundColor = ConsoleColor.White;
		}

		/// 
		/// <param name="question"></param>
		public String GetReply(String question){
            Console.Out.Write("\n" + question + " ");
            return Console.In.ReadLine();
		}

		/// 
		/// <param name="message"></param>
		public void PlayerMessage(String message){
            Console.Out.Write(message);
		}

        public String GetCommand()
        {
            Console.Out.Write("\n\n>>> ");
            return Console.In.ReadLine();
        }


    }//end SimpleConsoleClient

}//end namespace Mazegame