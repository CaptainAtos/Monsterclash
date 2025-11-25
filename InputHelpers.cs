namespace Monsterclash
{
    internal static class InputHelpers
    {
        public static bool CheckUserInputInt(string _input, int _expected, out int _result)
        {
            bool correctInput = int.TryParse(_input, out _result);

            if (correctInput)
                return _result == _expected;

            return false;
        }
        public static bool CheckUserInputIntRange(string _input, int _min, int _max, out int _result)
        {
            bool correctInput = int.TryParse(_input, out _result);
            
            if (correctInput)
                if (_result >= _min && _result <= _max)
                    return true;

            return false;
        }

        public static bool CheckUserInputIntMax(string _input, int _max, out int _result)
        {
            bool correctInput = int.TryParse(_input, out _result);

            if (correctInput)
                if (_result <= _max)
                    return true;

            return false;
        }

        public static bool CheckUserInputIntMin(string _input, int _min, out int _result)
        {
            bool correctInput = int.TryParse(_input, out _result);

            if (correctInput)
                if (_result >= _min)
                    return true;

            return false;
        }
    }
}