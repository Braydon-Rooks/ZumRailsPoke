using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZumPokeApi.Controllers
{
    public class PokeFilter : IValidatableObject
    {
        [Required]
        public required string SortBy { get; set; }
        public string? SortDirection { get; set; }

        private readonly List<string> _accecptedFilters = ["wins", "losses", "ties", "name", "id"];

        private readonly List<string> _acceptedDirections = ["asc", "desc"];
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!_accecptedFilters.Contains(SortBy.ToLower()))
            {
                yield return new ValidationResult($"sortBy parameter is invalid", new[] { nameof(SortBy) });
            }
            if (SortDirection != null && !_acceptedDirections.Contains(SortDirection.ToLower()))
            {
                yield return new ValidationResult($"sortDirection parameter is invalid", new[] { nameof(SortDirection) });
            }
        }
    }
}
