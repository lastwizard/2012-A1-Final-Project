using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Data.Search
{
    public class ProductSearchParameters
    {
        private IList<string> searchCriteria = new List<string>();

        public ProductSortType SortType { get; set; }
        public SortDirection SortDirection { get; set; }
        public IList<string> Criteria
        {
            get { return new List<string>(searchCriteria).AsReadOnly(); }
        }

        public void AddCriteria(string criteria)
        {
            if (!String.IsNullOrEmpty(criteria))
            {
                char[] breaks = new char[1];
                breaks[0] = ' ';
                string[] crits = criteria.Split(breaks);
                for (int i = 0; i < crits.Length; i++)
                    if (!searchCriteria.Contains(crits[i]))
                        searchCriteria.Add(crits[i]);
            }
        }
    }
}
