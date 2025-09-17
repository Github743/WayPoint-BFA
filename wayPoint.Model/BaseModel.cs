using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    public enum ObjectState
    {
        Unchanged = 0,
        New = 1,
        Modified = 2,
        Deleted = 8,
        NonEnhanced = 5
    }

    public enum ProcedureType
    {
        Get, Create, Update, Delete
    }
    public class BaseModel
    {
        [DbIgnore]
        [NotMapped]
        public ObjectState ModelState { get; set; }
        public bool Removed { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public string LastUpdatedBy { get; set; } = string.Empty;
        public DateTime LastUpdateDate { get; set; }
        [DbIgnore]
        public virtual string SchemaName { get { return string.Empty; } }

        public virtual string GetProcedureName(ProcedureType PT)
        {
            string _ProcedureType = string.Empty;

            string _EntityName = GetType().Name;
            string _SchemaName;
            if (string.IsNullOrWhiteSpace(SchemaName)) { _SchemaName = "dbo"; } else { _SchemaName = SchemaName; }

            if (PT == ProcedureType.Get)
            {
                _ProcedureType = PT.ToString();
            }
            else if (PT == ProcedureType.Create)
            {
                _ProcedureType =  PT.ToString();
            }
            else if (PT == ProcedureType.Update)
            {
                _ProcedureType = PT.ToString();
            }
            else if (PT == ProcedureType.Delete)
            {
                _ProcedureType = PT.ToString();
            }

            string _ProcedureName = _SchemaName + _ProcedureType + _EntityName;

            return _ProcedureName;
        }
    }
}
