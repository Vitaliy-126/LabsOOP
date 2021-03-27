using System;
namespace Library
{
    public class MyClass
    {
        public MyClass()
        {
            size = 0;
        }
        public MyClass(bool[] array)
        {
            this.array = array;
            size = array.Length;
        }
        public bool this[int index]
        {
            get
            {
                if (index >= 0 && index < size)
                {
                    if (array[index] == true)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    throw new Exception("index out of range");
                }
            }
        }

        public bool Result
        {
            get
            {
                if (size > 0)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (array[i] == true)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    throw new Exception("array is empty");
                }
            }
        }

        private bool[] array;
        private int size;
    }
}