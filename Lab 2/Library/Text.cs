namespace Library
{
	public class Text
	{
		public Text()
		{
			text = null;
			rows = 0;
		}
		public void AddLine(in MyString str)
		{
			MyString[] temp = new MyString[rows];
			if (text != null)
			{
				for (int i = 0; i < rows; i++)
				{
					temp[i] = text[i];
				}
			}
			rows++;
			text = new MyString[rows];
			for (int i = 0; i < rows - 1; i++)
			{
				text[i] = temp[i];
			}
			text[rows - 1] = str;
		}
		public void DeleteLine(int row)
		{
			if (row < rows)
			{
				if (text != null && rows >= 1)
				{
					MyString[] temp = new MyString[rows - 1];
					int start = 0,
						pos = 0;
					while (pos < rows)
					{
						if (pos != row)
						{
							temp[start] = text[pos];
							start++;
							pos++;
						}
						else pos++;
					}
					rows--;
					text = temp;
				}
			}
		}
		public void ClearText()
		{
			if (text != null)
				text = null;
			rows = 0;
		}
		public int LenShortestLine()
		{
			if (rows == 0) return -1;
			else
			{
				int min = text[0].GetLength();
				int index = 0;
				for (int i = 1; i < rows; i++)
				{
					if (min > text[i].GetLength())
					{
						min = text[i].GetLength();
						index = i;
					}
				}
				return index;
			}
		}
		public double PercentConsonants()
		{
			int length,
			letters = 0,
			consonants = 0;
			for (int i = 0; i < rows; i++)
			{
				length = text[i].GetLength();
				for (int j = 0; j < length; j++)
				{
					if (char.IsLetter(text[i][j]))
					{
						letters++;
						if (IsConsonant(text[i][j]))
							consonants++;
					}
				}
			}
			return ((double)consonants / letters) * 100;
		}
		public void FormatSpaces()
		{
			int j,
			counter = 0,
			start;
			for (int i = 0; i < rows; i++)
			{
				if (text[i].GetLength() > 0)
				{
					if (text[i][0] == ' ')
					{
						j = 0;
						counter = 0;
						while (text[i][j] == ' ')
						{
							counter++;
							j++;
						}
						text[i].Erase(0, counter);
					}
					if (text[i][text[i].GetLength() - 1] == ' ')
					{
						j = text[i].GetLength() - 1;
						counter = 0;
						while (text[i][j] == ' ')
						{
							counter++;
							j--;
						}
						text[i].Erase(j + 1, counter);
					}
					j = 0;
					start = 0;
					while (j < text[i].GetLength())
					{
						counter = 0;
						if (text[i][j] == ' ')
						{
							start = j;
							while (text[i][j] == ' ')
							{
								counter++;
								j++;
							}
							if (counter > 1)
							{
								text[i].Erase(start, counter - 1);
								j = start;
							}
						}
						j++;
					}
				}
			}
		}

		public MyString this[int index]
		{
			get
			{
				return text[index];
			}

			set
			{
				text[index] = value;
			}
		}
		public int GetSize()
		{
			return rows;
		}
		private MyString[] text;
		private int rows;
		private bool IsConsonant(char letter)
		{
			bool result = true;
			MyString vowels = new MyString("aeiouy".ToCharArray());
			for (int i = 0; i < vowels.GetLength(); i++)
			{
				if (vowels[i] == char.ToLower(letter))
					result = false;
			}
			return result;
		}
	}
}
