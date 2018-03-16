using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Device.Location;
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

                case "LRE":
                    double distance = CalculateDistance(agencyProperty.Latitude, agencyProperty.Longitude, databaseProperty.Latitude, databaseProperty.Longitude);
                    status = distance <= 200 ? true : false;
                    break;

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

        private double CalculateDistance(decimal srcLatitude, decimal srclongitdue, decimal dstLatitude, decimal dstLongitude)
        {
            /*
                 Double datatype is sufficient to capture the latitude and longitude values
                 Hence explict conversion from decimal to double will not loose its value
             */

            GeoCoordinate srcGeoCoordinate = new GeoCoordinate((double)srcLatitude, (double)srclongitdue);
            GeoCoordinate dstGeoCoordinate = new GeoCoordinate((double)dstLatitude, (double)dstLongitude);

            return Math.Round(srcGeoCoordinate.GetDistanceTo(dstGeoCoordinate));


        }
    }
}
