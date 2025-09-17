using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WayPoint.Model
{
    public partial class Lookup : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "LK.usp_";
            }
        } // end of schema name property

        ///<summary>
        /// Get or Set the LookupId Property of Lookup
        /// LookupId is Not Nullable
        ///</summary>


        [DisplayName("Lookup Id")]
        public int LookupId { get; set; }

        ///<summary>
        /// Get or Set the LookupTypeId Property of Lookup
        /// LookupTypeId is Not Nullable
        ///</summary>


        [DisplayName("Lookup Type Id")]
        public int LookupTypeId { get; set; }

        ///<summary>
        /// Get or Set the Name Property of Lookup
        /// Name is Not Nullable
        ///</summary>
        
        [StringLength(150)]
        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the DisplayName Property of Lookup
        /// DisplayName is Not Nullable
        ///</summary>
        
        [StringLength(150)]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the Description Property of Lookup
        /// Description is Nullable 
        ///</summary>

        [StringLength(250)]
        [DisplayName("Description")]
        public string Description { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the LegacyValue Property of Lookup
        /// LegacyValue is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Legacy Value")]
        public string LegacyValue { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the Acronym Property of Lookup
        /// Acronym is Nullable 
        ///</summary>

        [StringLength(10)]
        [DisplayName("Acronym")]
        public string Acronym { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the CanShow Property of Lookup
        /// CanShow is Not Nullable
        ///</summary>


        [DisplayName("Can Show")]
        public bool CanShow { get; set; }

        [DisplayName("Default Order")]
        public int? DefaultOrder { get; set; }

        #endregion
    }
}
