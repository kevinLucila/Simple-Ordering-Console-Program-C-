﻿using System;

namespace bgb
{
	
       class Menu
	{
		private int SelectedIndex;
		private string[] Options;
		private string Prompt;
		
		
		public Menu(string prompt, string[] options)
		{
			Prompt = prompt;
			Options = options;
			SelectedIndex = 0;
		
		}
		
		private void DisplayOptions()
		{
			Console.WriteLine(Prompt);
			Console.WriteLine();
		    for (int i = 0; i < Options.Length; i++) 
		    {
		    	string currentOption = Options[i];
		    	string prefix;
		    	
		    	if (i == SelectedIndex)
		    	{
		    		prefix = ">";
		    		
		    	}
		       else
		    	{
		     	  prefix = " ";
		     	  
		    	}
		    	
		       Console.WriteLine(prefix +"["+ currentOption +"]");
		    	
		    }
		   
		}
		
		public int Run()
		{
			ConsoleKey keyPressed;
			
			do
			{
				Console.Clear();
				DisplayOptions();
				
				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				keyPressed = keyInfo.Key;
				
				if (keyPressed == ConsoleKey.UpArrow)
				{
					SelectedIndex --;
					if (SelectedIndex == -1)
					{
						SelectedIndex = Options.Length -1;
					}
					
				}
				else if (keyPressed == ConsoleKey.DownArrow)
				{
					SelectedIndex ++;
					if (SelectedIndex == Options.Length)
					{
						SelectedIndex = 0;
					}
				}	
				
			}while (keyPressed != ConsoleKey.Enter);
		
			return SelectedIndex;
		
		}
	}
}
