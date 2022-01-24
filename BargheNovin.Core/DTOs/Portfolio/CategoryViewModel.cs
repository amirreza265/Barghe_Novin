using System;

namespace BargheNovin.Core.DTOs.Portfolio
{
    public class CategoryViewModel : IEquatable<CategoryViewModel>
    {
        public string Name { get; set; }
        public string FilterName { get; set; }

        public bool Equals(CategoryViewModel other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.FilterName.Equals(other.FilterName) && this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            int IDHashCode = this.FilterName == null ? 0 : this.FilterName.GetHashCode();
            int NameHashCode = this.Name == null ? 0 : this.Name.GetHashCode();

            return IDHashCode ^ NameHashCode;
        }
    }
}
