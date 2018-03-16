using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using Domain.CodingExercise.Project.Interfaces;

namespace Domain.CodingExercise.Project.Classes
{
    public class Helper : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            bool status = false;
            switch (agencyProperty.AgencyCode)
            {
                case "OTBRE":
                    status = RemovePunctuation(agencyProperty.Name) == databaseProperty.Name
                                          &&
                             RemovePunctuation(agencyProperty.Address) == databaseProperty.Address;
                    break;

                case "LRE": break;

                case "CRE":
                    status = String.Join(" ", agencyProperty.Name.Split(' ').Reverse()) == databaseProperty.Name;
                    break;
            }

            return status;
        }

        private string RemovePunctuation(string source)
        {
            /*
                \p{P}--> To replace punctuation with empty space
                \s+ --> To remove extra spaces
                Trim()--> To remove leading And trailing Spaces
                */

            return Regex.Replace(Regex.Replace(source, @"\p{P}", " "), @"\s+", " ").Trim();
        }
    }
}
