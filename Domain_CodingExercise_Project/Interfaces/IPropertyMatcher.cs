using System;
using System.Collections.Generic;
using System.Text;
using Domain_CodingExercise_Project.Classes;

namespace Domain_CodingExercise_Project.Interfaces
{
    public interface IPropertyMatcher
    {
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }
}
