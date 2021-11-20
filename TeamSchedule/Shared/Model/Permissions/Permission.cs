/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Model.Permissions
{
    using System.ComponentModel.DataAnnotations;

    public class Permission
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Id of the object which is being accessed
        /// </summary>
        [MaxLength(50)]
        public string ObjectId { get; set; }

        /// <summary>
        /// Used for conditional access. Docs TODO.
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// AccessData value, which defines permissions to a specific object.
        /// 'CRUDX' - create, read, update, delete, execute
        /// </summary>
        [MaxLength(5)]
        public string AccessData { get; set; }
    }
}
