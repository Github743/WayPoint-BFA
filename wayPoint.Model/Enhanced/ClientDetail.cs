namespace WayPoint.Model
{
    public partial class ClientDetail
    {
        public bool ClientSelected { get; set; }
        public int? EntityId { get; set; }
        public string ClientRoles { get; set; } = string.Empty;
    }
}
