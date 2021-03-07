using System;
using Library;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
			Text text=new Text();
			functions.Menu(text);
        }

		static public class functions
		{
			static private void OutputText(in Text text, int rows)
			{
				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < text[i].GetLength(); j++)
					{
						Console.Write(text[i][j]);
					}
					Console.WriteLine();
				}
			}

			static private char[] input()
			{
				char[] line=Console.ReadLine().ToCharArray();
				return line;
			}

			static private void PrintMenu()
			{
				Console.WriteLine("MENU[0-8]:");
				Console.WriteLine("0. Stop a program");
				Console.WriteLine("1. Аdd a line to the text");
				Console.WriteLine("2. Delete a line from the text");
				Console.WriteLine("3. Clear the text");
				Console.WriteLine("4. Find the length of the shortest row");
				Console.WriteLine("5. Percentage of consonants in text");
				Console.WriteLine("6. Format the spaces");
				Console.WriteLine("7. Print text");
				Console.WriteLine("8. Call Menu");
			}

			static public void Menu(in Text text)
			{
				bool need = true;
				int choice;
				PrintMenu();
				do
				{
					Console.WriteLine("Your choice: ");
					choice = Convert.ToInt32(Console.ReadLine());
					switch (choice)
					{
						case 0:
							{
								need = false;
								break;
							}
						case 1:
							{
								Console.WriteLine("Enter the line");
								char[] line = input();
								MyString str = new MyString(line);
								text.AddLine(str);
								break;
							}
						case 2:
							{
								int index;
								Console.WriteLine("Enter the index");
								index = Convert.ToInt32(Console.ReadLine());
								text.DeleteLine(index);
								break;
							}
						case 3:
							{
								text.ClearText();
								break;
							}
						case 4:
							{
								Console.WriteLine("The length of the shortest row: " + text.LenShortestLine());
								break;
							}
						case 5:
							{
								Console.WriteLine(text.PercentConsonants() + "%");
								break;
							}
						case 6:
							{
								text.FormatSpaces();
								break;
							}
						case 7:
							{
								Console.WriteLine("Your text:");
								OutputText(text, text.GetSize());
								break;
							}
						case 8:
							{
								PrintMenu();
								break;
							}
						default:
							Console.WriteLine("This item does not appear on the menu.");
							break;
					}
				} while (need);
			}
		}
	}
}
