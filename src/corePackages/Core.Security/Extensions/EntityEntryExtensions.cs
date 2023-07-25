using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.Security.Extensions
{
    public static class EntityEntryExtensions
    {
        /// <summary>
        /// Varlığın ve ilişkili Sahip olunan varlığın değişip değişmediğini kontrol edin.
        /// Bir nesnenin kendisinde veya iç içe geçmiş sahipli nesnelerinde herhangi bir değişiklik olup olmadığını belirlemek için kullanılabilir.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public static bool CheckOwnedEntityChange(this EntityEntry entry)
        {
            return entry.State == EntityState.Modified ||
                   entry.References.Any(r =>
                       r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && CheckOwnedEntityChange(r.TargetEntry));
        }
    }
}