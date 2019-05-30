using System;

namespace TrendyolTest.PageModel
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FindsBy : Attribute
    {
        private readonly string _locator;

        public string Locator
        {
            get
            {
                return _locator;
            }
        }

        public FindsBy(string locator)
        {
            _locator = locator;
        }
    }
}