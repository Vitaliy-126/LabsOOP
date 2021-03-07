
namespace Library
{
	public class MyString
	{
		public MyString()
		{
			str = null;
			length = 0;
		}
		public MyString(char[] str)
		{
			length = str.Length;
			this.str = new char[length];
			for (int i = 0; i < length; i++)
			{
				this.str[i] = str[i];
			}
		}
		public MyString(in MyString other)
		{
			length = other.length;
			str = new char[length];
			for (int i = 0; i < length; i++)
			{
				str[i] = other.str[i];
			}
		}
		public char this[int index]
		{
			get
			{
				return str[index];
			}

			set
			{
				str[index] = value;
			}
		}
		public int GetLength()
		{
			return length;
		}
		public void Erase(int pos, int k)
		{
			if (pos >= 0 && k > 0 && (pos + k - 1) <= this.GetLength())
			{
				MyString temp = new MyString(this);
				length = this.GetLength() - k;
				str = new char[length];
				int i = 0,
					correction = 0;
				while (i < length)
				{
					if (i == pos)
						correction = k;
					str[i] = temp.str[i + correction];
					i++;
				}
			}
		}

		private char[] str;
		private int length;
	}
}
