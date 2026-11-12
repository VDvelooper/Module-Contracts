using System.ComponentModel;
using System.Data.Common;

namespace ModuleContracts.Console.Output.Tables
{
    public class ConsoleTable
    {
        public int RowCount { get; }
        public int ColCount { get; }

        public bool ContainsHeader { get; }

        public List<string> Header { get; }
        public Dictionary<(int Row, int Col), string> Body { get; private set; }

        public int VerticalPadding
        {
            get { return _verticalPadding; }
            set
            {
                if (value < 0) return;
                else _verticalPadding = value;
            }
        }
        public int HorizontalPadding
        {
            get { return _horizontalPadding; }
            set
            {
                if (value < 0) return;
                else _horizontalPadding = value;
            }
        }
        public int ItemWidth
        {
            get { return _itemWidth; }
            set
            {
                if (value < 0) return;
                else _itemWidth = value;
            }
        }

        private int _verticalPadding = 0;
        private int _horizontalPadding = 0; // 2
        private int _itemWidth = 0;


        
        public int TableWidth
        {
            get 
            {
                int itemSumMaxWidth = 0;

                for (int c = 0; c < ColCount; c++)
                {
                    itemSumMaxWidth += GetColMaxItemLength(c);
                }

                return itemSumMaxWidth + (ColCount - 1); 
            }
        }
        public int TableHeight
        {
            get { return RowCount + 2 * VerticalPadding + RowCount; }
        }
        
        public ConsoleTable(int rowCount, int colCount, bool containsHeader, List<string>? headerContent = null)
        {
            ContainsHeader = containsHeader;

            RowCount = rowCount;
            ColCount = colCount;

            if (ContainsHeader) Header = new List<string>(colCount);

            if (ContainsHeader && headerContent != null)
            {
                for (int i = 0; i < ColCount; i++)
                {
                    Header!.Append(headerContent[i]);
                }
            }

            Body = new Dictionary<(int, int), string>();

            for (int row = 0; row < RowCount; row++)
            {
                for (int col = 0; col < ColCount; col++)
                {
                    Body.Add((row,col), "");
                }
            }
        }

        public void AddHeaderContent(string content)
        {
            Header.Add(content);
        }
        public void AddHeaderContent(List<string> content)
        {
            foreach (string s in content)
            {
                Header.Add(s);
            }
        }

        public void AddBodyContent(string content)
        {
            (int, int) pos = GetUncompleteIndex();

            if (pos == (-1,-1)) return;

            if (content.Length > ItemWidth) ItemWidth = content.Length;

            Body[pos] = content;
        }
        public void AddBodyContent(List<string> content) 
        {
            (int Row, int Col) pos = GetUncompleteIndex();

            if (pos == (-1, -1)) return;

            int contentIndex = 0;
            for (int row = pos.Row; row < RowCount && content.Count > contentIndex; row++)
            {
                for (int col = pos.Col; col < ColCount && content.Count > contentIndex; col++, contentIndex++)
                {
                    if (content[contentIndex].Length > ItemWidth) ItemWidth = content[contentIndex].Length;

                    if (content[contentIndex].Length % 2 != 0) content[contentIndex] += ' ';

                    Body[(row, col)] = content[contentIndex];
                    
                }
            }
        }

        public int GetColMaxItemLength(int column)
        {
            return Body.Where(x => x.Key.Col == column).OrderByDescending(x => x.Value.Length).Select(x=>x.Value.Length).First();
        }

        public bool IsRowEmpty(int row)
        {
            int foundEmpty = 0;
            for (int c = 0; c < ColCount; c++)
            {
                if (string.IsNullOrEmpty(Body[(row, c)]))
                    foundEmpty++;
            }

            return foundEmpty == ColCount;
        }
        
        private (int, int) GetUncompleteIndex()
        {
            (int, int)? foundPos = Body.Where(body => string.IsNullOrEmpty(body.Value)).OrderBy(body => body.Key.Row).ThenBy(body => body.Key.Col).Select(body => body.Key).FirstOrDefault();

            return foundPos ?? (-1,-1);
        }

    }
}
