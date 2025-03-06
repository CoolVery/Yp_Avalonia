namespace REG_MARK_LIB
{
    public class REG_MARK_LIB_CLASS
    {
        List<char> _correctSymbols = new List<char>() { 'a', 'b', 'e', 'k', 'm', 'h', 'o', 'p', 'c', 't', 'y', 'x'};
        List<int> _correctNumRegion = new List<int>() { 102, 113, 116, 716, 121, 123, 124, 125, 134, 150, 190, 750, 790, 152, 154, 159, 161, 163, 164, 196, 173, 174, 177, 197, 199, 777, 799, 186 };
        public bool CheckMark(string mark)
        {
            switch (_correctSymbols.Contains(mark[0]) && _correctSymbols.Contains(mark[4]) && _correctSymbols.Contains(mark[5]))
            {
                case false:
                    return false;
            }
            int numRegion = 0;
            switch (mark.Length)
            {
                case 9:
                    numRegion = Convert.ToInt32(mark[6..9]);
                    break;
                case 8:
                    numRegion = Convert.ToInt32(mark[6..8]);
                    break;
            }
            if (0 < numRegion && numRegion < 100)
            {
                return true;
            }
            if (_correctNumRegion.Contains(numRegion))
            {
                return true;
            }
            return false;
        }
        public string GetNextMarkAfter(string mark)
        {
            string resultNum = string.Copy(mark);
            int numberMark = Convert.ToInt32(mark[1..4]);
            if (numberMark != 999)
            {
                string numberMarkStr = (++numberMark).ToString();
                switch (numberMarkStr.Length)
                {
                    case 1:
                        numberMarkStr = String.Concat("00", numberMarkStr);
                        break;
                    case 2:
                        numberMarkStr = String.Concat("0", numberMarkStr);
                        break;
                }
                resultNum = resultNum.Remove(1, 1).Insert(1, numberMarkStr[0].ToString());
                resultNum = resultNum.Remove(2, 1).Insert(2, numberMarkStr[1].ToString()); 
                resultNum = resultNum.Remove(3, 1).Insert(3, numberMarkStr[2].ToString()); 
                return resultNum;
            }
            else
            {
                resultNum = resultNum.Remove(1, 1).Insert(1, "0");
                resultNum = resultNum.Remove(2, 1).Insert(2, "0");
                resultNum = resultNum.Remove(3, 1).Insert(3, "0");
                int countEndSymbol = resultNum.Count(x => x == 'x');
                if (countEndSymbol == 3)
                {
                    resultNum = resultNum.Remove(0, 1).Insert(0, "a"); 
                    resultNum = resultNum.Remove(4, 1).Insert(4, "a");
                    resultNum = resultNum.Remove(5, 1).Insert(5, "a");
                    return resultNum;
                }
                else if (countEndSymbol == 2)
                {
                    int indexFirstLastSymbol = resultNum.IndexOf('x');
                    int indexSecondLastSymbol = resultNum.LastIndexOf('x');
                    if (indexFirstLastSymbol == 0 && indexSecondLastSymbol == 4)
                    {
                        int indexInList = _correctSymbols.IndexOf(resultNum[5]);
                        resultNum = resultNum.Remove(5, 1).Insert(5, _correctSymbols[indexInList++].ToString());
                        return resultNum;
                    }
                    else if (indexFirstLastSymbol == 0 && indexSecondLastSymbol == 5)
                    {
                        int indexInList = _correctSymbols.IndexOf(resultNum[4]);
                        resultNum = resultNum.Remove(4, 1).Insert(4, _correctSymbols[indexInList++].ToString());
                        return resultNum;
                    }
                    else
                    {
                        int indexInList = _correctSymbols.IndexOf(resultNum[0]);
                        resultNum = resultNum.Remove(0, 1).Insert(0, _correctSymbols[indexInList++].ToString());
                        return resultNum;
                    }
                }
                else
                {
                    switch(resultNum.IndexOf('x'))
                    {
                        case 0:
                            int indexInList = _correctSymbols.IndexOf(resultNum[5]);
                            resultNum = resultNum.Remove(5, 1).Insert(5, _correctSymbols[indexInList++].ToString());
                            return resultNum;
                        case 4:
                            indexInList = _correctSymbols.IndexOf(resultNum[5]);
                            resultNum = resultNum.Remove(5, 1).Insert(5, _correctSymbols[indexInList++].ToString());
                            return resultNum;
                        case 5:
                            indexInList = _correctSymbols.IndexOf(resultNum[4]);
                            resultNum = resultNum.Remove(4, 1).Insert(4, _correctSymbols[indexInList++].ToString());
                            resultNum = resultNum.Remove(5, 1).Insert(5, "a");
                            return resultNum;
                    }
                }
            }
            return resultNum;
        }
        public string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            int indexFirstSymbolRangeStart = _correctSymbols.IndexOf(rangeStart[0]);
            int indexFirstSymbolRangeEnd = _correctSymbols.IndexOf(rangeEnd[0]);
            int indexFirstSymbolPrevMark = _correctSymbols.IndexOf(prevMark[0]);
            if (indexFirstSymbolRangeStart <= indexFirstSymbolPrevMark && indexFirstSymbolPrevMark <= indexFirstSymbolRangeEnd)
            {
                return GetNextMarkAfter(prevMark);
            }
            else if (indexFirstSymbolRangeStart == indexFirstSymbolRangeEnd && indexFirstSymbolRangeStart == indexFirstSymbolPrevMark)
            {
                int indexSecondSymbolRangeStart = _correctSymbols.IndexOf(rangeStart[4]);
                int indexSecondSymbolRangeEnd = _correctSymbols.IndexOf(rangeEnd[4]);
                int indexSecondSymbolPrevMark = _correctSymbols.IndexOf(prevMark[4]);
                if (indexSecondSymbolRangeStart <= indexSecondSymbolPrevMark && indexSecondSymbolPrevMark <= indexSecondSymbolRangeEnd)
                {
                    return GetNextMarkAfter(prevMark);
                }
                else if (indexSecondSymbolRangeStart == indexSecondSymbolRangeEnd && indexSecondSymbolRangeStart == indexSecondSymbolPrevMark)
                {
                    int indexThirdSymbolRangeStart = _correctSymbols.IndexOf(rangeStart[5]);
                    int indexThirdSymbolRangeEnd = _correctSymbols.IndexOf(rangeEnd[5]);
                    int indexThirdSymbolPrevMark = _correctSymbols.IndexOf(prevMark[5]);
                    if (indexThirdSymbolRangeStart <= indexThirdSymbolPrevMark && indexThirdSymbolPrevMark <= indexThirdSymbolRangeEnd)
                    {
                        return GetNextMarkAfter(prevMark);
                    }
                    else if (indexThirdSymbolRangeStart == indexThirdSymbolRangeEnd && indexThirdSymbolRangeStart == indexThirdSymbolPrevMark)
                    {
                        int numberRangeStart = Convert.ToInt32(rangeStart[1..3]);
                        int numberRangeEnd = Convert.ToInt32(rangeEnd[1..3]);
                        int numberPevMark = Convert.ToInt32(prevMark[1..3]);
                        if (numberRangeStart < numberPevMark && numberPevMark < numberRangeEnd)
                        {
                            return GetNextMarkAfter(prevMark);
                        }
                        else return "out of stock";
                    }
                    else
                    {
                        return "out of stock";
                    }
                }
                else
                {
                    return "out of stock";
                }
            }
            else
            {
                return "out of stock";
            }
        }
        int GetCombinationsCountInRange(string mark1, string mark2)
        {
            int indexFirstSymbolMarkOne = _correctSymbols.IndexOf(mark1[0]);
            int indexFirstSymbolMarkTwo = _correctSymbols.IndexOf(mark2[0]);
            switch (indexFirstSymbolMarkOne == indexFirstSymbolMarkTwo)
            {
                case true:
                    int numberMarkOne = Convert.ToInt32(mark1[1..4]);
                    int numberMarkTwo = Convert.ToInt32(mark1[1..4]);

                    break;
                case false:
                    break;
            }

        }

    }
}
