using System;

namespace Models
{
    public class Item : IAuditable
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UpdateBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DeletedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Delete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
