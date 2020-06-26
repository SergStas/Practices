using System;

namespace pract_26_06_20
{
    public class Ratio
    {
        public int Upper
        {
            get => _upper;
            set
            {
                _upper = value;
                Normalize();
            }
        }
        public int Lower
        {
            get => _lower;
            set
            {
                _lower = value;
                Normalize();
            }
        }
        public int Integer
        {
            get => _integer;
        }

        private int _lower;
        private int _upper;
        private int _integer;

        public Ratio(int upper, int lower)
        {
            _upper = Math.Abs(upper);
            Lower = lower;
        }

        public Ratio(int upper, int lower, int integer)
        {
            _integer = integer;
            _upper = Math.Abs(upper);
            Lower = lower;
        }

        private void Normalize()
        {
            _upper += _lower * _integer;
            _integer = _upper / _lower;
            _upper %= _lower;
            int common = GetCommon(_upper, _lower);
            _upper /= common;
            _lower /= common;
        }

        private static int GetCommon(int f, int s) => f == 0 ? s : GetCommon(s % f, f);

        public static Ratio operator +(Ratio r1, Ratio r2) =>
            r1.Add(r2);

        public static Ratio operator -(Ratio r1, Ratio r2) =>
            r1.Sub(r2);

        public static Ratio operator *(Ratio r1, Ratio r2) =>
            r1.Mp(r2);

        public static Ratio operator /(Ratio r1, Ratio r2) =>
            r1.Div(r2);

        public Ratio Add(Ratio ratio)
        {
            if (Lower != ratio.Lower)
                throw new NotImplementedException();
            Ratio result = new Ratio(Upper + ratio.Upper, Lower);
            return result;
        }

        public Ratio Sub(Ratio ratio)
        {
            if (Lower != ratio.Lower)
                throw new NotImplementedException();
            Ratio result = new Ratio(Upper - ratio.Upper, Lower);
            return result;
        }

        public Ratio Mp(Ratio ratio) =>
            new Ratio(Upper * ratio.Upper, Lower * ratio.Lower);

        public Ratio Div(Ratio ratio) =>
            new Ratio(Upper * ratio.Lower, Lower * ratio.Upper);

        public override string ToString() =>
            Integer == 0 && Upper == 0 ? "0" : $"{(Integer == 0 ? "" : $"{Integer} ")}{(Upper == 0 ? "" : $"{Upper}/{Lower}")}";
    }
}