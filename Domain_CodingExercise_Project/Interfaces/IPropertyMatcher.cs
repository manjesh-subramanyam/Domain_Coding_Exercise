using System;
using System.Collections.Generic;
using System.Text;
using Domain.CodingExercise.Project.Classes;

namespace Domain.CodingExercise.Project.Interfaces
{
    public interface IPropertyMatcher
    {
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }
}
