using System;

namespace BoxOfficeBL.Model
{
    public class Hall
    {
        public string Name { get; }
        public int QtyRows { get; }
        public int QtySeatsInRow { get; }
        public Hall(string name, int qtyRows, int qtySeatsInRow)
        {
            #region verify the conditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The name of the hall cannot be empty or null", nameof(name));
            }

            if (qtyRows <= 0)
            {
                throw new ArgumentException("The number of rows must be greater than zero", nameof(qtyRows));
            }

            if (qtySeatsInRow <= 0)
            {
                throw new ArgumentException("The number of seats in a row must be greater than zero", nameof(qtySeatsInRow));
            }
            #endregion
            Name = name;
            QtyRows = qtyRows;
            QtySeatsInRow = qtySeatsInRow;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
