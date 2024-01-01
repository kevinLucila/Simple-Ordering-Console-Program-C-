using System;

namespace bgb
{
	class Program
	{
		public static void Main()
		{
			string prompt = @"

      _       _                       ____            
     | | ___ | |__  _ __  _ __  _   _| __ )  ___  ___ 
  _  | |/ _ \| '_ \| '_ \| '_ \| | | |  _ \ / _ \/ _ \
 | |_| | (_) | | | | | | | | | | |_| | |_) |  __/  __/
  \___/ \___/|_| |_|_| |_|_| |_|\__, |____/ \___|\___|
                                |___/                 

";
			
			string[] options = {"Add order", "Details","Exit"};
			
			Menu mainMenu = new Menu( prompt ,options);
			int selectedIndex = mainMenu.Run();
			
			switch (selectedIndex)
			{
				case 0:
					Order();
					break;
					
			    case 1:
					details();
					break;
			
			     case 2:
					System.Environment.Exit(0);
					break;	
			}			
		

		}
		
		
		public static void details()
		{
			Console.Clear();
			ConsoleKey keypressed;
			Console.WriteLine(" ___________________________________________________________________________________________");
			Console.WriteLine("|"+"This project is named Simple Ordering Console Program, and it includes options, a meal menu"+"|");
			Console.WriteLine("|"+", the ordering procedure, and the subtotal of the orders."+"                                  |");
			Console.WriteLine("|"+"___________________________________________________________________________________________"+"|");
			Console.WriteLine();
			Console.WriteLine("Press esc to go back in main menu");
			ConsoleKeyInfo keyInfo = Console.ReadKey(true);
			keypressed = keyInfo.Key;
			if (keypressed == ConsoleKey.Escape)
			{
				Program.Main();
			}
			
		
		
		
		}
	
		public static void Order()
		{
		start:
			// Menu
			Console.Clear();
			ConsoleKey keyPPressed;
		    
			string[] code = new string[6] {"C1","C2","C3","C4","C5","F1"};
			string[] menu = new string[6] {"1pc. Chickenjoy w/ Johnny Spaghetti & Drinks",
			                               "2pc. Chickenjoy w/ Rice, Fries & Coke Float",
			                               "1pc. Burger Steak w/ Drinks",
			                               "2pc. Burger Steak w/ Fries & Drinks",
			                               "1pc. Chickenjoy w/ Burger Steak & Half Johnny Spaghetti",
			                               "Finish Order "};
			decimal[] price = new decimal[6] {129.00m,169.00m,79.00m,149.00m,239.00m,0};
			string sprice;
			
			Console.WriteLine(" __________________________________________________________________________________________ ");
			Console.WriteLine("|Code".PadRight(30)+"Menu".PadRight(55)+"Price"+" |");
			Console.WriteLine("|"+"------------------------------------------------------------------------------------------"+"|");
		for (int i = 0; i < menu.Length; i++) 
		{
			if(price[i] > 0){sprice = price[i].ToString();} else {sprice = " ";}
			Console.WriteLine("|"+code[i].PadRight(10) + menu[i].PadRight(70) + sprice.PadLeft(10)+"|");
		}
		Console.WriteLine("|"+"__________________________________________________________________________________________"+"|");
		Console.WriteLine();
		
		// Ordering
		string[] order_list = new string[1];
		string order,Sqty,total1,n, amount;
		int code_index, qty, currentindex = 0;
		decimal total = 0,grandtotal = 0, amountpaid = 0 ,change = 0;
		do{
		
			Console.Write("Enter product code: ");
			order = Console.ReadLine().ToUpper();
			code_index = Array.IndexOf(code, order);
			if (code_index < 0)
			{
				Console.WriteLine("<Invalid product code>");
			}
			else 
			{
				if(order != "F1")
				{
					do
					{
					 Console.Write("Enter Qty: ");
					 Sqty =Console.ReadLine();
					 if(int.TryParse(Sqty,out qty) == false)
					 {
					 	Console.WriteLine("<Invalid input quantity>");
					 }
					}while(int.TryParse(Sqty,out qty) == false);
					
					
					
					total = price[code_index] * qty;
					grandtotal = grandtotal + total;
					order_list[currentindex] = order.PadRight(10) + menu[code_index].PadRight(60) +price[code_index].ToString().PadRight(20) 
						                                                        + qty.ToString().PadRight(10) + total.ToString().PadLeft(10);
					Array.Resize(ref order_list, order_list.Length + 1);
					currentindex ++;
					
				}
			
			}
		}while (order != "F1");
		Console.WriteLine();
		Console.WriteLine();
		
		
		if (grandtotal > 0)
		{
			// Reciept
		     Console.Clear();
		    
		     Console.WriteLine("Code".PadRight(30)+"Menu".PadRight(40)+ " Price".PadRight(20)+"Qty.".PadRight(12)+" Subtotal");
		    
		       for (int i = 0; i< order_list.Length; i++)
		        {
			       Console.WriteLine(order_list[i]);
		        }

		      total1 = "Total: "+ grandtotal.ToString(".00");
		      Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
		      Console.WriteLine(total1.PadLeft(110));
			
			do
		     {
			    do
			     {
				Console.Write("Enter amount paid: ");
				amount = Console.ReadLine();
			      }while(decimal.TryParse(amount,out amountpaid)== false);
			if(Convert.ToDecimal(amount)<grandtotal)
			{
				Console.WriteLine("<Amount paid must be greater than the total amount>");
			}
			
		    }while(Convert.ToDecimal(amount)<grandtotal);
		          change = amountpaid - grandtotal;
		          Console.WriteLine("Change: "+ change);
		          Console.WriteLine();
			
		}
		
		//New transaction or go back to main menu
	    transact:
		Console.Write("Do you want to make another transaction? (Y/N): ");
		n = Console.ReadLine();
		if(n == "Y" || n == "y" )
		{
			goto start;
		}
		
		else if(n =="N" || n == "n")
		{
			
			Program.Main();
		}
		
		else 
		{
			Console.WriteLine("<Invalid Input>");
			goto transact;
		}
		
		Console.ReadKey();
		
		}
	
	}
	      
}
	      
	
	       
	
	
	
	
	
	
	
	
	
