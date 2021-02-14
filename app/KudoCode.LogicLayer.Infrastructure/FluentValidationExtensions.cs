using System;
using System.Globalization;
using System.Text.RegularExpressions;
using FluentValidation;
using KudoCode.Helpers;

namespace KudoCode.LogicLayer.Infrastructure
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> IsEmailAddress<T>
            (this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .EmailAddress()
                .WithMessage("A valid email address is required.");
        }

        public static IRuleBuilderOptions<T, string> NotContainSpecialCharacters<T>
            (this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(NotContainSpecialCharacters)
                .WithMessage("Input may not contain special characters.");
        }

        public static IRuleBuilderOptions<T, string> IsValidDate<T>
            (this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(BeAValidDate)
                .WithMessage("{PropertyName} Not a valid date");
        }

        public static IRuleBuilderOptions<T, string> IsValidInt<T>
            (this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(BeAValidInt)
                .WithMessage("{PropertyName} Not a valid int");
        }

        public static IRuleBuilderOptions<T, string> IsValidDecimal<T>
            (this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(BeAValidDecimal)
                .WithMessage("{PropertyName} Not a valid decimal");
        }

        private static bool NotContainSpecialCharacters(string value)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            return regexItem.IsMatch(value);
        }

        private static bool BeAValidDate(string value)
        {
            var date = value.ToDate();

            return date != default(DateTime);
        }

        private static bool BeAValidInt(string value)
        {
            return int.TryParse(value, out _);
        }

        private static bool BeAValidDecimal(string value)
        {
            return decimal.TryParse(value,NumberStyles.Any,CultureInfo.InvariantCulture, out _);
        }
    }
}