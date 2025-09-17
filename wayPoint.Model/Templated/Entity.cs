using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class Entity : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "FN.usp_";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the EntityId Property of Entity
        /// EntityId is Not Nullable
        ///</summary>


        [DisplayName("Entity Id")]
        public int EntityId { get; set; }

        ///<summary>
        /// Get or Set the EntityType Property of Entity
        /// EntityType is Not Nullable
        ///</summary>


        [DisplayName("Entity Type")]
        public int EntityType { get; set; }

        #endregion
    }
}
