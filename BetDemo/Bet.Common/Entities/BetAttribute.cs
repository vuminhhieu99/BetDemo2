using System;


namespace Bet.Common.Entities
{
    public class BetAttribute : Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string? PropertyName { get; set; }
        /// <summary>
        /// Câu cảnh báo tùy chỉnh
        /// </summary>
        public string? ErrorMessenger { get; set; }

        public BetAttribute(string? propertyName, string? errorMessenger = null)
        {
            this.PropertyName = propertyName ?? "";
            this.ErrorMessenger = errorMessenger ?? "";
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : BetAttribute
    {
        public Required(string? propertyName = null, string? errorMessenger = null) : base(propertyName, errorMessenger)
        {
            ;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : BetAttribute
    {
        /// <summary>
        /// Kích thước tối đa của property
        /// </summary>
        public int Length { get; set; }

        public MaxLength(int length, string? propertyName = null, string? errorMessenger = null) : base(propertyName, errorMessenger)
        {
            this.Length = length;
        }
    }

    public class FixLength : BetAttribute
    {
        /// <summary>
        /// Kích thước cố định của property
        /// </summary>
        public int Length { get; set; }

        public FixLength(int length, string? propertyName = null, string? errorMessenger = null) : base(propertyName, errorMessenger)
        {
            this.Length = length;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TableName : BetAttribute
    {
        /// <summary>
        /// Kích thước cố định của property
        /// </summary>
        public string? Name { get; set; }

        public TableName(string name, string? propertyName = null, string? errorMessenger = null) : base(propertyName, errorMessenger)
        {
            this.Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Column : BetAttribute
    {
        /// <summary>
        /// Kích thước cố định của property
        /// </summary>       

        public Column(string? propertyName = null, string? errorMessenger = null) : base(propertyName, errorMessenger)
        {
        }
           
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class Key : BetAttribute
    {
        /// <summary>
        /// Kích thước cố định của property
        /// </summary>       

        public Key(string? propertyName = null, string? errorMessenger = null) : base(propertyName, errorMessenger)
        {
        }

    }
}
