using System;
using System.Collections.Generic;

namespace LeoLang.Core
{
    /// <summary>
    /// Represents an optional value.
    /// </summary>
    /// <typeparam name="T">The type of the value to be wrapped.</typeparam>
    public struct Maybe<T> : IEquatable<Maybe<T>>, IComparable<Maybe<T>>
    {
        /// <summary>
        /// Checks if a value is present.
        /// </summary>
        public bool HasValue { get; }

        internal T Value { get; }

        internal Maybe(T value, bool hasValue)
        {
            this.Value = value;
            this.HasValue = hasValue;
        }

        /// <summary>
        /// Determines whether two optionals are equal.
        /// </summary>
        /// <param name="other">The optional to compare with the current one.</param>
        /// <returns>A boolean indicating whether or not the optionals are equal.</returns>
        public bool Equals(Maybe<T> other)
        {
            if (!HasValue && !other.HasValue)
            {
                return true;
            }
            else if (HasValue && other.HasValue)
            {
                return EqualityComparer<T>.Default.Equals(Value, other.Value);
            }

            return false;
        }

        /// <summary>
        /// Determines whether two optionals are equal.
        /// </summary>
        /// <param name="obj">The optional to compare with the current one.</param>
        /// <returns>A boolean indicating whether or not the optionals are equal.</returns>
        public override bool Equals(object obj) => obj is Maybe<T> ? Equals((Maybe<T>)obj) : false;

        /// <summary>
        /// Determines whether two optionals are equal.
        /// </summary>
        /// <param name="left">The first optional to compare.</param>
        /// <param name="right">The second optional to compare.</param>
        /// <returns>A boolean indicating whether or not the optionals are equal.</returns>
        public static bool operator ==(Maybe<T> left, Maybe<T> right) => left.Equals(right);

        /// <summary>
        /// Determines whether two optionals are unequal.
        /// </summary>
        /// <param name="left">The first optional to compare.</param>
        /// <param name="right">The second optional to compare.</param>
        /// <returns>A boolean indicating whether or not the optionals are unequal.</returns>
        public static bool operator !=(Maybe<T> left, Maybe<T> right) => !left.Equals(right);

        public static implicit operator bool(Maybe<T> value)
        {
            return value.HasValue;
        }

        public static implicit operator T(Maybe<T> value)
        {
            return value.Value;
        }

        /// <summary>
        /// Generates a hash code for the current optional.
        /// </summary>
        /// <returns>A hash code for the current optional.</returns>
        public override int GetHashCode()
        {
            if (HasValue)
            {
                return Value.GetHashCode();
            }

            return 0;
        }

        /// <summary>
        /// Compares the relative order of two optionals. An empty optional is
        /// ordered before a non-empty one.
        /// </summary>
        /// <param name="other">The optional to compare with the current one.</param>
        /// <returns>An integer indicating the relative order of the optionals being compared.</returns>
        public int CompareTo(Maybe<T> other)
        {
            if (HasValue && !other.HasValue) return 1;
            if (!HasValue && other.HasValue) return -1;
            return Comparer<T>.Default.Compare(Value, other.Value);
        }

        /// <summary>
        /// Determines if an optional is less than another optional.
        /// </summary>
        /// <param name="left">The first optional to compare.</param>
        /// <param name="right">The second optional to compare.</param>
        /// <returns>A boolean indicating whether or not the left optional is less than the right optional.</returns>
        public static bool operator <(Maybe<T> left, Maybe<T> right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines if an optional is less than or equal to another optional.
        /// </summary>
        /// <param name="left">The first optional to compare.</param>
        /// <param name="right">The second optional to compare.</param>
        /// <returns>A boolean indicating whether or not the left optional is less than or equal the right optional.</returns>
        public static bool operator <=(Maybe<T> left, Maybe<T> right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Determines if an optional is greater than another optional.
        /// </summary>
        /// <param name="left">The first optional to compare.</param>
        /// <param name="right">The second optional to compare.</param>
        /// <returns>A boolean indicating whether or not the left optional is greater than the right optional.</returns>
        public static bool operator >(Maybe<T> left, Maybe<T> right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines if an optional is greater than or equal to another optional.
        /// </summary>
        /// <param name="left">The first optional to compare.</param>
        /// <param name="right">The second optional to compare.</param>
        /// <returns>A boolean indicating whether or not the left optional is greater than or equal the right optional.</returns>
        public static bool operator >=(Maybe<T> left, Maybe<T> right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Returns a string that represents the current optional.
        /// </summary>
        /// <returns>A string that represents the current optional.</returns>
        public override string ToString()
        {
            if (HasValue)
            {
                return string.Format("Some({0})", Value);
            }

            return "None";
        }
    }
}