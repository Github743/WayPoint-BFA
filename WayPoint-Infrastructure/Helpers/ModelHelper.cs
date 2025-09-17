using WayPoint.Model;

namespace WayPoint_Infrastructure.Helpers
{
    public static class ModelHelper
    {
        public static void UpdateModelState(BaseModel model,
                                                    ObjectState state,
                                                    string userName,
                                                    DateTime? timeStampUtc)
        {
            var now = timeStampUtc?.ToUniversalTime() ?? DateTime.UtcNow;
            userName = userName[(userName.IndexOf("\\") + 1)..];

            switch (state)
            {
                case ObjectState.New:
                    model.Removed = false;
                    model.CreationDate = now;
                    model.CreatedBy = userName;
                    model.LastUpdateDate = now;
                    model.LastUpdatedBy = userName;
                    model.ModelState = ObjectState.New;
                    break;

                case ObjectState.Modified:
                    model.LastUpdateDate = now;
                    model.LastUpdatedBy = userName;
                    model.ModelState = ObjectState.Modified;
                    break;

                case ObjectState.Deleted:
                    model.Removed = true;
                    model.LastUpdateDate = now;
                    model.LastUpdatedBy = userName;
                    model.ModelState = ObjectState.Deleted;
                    break;

                case ObjectState.Unchanged:
                    // intentionally no changes
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}
